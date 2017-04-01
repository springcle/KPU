using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Offline.DataStructure;
using System.Reflection.Emit;
using Offline.Utilities;

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
    /**

        public partial class IOManager
        {
            public void read()
            {
                string filePath;
                Excel.Application RExeclApp = new Excel.Application();
                RExeclApp.Visible = false;


    int[] ch1_8 = new int[8];

            ch1_8[0] = 1;
            ch1_8[1] = 1;
            ch1_8[2] = 1;
            ch1_8[3] = 1;
            ch1_8[4] = 1;
            ch1_8[5] = 1;
            ch1_8[6] = 1;
            ch1_8[7] = 1;

            EEG eeg = new EEG(ch1_8);
            DataManager.getInstance.analysis_EEG_data.Add(eeg);
        }

        public void write(List<EEG> EEG_data)
        {
            Excel.Application WExeclApp = new Excel.Application();
            WExeclApp.Visible = false;
            Excel.Workbook workBook = WExeclApp.Workbooks.Add(); //워크북 추가
            Excel._Worksheet workSheet = (Excel.Worksheet)WExeclApp.ActiveSheet; // 활성워크시트 설정
            StringBuilder filePath = new StringBuilder(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            filePath.Append("\\");
            filePath.Append(TimeBuilder.getInstance.setYear().setMonth().setDay().setTime().build()); //파일이름: 현재시간

            for (int i = 0; i < EEG_data.Count; i++)
            {
                workSheet.Cells[i, 1] = EEG_data[i].ch1;
                workSheet.Cells[i, 1] = EEG_data[i].ch2;
                workSheet.Cells[i, 1] = EEG_data[i].ch3;
                workSheet.Cells[i, 1] = EEG_data[i].ch4;
                workSheet.Cells[i, 1] = EEG_data[i].ch5;
                workSheet.Cells[i, 1] = EEG_data[i].ch6;
                workSheet.Cells[i, 1] = EEG_data[i].ch7;
                workSheet.Cells[i, 1] = EEG_data[i].ch8;
            }

            workBook.SaveAs(filePath.ToString());
            workBook.Close();
            WExeclApp.Quit();

            Marshal.ReleaseComObject(workSheet);
            Marshal.ReleaseComObject(workBook);
            Marshal.ReleaseComObject(WExeclApp);
        }
        **/
}

