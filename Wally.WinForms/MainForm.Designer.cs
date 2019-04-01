﻿namespace Wally.WinForms
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer30mins = new System.Windows.Forms.Timer(this.components);
            this.NowLabel = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.timer10mins = new System.Windows.Forms.Timer(this.components);
            this.forecastUserControl1 = new Wally.WinForms.ForecastUserControl();
            this.forecastUserControl2 = new Wally.WinForms.ForecastUserControl();
            this.forecastUserControl3 = new Wally.WinForms.ForecastUserControl();
            this.forecastUserControl4 = new Wally.WinForms.ForecastUserControl();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.timer1sec = new System.Windows.Forms.Timer(this.components);
            this.timer5mins = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.BalancesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea10.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.chart1.Legends.Add(legend10);
            this.chart1.Location = new System.Drawing.Point(919, 0);
            this.chart1.Name = "chart1";
            series10.ChartArea = "ChartArea1";
            series10.IsValueShownAsLabel = true;
            series10.IsVisibleInLegend = false;
            series10.Legend = "Legend1";
            series10.Name = "Series1";
            this.chart1.Series.Add(series10);
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
            this.webBrowser1.Location = new System.Drawing.Point(-200, -57);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(1180, 615);
            this.webBrowser1.TabIndex = 3;
            this.webBrowser1.TabStop = false;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // timer10mins
            // 
            this.timer10mins.Interval = 600000;
            this.timer10mins.Tick += new System.EventHandler(this.timer10mins_Tick);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 730);
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

    }
}