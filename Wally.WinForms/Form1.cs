using System;
using System.Linq;
using System.Windows.Forms;
using Wally.Core;

namespace Wally.WinForms
{
    public partial class Form1 : Form
    {
        delegate void WriteMessageCallback(string text);
        public Form1() {
            InitializeComponent();
            Logger.SetMessageWriter(WriteMessage);
            void WriteMessage(string message) {
                var oldText = string.Join(Environment.NewLine, textBox1.Text.Split(Environment.NewLine.ToCharArray()).Take(50));
                message = $"{message}{Environment.NewLine}{oldText}";
                if (textBox1.InvokeRequired) { // https://stackoverflow.com/a/10775421/116895
                    WriteMessageCallback d = WriteMessage;
                    Invoke(d, message);
                } else {
                    textBox1.Text = message;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            try {
                var quotaForm = new MainForm();
                Present(quotaForm);
                WindowState = FormWindowState.Maximized;
                WindowState = FormWindowState.Minimized;
                Logger.Info($"{GetType().Name} loaded.");
            }
            catch (Exception exception) {
                Logger.Error($"Unable to present form...", exception);
            }
        }

        void Present(Form form) {
            form.Show();
            form.FormBorderStyle = FormBorderStyle.None;
            form.WindowState = FormWindowState.Maximized;
            form.Activate();
            form.Closed += (sender, args) => { Application.Exit(); };
        }
    }
}
