using Offline.DataStructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;

namespace Offline.Manager
{
    //SingleTone Proputy
    public partial class IOManager
    {
        private static IOManager Instance;
        public static IOManager getInstance
        {
            get
            {
                if (Instance == null) Instance = new IOManager();
                return Instance;
            }
        }
        private IOManager() { }
    }


    public partial class IOManager
    {
        StreamReader sr;
        StreamWriter sw;
        public void ReadOpen()
        {

            try
            {
                string myDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string path = Path.Combine(myDoc +
                    "\\" + LoginManager.getInstance.currentLoginUser.id + ".txt");
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                sr = new StreamReader(path);
            }
            catch (Exception e)
            {
                MessageBox.Show("read open error\n"+e.Message);
                Console.WriteLine("open error");
                throw e;
            }
        }
        public void WriteOpen()
        {

            try
            {
                string myDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string path = Path.Combine(myDoc +
                    "\\" + LoginManager.getInstance.currentLoginUser.id + ".txt");
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                sw = new StreamWriter(path);
            }
            catch (Exception e)
            {
                MessageBox.Show("write open error\n"+e.Message);
                Console.WriteLine("open error");
                throw e;
            }
        }

        public void Close()
        {
            if (sr != null)
            {
                sr.Close();
            }
            if (sw != null)
            {
                sw.Close();
            }
        }

        public void write(double[] data)
        {

            if (sw == null) WriteOpen();

            Console.WriteLine("write 1");
            for (int cnt = 0; cnt < data.Length; cnt++)
            {
                Console.WriteLine("writeLoop1");
                if (sw == null) Console.WriteLine("writeLoop error");
                sw.Write("{0},", data[cnt]);
            }

            sw.WriteLine("");

        }
        public List<EEG> read()
        {

            if (sr == null) ReadOpen();
            List<EEG> returnValue = new List<EEG>();
            double[] ch1_8 = new double[8];

            while (!sr.EndOfStream)
            {
                try
                {
                    Console.WriteLine("reading File");
                    //1~8 ch 
                    string str = sr.ReadLine();
                    string[] daneRys = str.Split(',');
                    ch1_8[0] = double.Parse(daneRys[1].ToString());
                    ch1_8[1] = double.Parse(daneRys[2].ToString());
                    ch1_8[2] = double.Parse(daneRys[3].ToString());
                    ch1_8[3] = double.Parse(daneRys[4].ToString());
                    ch1_8[4] = double.Parse(daneRys[5].ToString());
                    ch1_8[5] = double.Parse(daneRys[6].ToString());
                    ch1_8[6] = double.Parse(daneRys[7].ToString());
                    ch1_8[7] = double.Parse(daneRys[8].ToString());
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    break;
                }
                EEG eeg = new EEG(ch1_8);
                returnValue.Add(eeg);
            }
            return returnValue;

        }



    }
}



