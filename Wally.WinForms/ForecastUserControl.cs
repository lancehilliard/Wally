using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Wally.WinForms
{
    public partial class ForecastUserControl : UserControl
    {
        public ForecastUserControl()
        {
            InitializeComponent();
        }

        public void LoadData(string dayName, decimal maxTemp, decimal minTemp, string iconBase64, string summary) {
            DayLabel.Text = dayName;
            MaxTempLabel.Text = $"{Math.Round(maxTemp)}";
            MinTempLabel.Text = $"{Math.Round(minTemp)}";

            Image iconPicture = null;
            if (!string.IsNullOrWhiteSpace(iconBase64)) {
                var iconPic = Convert.FromBase64String(iconBase64);
                using (var ms = new MemoryStream(iconPic)) {
                    iconPicture = Image.FromStream(ms);
                }
            }
            panel1.BackgroundImage = iconPicture;
            MaxTempLabel.Parent = panel1;
            MaxTempLabel.Location = new Point(0,0);
            MaxTempLabel.BackColor = Color.Transparent;
            MinTempLabel.Parent = panel1;
            MinTempLabel.Location = new Point(panel1.Width-MinTempLabel.Width,panel1.Height-MinTempLabel.Height);
            MinTempLabel.BackColor = Color.Transparent;
        }
    }
}
