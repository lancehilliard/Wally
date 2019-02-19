using System;
using System.IO;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace Wally.Tour {
    public class TabLoader {
        private readonly PingPlotterWindowStateChanger _pingPlotterWindowStateChanger;
        private readonly ChromeDriver _driver;
        public TabLoader(ChromeDriver driver, PingPlotterWindowStateChanger pingPlotterWindowStateChanger) {
            _driver = driver;
            _pingPlotterWindowStateChanger = pingPlotterWindowStateChanger;
        }

        public void Load(Tab tab, Page page) {
            _pingPlotterWindowStateChanger.Maximize();
            _driver.Navigate().GoToUrl(page.Url);
            _driver.Navigate().Refresh();
            Thread.Sleep(TimeSpan.FromSeconds(page.SecondsToWaitForPageLoad));
            ExecuteScriptIfExists($"{page.VoiceCommandWord}.js");
            ExecuteScriptIfExists($"{page.VoiceCommandWord}.after.js");
            _pingPlotterWindowStateChanger.Minimize();
            tab.UpdateLastShownMoment();
        }

        string GetWallyfiedScript(string filepath) {
            var result = $"{File.ReadAllText("wally.js")}{Environment.NewLine}{File.ReadAllText(filepath)}";
            return result;
        }

        void ExecuteScriptIfExists(string filepath) {
            if (File.Exists(filepath)) {
                var script = GetWallyfiedScript(filepath);
                _driver.ExecuteScript(script);
            }
        }
    }
}