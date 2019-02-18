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
            var driverAction = page.DriverAction?.Invoke(_driver);
            driverAction?.Invoke();
            var scriptFilepath = $"{page.VoiceCommandWord}.js";
            if (File.Exists(scriptFilepath)) {
                var script = GetWallyfiedScript(scriptFilepath);
                _driver.ExecuteScript(script);
            }
            var scriptAfterFilepath = $"{page.VoiceCommandWord}.after.js";
            if (File.Exists(scriptAfterFilepath)) {
                var script = GetWallyfiedScript(scriptAfterFilepath);
                _driver.ExecuteScript(script);
            }
            _pingPlotterWindowStateChanger.Minimize();
            tab.UpdateLastShownMoment();
        }

        string GetWallyfiedScript(string filepath) {
            var result = $"{File.ReadAllText("wally.js")}{File.ReadAllText(filepath)}";
            return result;
        }
    }
}