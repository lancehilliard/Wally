using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Threading;
using OpenQA.Selenium.Chrome;
using Wally.Tour;

namespace Wally.ConsoleApp {
    internal static class Program {
        private static ConsoleEventDelegate _handler;
        private static readonly int CtrlCloseEvent = 2;

        private static TourGuide _tourGuide;
        private static ChromeDriver _driver;

        private static void Main() {
            _handler = ConsoleEventCallback;
            SetConsoleCtrlHandler(_handler, true);
            var chromeDriverTerminator = new ChromeDriverTerminator();
            var chromeDriverCreator = new ChromeDriverCreator();
            var internetConnectionChecker = new InternetConnectionChecker();
            var speechRecognitionEngine = new SpeechRecognitionEngine(SpeechRecognitionEngine.InstalledRecognizers().First(x => x.Culture.ToString() == "en-US"));
            var voiceListener = new VoiceListener(speechRecognitionEngine);
            chromeDriverTerminator.TerminateAll();
            _driver = chromeDriverCreator.Create(ConfigurationManager.AppSettings["ChromeUserDataDirectory"]);
            var pingPlotterWindowStateChanger = new PingPlotterWindowStateChanger(new WindowStateChanger());
            var tabLoader = new TabLoader(_driver, pingPlotterWindowStateChanger);
            var pageInitializer = new PageInitializer(_driver);
            var tabSwitcher = new TabSwitcher(voiceListener, _driver);
            _tourGuide = new TourGuide(internetConnectionChecker, tabLoader, pageInitializer, pingPlotterWindowStateChanger, tabSwitcher);
            var pagesGetter = new PagesGetter();
            var pages = pagesGetter.Get();
            if (Debugger.IsAttached) {
                pages = pages.Where(x => "quota".Equals(x.VoiceCommandWord)).ToList();
            }
            try {
                _tourGuide.Guide(pages, _driver, OnLoadingPage, OnShowingPage, OnInitializingPage, OnExpired, OnError);

                void OnInitializingPage(int pageNumber, Page page) {
                    OnVerbingPage(pageNumber, page, "Initializing");
                }

                void OnLoadingPage(int pageNumber, Page page) {
                    OnVerbingPage(pageNumber, page, "Loading");
                }

                void OnShowingPage(int pageNumber, Page page) {
                    OnVerbingPage(pageNumber, page, "Showing");
                }

                void OnVerbingPage(int pageNumber, Page page, string verb) {
                    Console.WriteLine($"{DateTime.Now}: {verb} ({pageNumber}/{pages.Count}): '{page.Url}'");
                }

                void OnExpired(Page page) {
                    Console.WriteLine($"{DateTime.Now}: Expired: '{page.Url}'");
                }

                void OnError(Page page, Exception exception) {
                    Console.WriteLine($"ERROR - {DateTime.Now}: {exception}");
                    Thread.Sleep(5000);
                }
            }
            catch (Exception e) {
                Console.WriteLine($"Program {DateTime.Now}: {e}");
                Thread.Sleep(20000);
                ConsoleEventCallback(CtrlCloseEvent);
                Environment.Exit(1);
            }
        }

        private static bool ConsoleEventCallback(int eventType) {
            if (eventType == CtrlCloseEvent) {
                _driver?.Quit();
            }

            return false;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
        private delegate bool ConsoleEventDelegate(int eventType);
    }
}