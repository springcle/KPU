using Offline.Utilities;
using OpenBCI_GUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using static OpenBCI_GUI.GraphForm;

namespace Offline.Manager
{
    //SingleTon Property
    public partial class SerialCommunicationManager
    {
        public void init()
        {
            disConnect();
            instance = null;
        }
        private SerialCommunicationManager()
        {
        }
        private static SerialCommunicationManager instance;
        public static SerialCommunicationManager getInstance
        {
            get
            {
                if (instance == null) instance = new SerialCommunicationManager();
                return instance;
            }
        }
    }

    //protocol
    public partial class SerialCommunicationManager
    {
        public static readonly string stopCommand = "s";
        public static readonly string startCommand = "b";
        public static readonly int startBit = 0xA0;
        public static readonly int endBit = 0xC0;
        public static readonly int dataLength = 32;
        public static readonly float timeOut = 3;
        public static readonly int baudRate = 115200;
        public static readonly Parity parity = Parity.None;
        public static readonly int dataBits = 8;
        public static readonly StopBits stopBits = StopBits.One;
        public static readonly Encoding encoding = Encoding.UTF8;
    }

    //Filed
    public partial class SerialCommunicationManager:IDisposable
    {
        public Queue<DaneSerialPort> driver = new Queue<DaneSerialPort>();

        //port
        private SerialPort port { get; set; }
       

        public bool isOpen
        {
            get
            {
                if (port == null) return false;
                return port.IsOpen;
            }
        }

        public void Dispose()
        {
            if (port != null)
                if (port.IsOpen) port.Close();
        }
        public string currentData { get; private set; }
    }

    /*Func*/
    public partial class SerialCommunicationManager
    {
        public static string[] FindPorts()
        {
            string[] result = SerialPort.GetPortNames();
            if (result == null)
                throw new NullReferenceException();
            return result;
        }


        //explicit connect
        public void connect(string portName)
        {
            if (port != null && port.IsOpen)
            {
                return;
            }
            try
            {
                Task task = Task.Run(() =>
                {
                    SerialPort temp = null;
                    try
                    {
                        temp = getPort(portName);
                        temp.Encoding = encoding;
                        temp.DataReceived += Update;
                        temp.Open();
                        this.port = temp;
                    }
                    catch(Exception E)
                    {
                        if (temp != null) temp.Close();
                    }
                });
                TimeSpan ts = TimeSpan.FromSeconds(10);
                if (!task.Wait(ts))
                    throw new TimeoutException();
            }
            catch (TimeoutException e)
            {
                if (port != null) port.Close();
                MessageBox.Show(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                if (port != null) port.Close();
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                if (port != null) port.Close();
                MessageBox.Show(e.Message);
            }
  
        }
        private void Update(object sender, SerialDataReceivedEventArgs e)
        {
            DaneSerialPort odebrane_dane;
            byte[] buffer = new byte[port.BytesToRead];
            port.Read(buffer, 0, buffer.Length);
            odebrane_dane.zmienna = buffer;
            driver.Enqueue(odebrane_dane);
        }
        Thread stremingThread;

        public void startStreming()
        {
            if (stremingThread != null) return;

            if (port == null) return;
            driver.Clear();
            port.Write(startCommand);

            stremingThread = new Thread(new ThreadStart(DoRecord));
            stremingThread.Start();


        }

        public void stopStreming()
        {
            if (port == null) return;   
            port.Write(stopCommand);
            stremingThread.Abort();
            stremingThread.Join();
            stremingThread = null;
        }
        //disconnect
        public void disConnect()
        {
 
            if (port != null && port.IsOpen) port.Close();
        }

        //getPort
        private SerialPort getPort(string portName)
        {
            try
            {
                SerialPort temp = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
                if (temp == null) throw new ArgumentNullException();
                return temp;
            }
            catch (System.IO.IOException e)
            {
                throw e;
            }
        }
        private int[] processingRawData(int[] rawdatas)
        {
            if (rawdatas.Length != dataLength) throw new ArgumentException();

            Func<int[], int, int, int> parse = (data, start, End) =>
            {
                int[] subAry = rawdatas.Skip(start).Take(End).ToArray();
                byte[] byteAry = { (byte)rawdatas[0], (byte)rawdatas[1], (byte)rawdatas[2] };
                int result = parseInt24To32(byteAry);
                return result;
            };

            int[] temp = new int[12];
            int rate = 3;
            temp[0] = rawdatas[1];

            for (int cnt = 1; cnt <= 8; cnt++)
            {
                int offset = (rate * (cnt - 1));
                int min = 2 + offset;
                int max = 4 + offset;
                temp[cnt] = parse(rawdatas, min, max);
            }
            temp[9] = parse(rawdatas, 26, 27); //x축가속도값
            temp[10] = parse(rawdatas, 28, 29); //y축
            temp[11] = parse(rawdatas, 30, 31); //z축
            return temp;
        }


        //used int at 24 bit in bci so transform 32 bit
        private int parseInt24To32(byte[] byteArray)
        {
            int newInt = (
               ((0xFF & byteArray[0]) << 16) |
               ((0xFF & byteArray[1]) << 8) |
               (0xFF & byteArray[2])
              );
            //MSB가 1이면 (보수사용)
            if ((newInt & 0x00800000) > 0)
                newInt = ~newInt + 1;
            else
                newInt &= 0x00FFFFFF;
            return newInt;
        }
        private double[] filtering(int standard, int notch, double[] dane)
        {
            for (int i = 0; i < 8; i++)
            {
                dane[i + 1] = Filters.FiltersSelect(standard, notch, dane[i + 1], i);
            }

            return dane;
        }

        private void DoRecord()
        {
            double[] daneRys;
          
            try
            {
              

                while (isOpen)
                {
                    while (driver.Count > 0)
                    {
                        Console.WriteLine("step 1");
                        DaneSerialPort data = driver.Dequeue();
                        Console.WriteLine("step 2");
                        for (int g = 0; g < data.zmienna.Length; g++)
                        {
                            Console.WriteLine("loop1");
                            daneRys = OpenBCI_GUI.Convert.interpretBinaryStream(data.zmienna[g]);
                            Console.WriteLine("loop2");
                            if (daneRys != null)
                            {

                                Console.WriteLine("loop3");
                                double mnoz = (4.5 / 24 / (Math.Pow(2, 23) - 1)) * (Math.Pow(10, 6));

                                Console.WriteLine("loop4");
                                for (int i = 0; i < 8; i++)
                                {
                                    daneRys[i + 1] = daneRys[i + 1] * mnoz;
                                }

                                Console.WriteLine("loop5");
                                string str = string.Empty;
                                foreach(var each in daneRys)
                                {
                                    str += each + ",";
                                }
                                str.Remove(str.Length - 1);
                                currentData = str;

                                Console.WriteLine("loop6");
                                filtering(0, 0, daneRys);

                                Console.WriteLine("loop7");
                            }
                        }
                        Console.WriteLine("step 3");
                    }
                    Thread.Sleep(50);
                }
        
            }
            catch (Exception e)
            {
                MessageBox.Show("확인");
            }
        }
           
    }
}




