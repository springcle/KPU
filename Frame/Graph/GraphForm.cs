using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using Offline.Properties;
using System.Resources;
using System.Reflection;
using Offline.Manager;

namespace OpenBCI_GUI
{
    public partial class GraphForm : UserControl,IDisposable
    {
        double ch1_mean = 0;
        double sum1 = 0;
        int sumCount1;
        public int BLINKED;
        bool istniejeSW = false;
        Image ClosedEye;
        Image OpenedEye;
        
        public new void Dispose()
        {
            if (serialPort1 != null)
                if (serialPort1.IsOpen)
                    serialPort1.Close();


        }
        public GraphForm()
        {
            InitializeComponent();
            ConsoleLib.ConsoleLib.CreateConsole();

            ClosedEye = Resources.ClosedEye;
            OpenedEye = Resources.OpenedEye;

            if (ClosedEye == null || OpenedEye == null)
            {
                MessageBox.Show("널");
            }


            textBox2.Text = Application.StartupPath;
        

            radioButton4.Checked = true;
            radioButton5.Checked = true;
            radioButton8.Checked = true;

            button5.Enabled = false;
            button6.Enabled = false;

            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            checkBox5.Checked = true;
            checkBox6.Checked = true;
            checkBox7.Checked = true;
            checkBox8.Checked = true;
        }
        
       public struct DaneSerialPort
        {
            public byte[] zmienna;
        };

        Queue<DaneSerialPort> driver = new Queue<DaneSerialPort>();


        void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DaneSerialPort odebrane_dane;
            byte[] buffer = new byte[serialPort1.BytesToRead];
            serialPort1.Read(buffer, 0, buffer.Length);
            odebrane_dane.zmienna = buffer;
            driver.Enqueue(odebrane_dane);

        }

        public void OpenPort(string port)
        {
            textBox3.Text = LoginManager.getInstance.currentLoginUser.id + ".txt";
            serialPort1.PortName = port;
            serialPort1.BaudRate = 115200;
            serialPort1.DataReceived += serialPort1_DataReceived;
            serialPort1.Open();
        }

        private void ClosePort(object sender, EventArgs e)
        {
            turnOFF_SW();
            turnOFF_transmision();
            serialPort1.Close();
            button5.Enabled = false;
            button6.Enabled = false;
        }
        public void ClosePort()
        {
            turnOFF_SW();
            turnOFF_transmision();
            serialPort1.Close();
            button5.Enabled = false;
            button6.Enabled = false;
        }


        public void StartStreming()
        {
            char[] buff = new char[1];
            buff[0] = 'b';
            try
            {
                serialPort1.Write(buff, 0, 1);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
               
            }
        }

        public void StopStreming()
        {
            turnOFF_SW();
            turnOFF_transmision();
        }

        //SaveFile Start
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {   
                istniejeSW = true;
            }
            catch
            {
               // MessageBox.Show("Nie można utworzyć katalogu bezpośrednio na głównej partycji.");
            }
            button5.Enabled = false;
            button6.Enabled = true;
        }

        //SaveFile Stop
        private void button6_Click(object sender, EventArgs e)
        {
            turnOFF_SW();
            button5.Enabled = true;
            button6.Enabled = false;
        }

       
        // public bool blink_detect(ref double ch, double value)
        public bool blink_detect(ref double mean,ref double sum,ref int sumCount,double value)
        {
            bool blink = false;
            if(sumCount++< 25)
            {
                sum += Math.Abs ( value );
                return false;
            }

            mean = sum / sumCount;
      
            double temp = (Math.Abs(value) - mean );
            sumCount = 0;
            sum = 0;
          

            if ( (temp >100) && Math.Abs(value)>100)
            {
                 blink = true;
                BLINKED++;
                Console.WriteLine("*************************Blink*************************");
            }
            else
            {
                blink = false;
 
            }
          
            return blink;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            double[] daneRys;
 
            while (driver.Count > 0)
            {
                DaneSerialPort data = driver.Dequeue();
                for (int g = 0; g < data.zmienna.Length; g++)
                {
                    daneRys = Convert.interpretBinaryStream(data.zmienna[g]);
                    if (daneRys != null)
                    {
                        daneRys = ValueOrZero(daneRys);
                        writeToFile(daneRys);
                        drawPlot(daneRys);
                        bool isBlink = blink_detect(ref ch1_mean,ref sum1,ref sumCount1,daneRys[1]);
                        if (isBlink)
                        {
                            pictureBox1.Invoke((MethodInvoker)delegate { pictureBox1.Image = ClosedEye; });
                        }
                        else
                        {
                            pictureBox1.Invoke((MethodInvoker)delegate { pictureBox1.Image = OpenedEye; });
                        }
                    }
                }
            }

        }

        private void writeToFile(double[] daneRys)
        {
            double mnoz = (4.5 / 24 / (Math.Pow(2, 23) - 1)) * (Math.Pow(10, 6));

            for (int i = 0; i < 8; i++)
            {
                daneRys[i + 1] = daneRys[i + 1] * mnoz;
            }
            if (istniejeSW)
            {
            }
        }

        private void drawPlot(double[] dane)
        {
            dane = filtering(dane);

                chart1.Series[0].Points.Add(dane[0]);
                chart2.Series[0].Points.Add(dane[1]);
                chart3.Series[0].Points.Add(dane[2]);
                chart4.Series[0].Points.Add(dane[3]);
                chart5.Series[0].Points.Add(dane[4]);
                chart6.Series[0].Points.Add(dane[5]);
                chart7.Series[0].Points.Add(dane[6]);
                chart8.Series[0].Points.Add(dane[7]);
                chart9.Series[0].Points.Add(dane[8]);

                while (chart1.Series[0].Points.Count > 1250)
                {
                    chart1.Series[0].Points.SuspendUpdates();
                    chart1.Series[0].Points.Remove(chart1.Series[0].Points.First());
                    chart1.Series[0].Points.ResumeUpdates();

                    chart2.Series[0].Points.SuspendUpdates();
                    chart2.Series[0].Points.Remove(chart2.Series[0].Points.First());
                    chart2.Series[0].Points.ResumeUpdates();

                    chart3.Series[0].Points.SuspendUpdates();
                    chart3.Series[0].Points.Remove(chart3.Series[0].Points.First());
                    chart3.Series[0].Points.ResumeUpdates();

                    chart4.Series[0].Points.SuspendUpdates();
                    chart4.Series[0].Points.Remove(chart4.Series[0].Points.First());
                    chart4.Series[0].Points.ResumeUpdates();

                    chart5.Series[0].Points.SuspendUpdates();
                    chart5.Series[0].Points.Remove(chart5.Series[0].Points.First());
                    chart5.Series[0].Points.ResumeUpdates();

                    chart6.Series[0].Points.SuspendUpdates();
                    chart6.Series[0].Points.Remove(chart6.Series[0].Points.First());
                    chart6.Series[0].Points.ResumeUpdates();

                    chart7.Series[0].Points.SuspendUpdates();
                    chart7.Series[0].Points.Remove(chart7.Series[0].Points.First());
                    chart7.Series[0].Points.ResumeUpdates();

                    chart8.Series[0].Points.SuspendUpdates();
                    chart8.Series[0].Points.Remove(chart8.Series[0].Points.First());
                    chart8.Series[0].Points.ResumeUpdates();

                    chart9.Series[0].Points.SuspendUpdates();
                    chart9.Series[0].Points.Remove(chart9.Series[0].Points.First());
                    chart9.Series[0].Points.ResumeUpdates();
                }
        }

        private double[] ValueOrZero(double[] dane)
        {
            if (!checkBox1.Checked)
            {
                dane[1] = 0;
            }
            if (!checkBox2.Checked)
            {
                dane[2] = 0;
            }
            if (!checkBox3.Checked)
            {
                dane[3] = 0;
            }
            if (!checkBox4.Checked)
            {
                dane[4] = 0;
            }
            if (!checkBox5.Checked)
            {
                dane[5] = 0;
            }
            if (!checkBox6.Checked)
            {
                dane[6] = 0;
            }
            if (!checkBox7.Checked)
            {
                dane[7] = 0;
            }
            if (!checkBox8.Checked)
            {
                dane[8] = 0;
            }
            return dane;
        }

        private double[] filtering(double[] dane)
        {
            int standard = 0;
            int notch =0;

            if (radioButton5.Checked)
            {
                notch = 0;
            }
            else if (radioButton6.Checked)
            {
                notch = 1;
            }
            else if (radioButton7.Checked)
            {
                notch = 2;
            }
            if (radioButton8.Checked)
            {
                standard = 0;
            }
            if (radioButton9.Checked)
            {
                standard = 1;
            }
            if (radioButton10.Checked)
            {
                standard = 2;
            }
            if (radioButton11.Checked)
            {
                standard = 3;
            }
            if (radioButton12.Checked)
            {
                standard = 4;
            }

            for (int i = 0; i < 8; i++)
            {
                dane[i + 1] = Filters.FiltersSelect(standard, notch, dane[i + 1], i);
            }

            return dane;
        }

        private void turnOFF_SW()
        {
            if (istniejeSW)
            {
                istniejeSW = false;
                }
        }
        private void turnOFF_transmision()
        {
            char[] buff = new char[1];
            buff[0] = 's';
            serialPort1.Write(buff, 0, 1);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //-1V 1V
            chart2.ChartAreas[0].AxisY.Maximum = 1000000;
            chart2.ChartAreas[0].AxisY.Minimum = -1000000;

            chart3.ChartAreas[0].AxisY.Maximum = 1000000;
            chart3.ChartAreas[0].AxisY.Minimum = -1000000;

            chart4.ChartAreas[0].AxisY.Maximum = 1000000;
            chart4.ChartAreas[0].AxisY.Minimum = -1000000;

            chart5.ChartAreas[0].AxisY.Maximum = 1000000;
            chart5.ChartAreas[0].AxisY.Minimum = -1000000;

            chart6.ChartAreas[0].AxisY.Maximum = 1000000;
            chart6.ChartAreas[0].AxisY.Minimum = -1000000;

            chart7.ChartAreas[0].AxisY.Maximum = 1000000;
            chart7.ChartAreas[0].AxisY.Minimum = -1000000;

            chart8.ChartAreas[0].AxisY.Maximum = 1000000;
            chart8.ChartAreas[0].AxisY.Minimum = -1000000;

            chart9.ChartAreas[0].AxisY.Maximum = 1000000;
            chart9.ChartAreas[0].AxisY.Minimum = -1000000;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //-100mV 100mV
            chart2.ChartAreas[0].AxisY.Maximum = 100000;
            chart2.ChartAreas[0].AxisY.Minimum = -100000;

            chart3.ChartAreas[0].AxisY.Maximum = 100000;
            chart3.ChartAreas[0].AxisY.Minimum = -100000;

            chart4.ChartAreas[0].AxisY.Maximum = 100000;
            chart4.ChartAreas[0].AxisY.Minimum = -100000;

            chart5.ChartAreas[0].AxisY.Maximum = 100000;
            chart5.ChartAreas[0].AxisY.Minimum = -100000;

            chart6.ChartAreas[0].AxisY.Maximum = 100000;
            chart6.ChartAreas[0].AxisY.Minimum = -100000;

            chart7.ChartAreas[0].AxisY.Maximum = 100000;
            chart7.ChartAreas[0].AxisY.Minimum = -100000;

            chart8.ChartAreas[0].AxisY.Maximum = 100000;
            chart8.ChartAreas[0].AxisY.Minimum = -100000;

            chart9.ChartAreas[0].AxisY.Maximum = 100000;
            chart9.ChartAreas[0].AxisY.Minimum = -100000;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //-10mv 10mv
            chart2.ChartAreas[0].AxisY.Maximum = 10000;
            chart2.ChartAreas[0].AxisY.Minimum = -10000;

            chart3.ChartAreas[0].AxisY.Maximum = 10000;
            chart3.ChartAreas[0].AxisY.Minimum = -10000;

            chart4.ChartAreas[0].AxisY.Maximum = 10000;
            chart4.ChartAreas[0].AxisY.Minimum = -10000;

            chart5.ChartAreas[0].AxisY.Maximum = 10000;
            chart5.ChartAreas[0].AxisY.Minimum = -10000;

            chart6.ChartAreas[0].AxisY.Maximum = 10000;
            chart6.ChartAreas[0].AxisY.Minimum = -10000;

            chart7.ChartAreas[0].AxisY.Maximum = 10000;
            chart7.ChartAreas[0].AxisY.Minimum = -10000;

            chart8.ChartAreas[0].AxisY.Maximum = 10000;
            chart8.ChartAreas[0].AxisY.Minimum = -10000;

            chart9.ChartAreas[0].AxisY.Maximum = 10000;
            chart9.ChartAreas[0].AxisY.Minimum = -10000;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //-1mV
            chart2.ChartAreas[0].AxisY.Maximum = 1000;
            chart2.ChartAreas[0].AxisY.Minimum = -1000;

            chart3.ChartAreas[0].AxisY.Maximum = 1000;
            chart3.ChartAreas[0].AxisY.Minimum = -1000;

            chart4.ChartAreas[0].AxisY.Maximum = 1000;
            chart4.ChartAreas[0].AxisY.Minimum = -1000;

            chart5.ChartAreas[0].AxisY.Maximum = 1000;
            chart5.ChartAreas[0].AxisY.Minimum = -1000;

            chart6.ChartAreas[0].AxisY.Maximum = 1000;
            chart6.ChartAreas[0].AxisY.Minimum = -1000;

            chart7.ChartAreas[0].AxisY.Maximum = 1000;
            chart7.ChartAreas[0].AxisY.Minimum = -1000;

            chart8.ChartAreas[0].AxisY.Maximum = 1000;
            chart8.ChartAreas[0].AxisY.Minimum = -1000;

            chart9.ChartAreas[0].AxisY.Maximum = 1000;
            chart9.ChartAreas[0].AxisY.Minimum = -1000;
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            //-100uV
            chart2.ChartAreas[0].AxisY.Maximum = 100;
            chart2.ChartAreas[0].AxisY.Minimum = -100;

            chart3.ChartAreas[0].AxisY.Maximum = 100;
            chart3.ChartAreas[0].AxisY.Minimum = -100;

            chart4.ChartAreas[0].AxisY.Maximum = 100;
            chart4.ChartAreas[0].AxisY.Minimum = -100;

            chart5.ChartAreas[0].AxisY.Maximum = 100;
            chart5.ChartAreas[0].AxisY.Minimum = -100;

            chart6.ChartAreas[0].AxisY.Maximum = 100;
            chart6.ChartAreas[0].AxisY.Minimum = -100;

            chart7.ChartAreas[0].AxisY.Maximum = 100;
            chart7.ChartAreas[0].AxisY.Minimum = -100;

            chart8.ChartAreas[0].AxisY.Maximum = 100;
            chart8.ChartAreas[0].AxisY.Minimum = -100;

            chart9.ChartAreas[0].AxisY.Maximum = 100;
            chart9.ChartAreas[0].AxisY.Minimum = -100;
        }
    }
}
