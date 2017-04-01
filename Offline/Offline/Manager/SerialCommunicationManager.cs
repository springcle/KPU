using Offline.Utilities;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

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
        private SerialCommunicationManager() { }
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
    public partial class SerialCommunicationManager
    {
        //rawData
        public int[] data { get; private set; }
        /*
         * currentData 
         * 0 - > count
         * 1 to 8 channel 
         * Accelerometer Dat
         */

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
    }

    /*Func*/
    public partial class SerialCommunicationManager
    {
        public string[] FindPorts()
        {
            string[] result = SerialPort.GetPortNames();
            if (result == null)
                throw new NullReferenceException();
            return result;
        }

        //syncronize data in serail stream
        private void sync(SerialPort port, int bit)
        {
            if (port == null) return;
            if (!port.IsOpen) port.Open();

            OfflineTimer timer = new OfflineTimer();
            timer.start();
            try
            {
                while (port.ReadByte() != bit)
                {
                    if (timer.currentTime.Seconds > timeOut)
                    {
                        throw new TimeoutException();
                    }
                    continue;
                }
            }
            catch
            {
                throw new Exception();
            }
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

            if (port == null || !port.IsOpen) return;
            int[] buffer = new int[dataLength];

            sync(port, endBit);
            int MSB = port.ReadByte();
            if (MSB != startBit)
            {
                sync(port, endBit);
            }
            buffer[0] = MSB;
            for (int cnt = 1; cnt < buffer.Length; cnt++)
            {
                buffer[cnt] = port.ReadByte();
            }
            int LSB = buffer[buffer.Length - 1];
            if (LSB != endBit)
            {
                sync(port, endBit);
            }
            data = processingRawData(buffer);
            
        }

        public void writeData()
        {
            if (port == null) return;
            port.Write(startCommand);
        }

        //attempt to connect after find all ports
        public bool AutoConnect()
        {
            try
            {
                string[] connectedComPort = FindPorts();
                Thread[] connectThread = new Thread[connectedComPort.Length];

                foreach (var each in connectedComPort.Select((value, index) => new { Value = value, Index = index }))
                {
                    int index = each.Index;
                    string comport = each.Value;
                    Action thread = () => { connect(comport); };
                    connectThread[index] = new Thread(new ThreadStart(thread));
                }
                foreach (var each in connectThread)
                {
                    each.IsBackground = true;
                    each.Start();
                    each.Join();
                }
            }
            catch
            {
                return false;
            }
            return true;
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
    }
}
