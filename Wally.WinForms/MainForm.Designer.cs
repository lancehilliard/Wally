namespace Wally.WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

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
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer30mins = new System.Windows.Forms.Timer(this.components);
            this.NowLabel = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.timer10mins = new System.Windows.Forms.Timer(this.components);
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.timer1sec = new System.Windows.Forms.Timer(this.components);
            this.timer5mins = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.BalancesLabel = new System.Windows.Forms.Label();
            this.DaysRemainingLabel = new System.Windows.Forms.Label();
            this.DaysUntilLabel = new System.Windows.Forms.Label();
            this.EventNameLabel = new System.Windows.Forms.Label();
            this.forecastUserControl1 = new Wally.WinForms.ForecastUserControl();
            this.forecastUserControl2 = new Wally.WinForms.ForecastUserControl();
            this.forecastUserControl3 = new Wally.WinForms.ForecastUserControl();
            this.forecastUserControl4 = new Wally.WinForms.ForecastUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(919, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(446, 588);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // timer30mins
            // 
            this.timer30mins.Interval = 1800000;
            this.timer30mins.Tick += new System.EventHandler(this.timer30mins_Tick);
            // 
            // NowLabel
            // 
            this.NowLabel.AutoSize = true;
            this.NowLabel.Font = new System.Drawing.Font("Courier New", 48F);
            this.NowLabel.Location = new System.Drawing.Point(-1, -1);
            this.NowLabel.Name = "NowLabel";
            this.NowLabel.Size = new System.Drawing.Size(600, 69);
            this.NowLabel.TabIndex = 2;
            this.NowLabel.Text = "Now: 99F Cloudy";
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(980, 558);
            this.webBrowser1.TabIndex = 3;
            this.webBrowser1.TabStop = false;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // timer10mins
            // 
            this.timer10mins.Interval = 600000;
            this.timer10mins.Tick += new System.EventHandler(this.timer10mins_Tick);
            // 
            // webBrowser2
            // 
            this.webBrowser2.AllowWebBrowserDrop = false;
            this.webBrowser2.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser2.Location = new System.Drawing.Point(-5, 732);
            this.webBrowser2.Margin = new System.Windows.Forms.Padding(0);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.ScriptErrorsSuppressed = true;
            this.webBrowser2.ScrollBarsEnabled = false;
            this.webBrowser2.Size = new System.Drawing.Size(1366, 40);
            this.webBrowser2.TabIndex = 8;
            // 
            // timer1sec
            // 
            this.timer1sec.Interval = 1000;
            this.timer1sec.Tick += new System.EventHandler(this.timer1sec_Tick);
            // 
            // timer5mins
            // 
            this.timer5mins.Interval = 300000;
            this.timer5mins.Tick += new System.EventHandler(this.timer5mins_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.BalancesLabel);
            this.panel1.Location = new System.Drawing.Point(1166, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(200, 20);
            this.panel1.TabIndex = 11;
            // 
            // BalancesLabel
            // 
            this.BalancesLabel.BackColor = System.Drawing.Color.White;
            this.BalancesLabel.Location = new System.Drawing.Point(0, 0);
            this.BalancesLabel.Name = "BalancesLabel";
            this.BalancesLabel.Size = new System.Drawing.Size(200, 13);
            this.BalancesLabel.TabIndex = 0;
            this.BalancesLabel.Text = "Evan: $42.00; Quinn: $86.00";
            // 
            // DaysRemainingLabel
            // 
            this.DaysRemainingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DaysRemainingLabel.Location = new System.Drawing.Point(987, 562);
            this.DaysRemainingLabel.Name = "DaysRemainingLabel";
            this.DaysRemainingLabel.Size = new System.Drawing.Size(206, 95);
            this.DaysRemainingLabel.TabIndex = 12;
            this.DaysRemainingLabel.Text = "99";
            this.DaysRemainingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DaysUntilLabel
            // 
            this.DaysUntilLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DaysUntilLabel.Location = new System.Drawing.Point(988, 656);
            this.DaysUntilLabel.Name = "DaysUntilLabel";
            this.DaysUntilLabel.Size = new System.Drawing.Size(195, 23);
            this.DaysUntilLabel.TabIndex = 13;
            this.DaysUntilLabel.Text = "DAYS UNTIL";
            this.DaysUntilLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EventNameLabel
            // 
            this.EventNameLabel.AutoSize = true;
            this.EventNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventNameLabel.Location = new System.Drawing.Point(1005, 683);
            this.EventNameLabel.Name = "EventNameLabel";
            this.EventNameLabel.Size = new System.Drawing.Size(339, 39);
            this.EventNameLabel.TabIndex = 14;
            this.EventNameLabel.Text = "The Really Big Event";
            // 
            // forecastUserControl1
            // 
            this.forecastUserControl1.Location = new System.Drawing.Point(14, 559);
            this.forecastUserControl1.Name = "forecastUserControl1";
            this.forecastUserControl1.Size = new System.Drawing.Size(236, 240);
            this.forecastUserControl1.TabIndex = 4;
            // 
            // forecastUserControl2
            // 
            this.forecastUserControl2.Location = new System.Drawing.Point(257, 559);
            this.forecastUserControl2.Name = "forecastUserControl2";
            this.forecastUserControl2.Size = new System.Drawing.Size(236, 240);
            this.forecastUserControl2.TabIndex = 5;
            // 
            // forecastUserControl3
            // 
            this.forecastUserControl3.Location = new System.Drawing.Point(501, 559);
            this.forecastUserControl3.Name = "forecastUserControl3";
            this.forecastUserControl3.Size = new System.Drawing.Size(236, 240);
            this.forecastUserControl3.TabIndex = 6;
            // 
            // forecastUserControl4
            // 
            this.forecastUserControl4.Location = new System.Drawing.Point(744, 559);
            this.forecastUserControl4.Name = "forecastUserControl4";
            this.forecastUserControl4.Size = new System.Drawing.Size(236, 240);
            this.forecastUserControl4.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.EventNameLabel);
            this.Controls.Add(this.DaysUntilLabel);
            this.Controls.Add(this.DaysRemainingLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webBrowser2);
            this.Controls.Add(this.forecastUserControl1);
            this.Controls.Add(this.forecastUserControl2);
            this.Controls.Add(this.forecastUserControl3);
            this.Controls.Add(this.forecastUserControl4);
            this.Controls.Add(this.NowLabel);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.chart1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer30mins;
        private System.Windows.Forms.Label NowLabel;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private ForecastUserControl forecastUserControl1;
        private ForecastUserControl forecastUserControl2;
        private ForecastUserControl forecastUserControl3;
        private ForecastUserControl forecastUserControl4;
        private System.Windows.Forms.Timer timer10mins;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.Timer timer1sec;
        private System.Windows.Forms.Timer timer5mins;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label BalancesLabel;
        private System.Windows.Forms.Label DaysRemainingLabel;
        private System.Windows.Forms.Label DaysUntilLabel;
        private System.Windows.Forms.Label EventNameLabel;
    }
}