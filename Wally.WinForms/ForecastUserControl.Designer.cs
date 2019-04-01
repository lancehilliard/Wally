namespace Wally.WinForms
{
    partial class ForecastUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DayLabel = new System.Windows.Forms.Label();
            this.MaxTempLabel = new System.Windows.Forms.Label();
            this.MinTempLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DayLabel
            // 
            this.DayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayLabel.Location = new System.Drawing.Point(0, -8);
            this.DayLabel.Name = "DayLabel";
            this.DayLabel.Size = new System.Drawing.Size(236, 59);
            this.DayLabel.TabIndex = 0;
            this.DayLabel.Text = "Day";
            this.DayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MaxTempLabel
            // 
            this.MaxTempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxTempLabel.Location = new System.Drawing.Point(9, 10);
            this.MaxTempLabel.Margin = new System.Windows.Forms.Padding(0);
            this.MaxTempLabel.Name = "MaxTempLabel";
            this.MaxTempLabel.Size = new System.Drawing.Size(90, 50);
            this.MaxTempLabel.TabIndex = 4;
            this.MaxTempLabel.Text = "75";
            this.MaxTempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MinTempLabel
            // 
            this.MinTempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinTempLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.MinTempLabel.Location = new System.Drawing.Point(141, 70);
            this.MinTempLabel.Name = "MinTempLabel";
            this.MinTempLabel.Size = new System.Drawing.Size(90, 50);
            this.MinTempLabel.TabIndex = 6;
            this.MinTempLabel.Text = "42";
            this.MinTempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.MaxTempLabel);
            this.panel1.Controls.Add(this.MinTempLabel);
            this.panel1.Location = new System.Drawing.Point(1, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 130);
            this.panel1.TabIndex = 7;
            // 
            // ForecastUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DayLabel);
            this.Name = "ForecastUserControl";
            this.Size = new System.Drawing.Size(240, 172);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label DayLabel;
        private System.Windows.Forms.Label MaxTempLabel;
        private System.Windows.Forms.Label MinTempLabel;
        private System.Windows.Forms.Panel panel1;
    }
}
