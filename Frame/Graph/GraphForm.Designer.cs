using System.Windows.Forms;

namespace OpenBCI_GUI
{
    partial class GraphForm:UserControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.chart5 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.chart6 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.chart7 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.chart8 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel12 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.chart9 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.flowLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.flowLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            this.flowLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart5)).BeginInit();
            this.flowLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart6)).BeginInit();
            this.flowLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart7)).BeginInit();
            this.flowLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart8)).BeginInit();
            this.flowLayoutPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart9)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1381, 610);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel6);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel7);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel8);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel9);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel10);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel11);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel12);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1123, 591);
            this.flowLayoutPanel2.TabIndex = 31;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.chart1);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(1120, 60);
            this.flowLayoutPanel4.TabIndex = 44;
            // 
            // chart1
            // 
            this.chart1.AllowDrop = true;
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.Maximum = 1250D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.ScaleView.Zoomable = false;
            chartArea1.AxisX.ScrollBar.Enabled = false;
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.Maximum = 256D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Color = System.Drawing.Color.Black;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1100, 40);
            this.chart1.TabIndex = 27;
            this.chart1.Text = "chart1";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.checkBox1);
            this.flowLayoutPanel6.Controls.Add(this.chart2);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 69);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(1120, 60);
            this.flowLayoutPanel6.TabIndex = 46;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 28;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chart2
            // 
            this.chart2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.IsMarginVisible = false;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisX.Maximum = 1250D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.ScaleView.Zoomable = false;
            chartArea2.AxisX.ScrollBar.Enabled = false;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Enabled = false;
            chartArea2.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(3, 23);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Color = System.Drawing.Color.Silver;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(1100, 40);
            this.chart2.TabIndex = 29;
            this.chart2.Text = "chart2";
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Controls.Add(this.checkBox2);
            this.flowLayoutPanel7.Controls.Add(this.chart3);
            this.flowLayoutPanel7.Location = new System.Drawing.Point(3, 135);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(1120, 60);
            this.flowLayoutPanel7.TabIndex = 47;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(3, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 37;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // chart3
            // 
            this.chart3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.IsMarginVisible = false;
            chartArea3.AxisX.LabelStyle.Enabled = false;
            chartArea3.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX.MajorTickMark.Enabled = false;
            chartArea3.AxisX.Maximum = 1250D;
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.AxisX.ScaleView.Zoomable = false;
            chartArea3.AxisX.ScrollBar.Enabled = false;
            chartArea3.AxisY.LabelStyle.Enabled = false;
            chartArea3.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.AxisY.MajorTickMark.Enabled = false;
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(3, 23);
            this.chart3.Name = "chart3";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Color = System.Drawing.Color.MediumPurple;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart3.Series.Add(series3);
            this.chart3.Size = new System.Drawing.Size(1100, 40);
            this.chart3.TabIndex = 30;
            this.chart3.Text = "chart3";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.checkBox3);
            this.flowLayoutPanel5.Controls.Add(this.chart4);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 201);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(1120, 60);
            this.flowLayoutPanel5.TabIndex = 48;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(3, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 38;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // chart4
            // 
            this.chart4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.AxisX.IsLabelAutoFit = false;
            chartArea4.AxisX.IsMarginVisible = false;
            chartArea4.AxisX.LabelStyle.Enabled = false;
            chartArea4.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisX.MajorTickMark.Enabled = false;
            chartArea4.AxisX.Maximum = 1250D;
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.AxisX.ScaleView.Zoomable = false;
            chartArea4.AxisX.ScrollBar.Enabled = false;
            chartArea4.AxisY.LabelStyle.Enabled = false;
            chartArea4.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea4.AxisY.MajorGrid.Enabled = false;
            chartArea4.AxisY.MajorTickMark.Enabled = false;
            chartArea4.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea4);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.chart4.Legends.Add(legend4);
            this.chart4.Location = new System.Drawing.Point(3, 23);
            this.chart4.Name = "chart4";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.Color = System.Drawing.Color.RoyalBlue;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart4.Series.Add(series4);
            this.chart4.Size = new System.Drawing.Size(1100, 40);
            this.chart4.TabIndex = 31;
            this.chart4.Text = "chart4";
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.Controls.Add(this.checkBox4);
            this.flowLayoutPanel8.Controls.Add(this.chart5);
            this.flowLayoutPanel8.Location = new System.Drawing.Point(3, 267);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(1120, 60);
            this.flowLayoutPanel8.TabIndex = 49;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(3, 3);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 39;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // chart5
            // 
            this.chart5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea5.AxisX.IsLabelAutoFit = false;
            chartArea5.AxisX.IsMarginVisible = false;
            chartArea5.AxisX.LabelStyle.Enabled = false;
            chartArea5.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea5.AxisX.MajorGrid.Enabled = false;
            chartArea5.AxisX.MajorTickMark.Enabled = false;
            chartArea5.AxisX.Maximum = 1250D;
            chartArea5.AxisX.Minimum = 0D;
            chartArea5.AxisX.ScaleView.Zoomable = false;
            chartArea5.AxisX.ScrollBar.Enabled = false;
            chartArea5.AxisY.LabelStyle.Enabled = false;
            chartArea5.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea5.AxisY.MajorGrid.Enabled = false;
            chartArea5.AxisY.MajorTickMark.Enabled = false;
            chartArea5.Name = "ChartArea1";
            this.chart5.ChartAreas.Add(chartArea5);
            legend5.Enabled = false;
            legend5.Name = "Legend1";
            this.chart5.Legends.Add(legend5);
            this.chart5.Location = new System.Drawing.Point(3, 23);
            this.chart5.Name = "chart5";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series5.Color = System.Drawing.Color.ForestGreen;
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart5.Series.Add(series5);
            this.chart5.Size = new System.Drawing.Size(1100, 40);
            this.chart5.TabIndex = 32;
            this.chart5.Text = "chart5";
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.Controls.Add(this.checkBox5);
            this.flowLayoutPanel9.Controls.Add(this.chart6);
            this.flowLayoutPanel9.Location = new System.Drawing.Point(3, 333);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Size = new System.Drawing.Size(1120, 60);
            this.flowLayoutPanel9.TabIndex = 50;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(3, 3);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 40;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // chart6
            // 
            this.chart6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea6.AxisX.IsLabelAutoFit = false;
            chartArea6.AxisX.IsMarginVisible = false;
            chartArea6.AxisX.LabelStyle.Enabled = false;
            chartArea6.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea6.AxisX.MajorGrid.Enabled = false;
            chartArea6.AxisX.MajorTickMark.Enabled = false;
            chartArea6.AxisX.Maximum = 1250D;
            chartArea6.AxisX.Minimum = 0D;
            chartArea6.AxisX.ScaleView.Zoomable = false;
            chartArea6.AxisX.ScrollBar.Enabled = false;
            chartArea6.AxisY.LabelStyle.Enabled = false;
            chartArea6.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea6.AxisY.MajorGrid.Enabled = false;
            chartArea6.AxisY.MajorTickMark.Enabled = false;
            chartArea6.Name = "ChartArea1";
            this.chart6.ChartAreas.Add(chartArea6);
            legend6.Enabled = false;
            legend6.Name = "Legend1";
            this.chart6.Legends.Add(legend6);
            this.chart6.Location = new System.Drawing.Point(3, 23);
            this.chart6.Name = "chart6";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series6.Color = System.Drawing.Color.Gold;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chart6.Series.Add(series6);
            this.chart6.Size = new System.Drawing.Size(1100, 40);
            this.chart6.TabIndex = 33;
            this.chart6.Text = "chart6";
            // 
            // flowLayoutPanel10
            // 
            this.flowLayoutPanel10.Controls.Add(this.checkBox6);
            this.flowLayoutPanel10.Controls.Add(this.chart7);
            this.flowLayoutPanel10.Location = new System.Drawing.Point(3, 399);
            this.flowLayoutPanel10.Name = "flowLayoutPanel10";
            this.flowLayoutPanel10.Size = new System.Drawing.Size(1120, 60);
            this.flowLayoutPanel10.TabIndex = 51;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(3, 3);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 14);
            this.checkBox6.TabIndex = 41;
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // chart7
            // 
            this.chart7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea7.AxisX.IsLabelAutoFit = false;
            chartArea7.AxisX.IsMarginVisible = false;
            chartArea7.AxisX.LabelStyle.Enabled = false;
            chartArea7.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea7.AxisX.MajorGrid.Enabled = false;
            chartArea7.AxisX.MajorTickMark.Enabled = false;
            chartArea7.AxisX.Maximum = 1250D;
            chartArea7.AxisX.Minimum = 0D;
            chartArea7.AxisX.ScaleView.Zoomable = false;
            chartArea7.AxisX.ScrollBar.Enabled = false;
            chartArea7.AxisY.LabelStyle.Enabled = false;
            chartArea7.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea7.AxisY.MajorGrid.Enabled = false;
            chartArea7.AxisY.MajorTickMark.Enabled = false;
            chartArea7.Name = "ChartArea1";
            this.chart7.ChartAreas.Add(chartArea7);
            legend7.Enabled = false;
            legend7.Name = "Legend1";
            this.chart7.Legends.Add(legend7);
            this.chart7.Location = new System.Drawing.Point(3, 23);
            this.chart7.Name = "chart7";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series7.Color = System.Drawing.Color.Coral;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chart7.Series.Add(series7);
            this.chart7.Size = new System.Drawing.Size(1100, 40);
            this.chart7.TabIndex = 34;
            this.chart7.Text = "chart7";
            // 
            // flowLayoutPanel11
            // 
            this.flowLayoutPanel11.Controls.Add(this.checkBox7);
            this.flowLayoutPanel11.Controls.Add(this.chart8);
            this.flowLayoutPanel11.Location = new System.Drawing.Point(3, 465);
            this.flowLayoutPanel11.Name = "flowLayoutPanel11";
            this.flowLayoutPanel11.Size = new System.Drawing.Size(1120, 60);
            this.flowLayoutPanel11.TabIndex = 52;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(3, 3);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(15, 14);
            this.checkBox7.TabIndex = 42;
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // chart8
            // 
            this.chart8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea8.AxisX.IsLabelAutoFit = false;
            chartArea8.AxisX.IsMarginVisible = false;
            chartArea8.AxisX.LabelStyle.Enabled = false;
            chartArea8.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea8.AxisX.MajorGrid.Enabled = false;
            chartArea8.AxisX.MajorTickMark.Enabled = false;
            chartArea8.AxisX.Maximum = 1250D;
            chartArea8.AxisX.Minimum = 0D;
            chartArea8.AxisX.ScaleView.Zoomable = false;
            chartArea8.AxisX.ScrollBar.Enabled = false;
            chartArea8.AxisY.LabelStyle.Enabled = false;
            chartArea8.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea8.AxisY.MajorGrid.Enabled = false;
            chartArea8.AxisY.MajorTickMark.Enabled = false;
            chartArea8.Name = "ChartArea1";
            this.chart8.ChartAreas.Add(chartArea8);
            legend8.Enabled = false;
            legend8.Name = "Legend1";
            this.chart8.Legends.Add(legend8);
            this.chart8.Location = new System.Drawing.Point(3, 23);
            this.chart8.Name = "chart8";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series8.Color = System.Drawing.Color.OrangeRed;
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chart8.Series.Add(series8);
            this.chart8.Size = new System.Drawing.Size(1100, 40);
            this.chart8.TabIndex = 35;
            this.chart8.Text = "chart8";
            // 
            // flowLayoutPanel12
            // 
            this.flowLayoutPanel12.Controls.Add(this.checkBox8);
            this.flowLayoutPanel12.Controls.Add(this.chart9);
            this.flowLayoutPanel12.Location = new System.Drawing.Point(3, 531);
            this.flowLayoutPanel12.Name = "flowLayoutPanel12";
            this.flowLayoutPanel12.Size = new System.Drawing.Size(1120, 60);
            this.flowLayoutPanel12.TabIndex = 53;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(3, 3);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(15, 14);
            this.checkBox8.TabIndex = 43;
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // chart9
            // 
            this.chart9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea9.AxisX.IsLabelAutoFit = false;
            chartArea9.AxisX.IsMarginVisible = false;
            chartArea9.AxisX.LabelStyle.Enabled = false;
            chartArea9.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea9.AxisX.MajorGrid.Enabled = false;
            chartArea9.AxisX.MajorTickMark.Enabled = false;
            chartArea9.AxisX.Maximum = 1250D;
            chartArea9.AxisX.Minimum = 0D;
            chartArea9.AxisX.ScaleView.Zoomable = false;
            chartArea9.AxisX.ScrollBar.Enabled = false;
            chartArea9.AxisY.LabelStyle.Enabled = false;
            chartArea9.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea9.AxisY.MajorGrid.Enabled = false;
            chartArea9.AxisY.MajorTickMark.Enabled = false;
            chartArea9.Name = "ChartArea1";
            this.chart9.ChartAreas.Add(chartArea9);
            legend9.Enabled = false;
            legend9.Name = "Legend1";
            this.chart9.Legends.Add(legend9);
            this.chart9.Location = new System.Drawing.Point(3, 23);
            this.chart9.Name = "chart9";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series9.Color = System.Drawing.Color.Sienna;
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            this.chart9.Series.Add(series9);
            this.chart9.Size = new System.Drawing.Size(1100, 40);
            this.chart9.TabIndex = 36;
            this.chart9.Text = "chart9";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.groupBox4);
            this.flowLayoutPanel3.Controls.Add(this.groupBox5);
            this.flowLayoutPanel3.Controls.Add(this.groupBox2);
            this.flowLayoutPanel3.Controls.Add(this.groupBox3);
            this.flowLayoutPanel3.Controls.Add(this.groupBox1);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(1132, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(246, 591);
            this.flowLayoutPanel3.TabIndex = 30;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(226, 129);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Eye";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox8);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Location = new System.Drawing.Point(3, 138);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(226, 145);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Write to file";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textBox3);
            this.groupBox8.Location = new System.Drawing.Point(7, 91);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(219, 43);
            this.groupBox8.TabIndex = 23;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "File name";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(8, 18);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(203, 21);
            this.textBox3.TabIndex = 22;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox2);
            this.groupBox7.Location = new System.Drawing.Point(7, 44);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(219, 42);
            this.groupBox7.TabIndex = 23;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Path";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(7, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(205, 21);
            this.textBox2.TabIndex = 21;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(7, 18);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(87, 21);
            this.button5.TabIndex = 5;
            this.button5.Text = "Write to file";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(132, 18);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(87, 21);
            this.button6.TabIndex = 6;
            this.button6.Text = "Stop write";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radioButton7);
            this.groupBox2.Controls.Add(this.radioButton6);
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Location = new System.Drawing.Point(3, 289);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 56);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Notch filters";
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(7, 38);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(54, 16);
            this.radioButton7.TabIndex = 6;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "60 Hz";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(7, 18);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(54, 16);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "50 Hz";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(128, 18);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(51, 16);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "none";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.radioButton12);
            this.groupBox3.Controls.Add(this.radioButton11);
            this.groupBox3.Controls.Add(this.radioButton8);
            this.groupBox3.Controls.Add(this.radioButton9);
            this.groupBox3.Controls.Add(this.radioButton10);
            this.groupBox3.Location = new System.Drawing.Point(3, 351);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(226, 102);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filters";
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(7, 81);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(66, 16);
            this.radioButton12.TabIndex = 8;
            this.radioButton12.TabStop = true;
            this.radioButton12.Text = "5-50 Hz";
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(7, 60);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(72, 16);
            this.radioButton11.TabIndex = 7;
            this.radioButton11.TabStop = true;
            this.radioButton11.Text = "15-50 Hz";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(128, 18);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(51, 16);
            this.radioButton8.TabIndex = 6;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "none";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(7, 18);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(66, 16);
            this.radioButton9.TabIndex = 5;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "1-50 Hz";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(7, 39);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(66, 16);
            this.radioButton10.TabIndex = 4;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "7-13 Hz";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButton13);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(3, 459);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 121);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scale";
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.Location = new System.Drawing.Point(7, 102);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(102, 16);
            this.radioButton13.TabIndex = 4;
            this.radioButton13.TabStop = true;
            this.radioButton13.Text = "-100 to 100 uV";
            this.radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(7, 81);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(82, 16);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "-1 to 1 mV";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(7, 60);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(94, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "-10 to 10 mV";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 39);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(106, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "-100 to 100 mV";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "-1 to 1 V";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Offline.Properties.Resources.OpenedEye;
            this.pictureBox1.Location = new System.Drawing.Point(3, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "GraphForm";
            this.Size = new System.Drawing.Size(1381, 610);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            this.flowLayoutPanel8.ResumeLayout(false);
            this.flowLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart5)).EndInit();
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart6)).EndInit();
            this.flowLayoutPanel10.ResumeLayout(false);
            this.flowLayoutPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart7)).EndInit();
            this.flowLayoutPanel11.ResumeLayout(false);
            this.flowLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart8)).EndInit();
            this.flowLayoutPanel12.ResumeLayout(false);
            this.flowLayoutPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart9)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private FlowLayoutPanel flowLayoutPanel6;
        private CheckBox checkBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private FlowLayoutPanel flowLayoutPanel7;
        private CheckBox checkBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private FlowLayoutPanel flowLayoutPanel5;
        private CheckBox checkBox3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private FlowLayoutPanel flowLayoutPanel8;
        private CheckBox checkBox4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart5;
        private FlowLayoutPanel flowLayoutPanel9;
        private CheckBox checkBox5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart6;
        private FlowLayoutPanel flowLayoutPanel10;
        private CheckBox checkBox6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart7;
        private FlowLayoutPanel flowLayoutPanel11;
        private CheckBox checkBox7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart8;
        private FlowLayoutPanel flowLayoutPanel12;
        private CheckBox checkBox8;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart9;
        private FlowLayoutPanel flowLayoutPanel3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox8;
        private TextBox textBox3;
        private GroupBox groupBox7;
        private TextBox textBox2;
        private Button button5;
        private Button button6;
        private GroupBox groupBox2;
        private RadioButton radioButton7;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private GroupBox groupBox3;
        private RadioButton radioButton12;
        private RadioButton radioButton11;
        private RadioButton radioButton8;
        private RadioButton radioButton9;
        private RadioButton radioButton10;
        private GroupBox groupBox1;
        private RadioButton radioButton13;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private PictureBox pictureBox1;
    }
}

