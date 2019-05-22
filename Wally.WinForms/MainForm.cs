using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Wally.Core;

namespace Wally.WinForms
{
    public partial class MainForm : Form
    {
        private static readonly string WeatherApiKey = ConfigurationManager.AppSettings["WeatherApiKey"];
        private static readonly string QuotaUsername = ConfigurationManager.AppSettings["QuotaUsername"];
        private static readonly string QuotaPassword = ConfigurationManager.AppSettings["QuotaPassword"];
        private static readonly string BudgetApiKey = ConfigurationManager.AppSettings["BudgetApiKey"];
        private static readonly string BudgetCategories = ConfigurationManager.AppSettings["BudgetCategories"];
        private static readonly string BrowserDocumentContent = ConfigurationManager.AppSettings["BrowserDocumentContent"];
        private static readonly string WeatherCoordinate = ConfigurationManager.AppSettings["WeatherCoordinate"];
        private static readonly string DaysUntilEvents = ConfigurationManager.AppSettings["DaysUntilEvents"];
        private readonly DataQuotaInfoGetter _dataQuotaInfoGetter = new DataQuotaInfoGetter();
        private readonly WeatherGetter _weatherGetter = new WeatherGetter(WeatherApiKey, new IconGetter());
        private readonly BackgroundWorker _netGraphBackgroundWorker = new BackgroundWorker();
        private readonly BudgetBalanceGetter _budgetBalanceGetter = new BudgetBalanceGetter(BudgetApiKey);
        private readonly ConfigAdapter _configAdapter = new ConfigAdapter();
        private readonly List<bool> _netResults = new List<bool>();
        private DateTime _internetLastDetected;
        private decimal _preDawnUsage = default(decimal);
        private readonly IReadOnlyCollection<BudgetApiCategory> _budgetApiCategories;
        private readonly WeatherCoordinate _weatherCoordinate;
        private int _daysUntilEventsIndex = 0;

        public MainForm()
        {
            InitializeComponent();
            var configs = new List<string> {WeatherApiKey, QuotaUsername, QuotaPassword, BudgetApiKey, BudgetCategories, WeatherCoordinate};
            if (configs.Any(string.IsNullOrWhiteSpace)) {
                throw new TypeInitializationException(GetType().Name, new Exception("Invalid configuration."));
            }
            _budgetApiCategories = _configAdapter.ToBudgetApiCategories(BudgetCategories);
            _weatherCoordinate = _configAdapter.ToWeatherCoordinate(WeatherCoordinate);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            UpdateChart();
            UpdateWeather();
            UpdateBalances();
            UpdateDaysUntil();
            timer30mins.Start();
            timer10mins.Start();
            timer5mins.Start();
            timer1sec.Start();
            _netGraphBackgroundWorker.DoWork += _netGraphBackgroundWorker_DoWork;
            _netGraphBackgroundWorker.RunWorkerAsync();
        }

        private async void UpdateBalances() {
            var categoryBalanceDisplays = new List<string>();
            foreach (var budgetApiCategory in _budgetApiCategories) {
                var balance = await _budgetBalanceGetter.Get(budgetApiCategory.BudgetId, budgetApiCategory.CategoryId);
                categoryBalanceDisplays.Add($"{budgetApiCategory.DisplayName}: ${balance}");
            }
            var balancesText = string.Join("; ", categoryBalanceDisplays);
            BalancesLabel.Text = balancesText;
        }

        private void _netGraphBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            while (DateTime.Now > DateTime.MinValue) {
                try {
                    using (var client = new ShortTimeWebClient()) {
                        using (client.OpenRead("http://clients3.google.com/generate_204")) {
                            _internetLastDetected = DateTime.Now;
                        }
                    }
                }
                catch (Exception exception) {
                    Logger.Error("Cannot reach internet...", exception);
                }

                Thread.Sleep(1000);
            }
        }

        private async void UpdateWeather() {
            Logger.Info("Updating weather...");
            var weather = await _weatherGetter.Get(_weatherCoordinate);
            var currentConditions = weather.CurrentConditions;
            var dailyForecasts = weather.DailyForecasts;
            var f1 = dailyForecasts.ElementAt(0);
            var f2 = dailyForecasts.ElementAt(1);
            var f3 = dailyForecasts.ElementAt(2);
            var f4 = dailyForecasts.ElementAt(3);
            NowLabel.Text = $"Now:{Math.Round(currentConditions.FahrenheitTemperature)}F {currentConditions.Description}";
            forecastUserControl1.LoadData($"{f1.When:ddd}", f1.MaximumFahrenheitTemperature, f1.MinimumFahrenheitTemperature, f1.IconBase64, f1.Summary);
            forecastUserControl2.LoadData($"{f2.When:ddd}", f2.MaximumFahrenheitTemperature, f2.MinimumFahrenheitTemperature, f2.IconBase64, f2.Summary);
            forecastUserControl3.LoadData($"{f3.When:ddd}", f3.MaximumFahrenheitTemperature, f3.MinimumFahrenheitTemperature, f3.IconBase64, f3.Summary);
            forecastUserControl4.LoadData($"{f4.When:ddd}", f4.MaximumFahrenheitTemperature, f4.MinimumFahrenheitTemperature, f4.IconBase64, f4.Summary);
            SetBrowserDocumentText(webBrowser1, BrowserDocumentContent.Replace("r=___", $"r={DateTime.Now.Ticks}"));
        }

        private void SetBrowserDocumentText(WebBrowser webBrowser, string documentText) {
            webBrowser.Navigate("about:blank");
            var doc = webBrowser.Document;
            if (doc != null) {
                doc.Write(string.Empty);
            }

            webBrowser.DocumentText = documentText;
        }

        private async void UpdateChart() {
            Logger.Info("Updating chart...");
            var quotaInfo = await _dataQuotaInfoGetter.GetCurrentMonth(QuotaUsername, QuotaPassword);
            if (quotaInfo.AllowableUsage != 0) {
                if (DateTime.Now.Hour >= 5 && DateTime.Now.Hour <= 6) {
                    _preDawnUsage = quotaInfo.TotalUsage;
                }
                var minutesInEveryDay = 60 * 24;
                var minuteOfTheMonth = (DateTime.Now.Day - 1) * minutesInEveryDay + DateTime.Now.Hour * 60 + DateTime.Now.Minute;
                var daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                var minutesInCurrentMonth = daysInCurrentMonth * minutesInEveryDay;
                var monthProgress = decimal.Divide(minuteOfTheMonth, minutesInCurrentMonth);
                var data = new List<QuotaMonth> {new QuotaMonth(DateTime.Now.ToString("MMMM"), $"{quotaInfo.TotalUsage}")};

                chart1.ChartAreas[0].AxisY.StripLines.Clear();

                var monthTargetUsage = (int)(quotaInfo.AllowableUsage * monthProgress);
                var targetUsage = (monthTargetUsage > quotaInfo.AllowableUsage * .9m ? (int)(quotaInfo.AllowableUsage * .9m) : monthTargetUsage);
                if (DateTime.Now.Day > 5) {
                    var monthTargetUsageStripline = new StripLine {
                        Interval = 0,
                        IntervalOffset = monthTargetUsage,
                        BorderWidth = 3,
                        BorderColor = Color.Black,
                        BorderDashStyle = ChartDashStyle.Dash,
                        Font = new Font(FontFamily.GenericMonospace, 24, FontStyle.Bold),
                        Text = $"{DateTime.Now:MMM}{Environment.NewLine}{DateTime.Now:dd}"
                    };
                    chart1.ChartAreas[0].AxisY.StripLines.Add(monthTargetUsageStripline);
                }

                var allowableUsageStripline = new StripLine {
                    Interval = 0,
                    IntervalOffset = Convert.ToDouble(quotaInfo.AllowableUsage),
                    StripWidth = 3,
                    BackColor = Color.Black,
                    StripWidthType = DateTimeIntervalType.Days,
                    Text = $"{quotaInfo.AllowableUsage}",
                    TextLineAlignment = StringAlignment.Far,
                    TextAlignment = StringAlignment.Near
                };
                chart1.ChartAreas[0].AxisY.StripLines.Add(allowableUsageStripline);

                chart1.DataSource = data;
                var series = chart1.Series.First();
                series.XValueMember = "MonthName";
                series.YValueMembers = "Usage";
                series.Label = $"{quotaInfo.TotalUsage}{(default(decimal).Equals(_preDawnUsage) ? string.Empty : $" ({Math.Ceiling(quotaInfo.TotalUsage - _preDawnUsage)} today)")}";
                series.LabelBackColor = Color.White;
                if (quotaInfo.TotalUsage < targetUsage * .90m) {
                    series.Color = Color.Green;
                } else if (quotaInfo.TotalUsage < targetUsage) {
                    series.Color = Color.Yellow;
                } else {
                    series.Color = Color.Red;
                }

                chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(quotaInfo.AllowableUsage) * 1.1;
                chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            }
        }

        private void UpdateNetgraph() {
            webBrowser2.Location = new Point(webBrowser2.Location.X, Height - webBrowser2.Height);
            webBrowser2.Width = Width + 5;
            _netResults.Add(DateTime.Now - _internetLastDetected < TimeSpan.FromSeconds(2));
            var spans = _netResults.Select(x => $@"<div style=""display:inline;background-color:{(x ? "green" : "red")};height:100px;"">&nbsp;</div>");
            SetBrowserDocumentText(webBrowser2, $@"<html><body style=""margin: 0; text-align: right;"">{string.Join(string.Empty, spans)}</body></html>");
            var netResultsToKeep = _netResults.Skip(Math.Max(0, _netResults.Count() - 360)).ToList();
            _netResults.Clear();
            _netResults.AddRange(netResultsToKeep);
        }

        public void UpdateDaysUntil()
        {
            var daysUntilEvents = _configAdapter.ToDaysUntilEvents(DaysUntilEvents).Where(x => x.DaysUntil <= x.DisplayCountInDays).ToList();
            if (daysUntilEvents.Any())
            {
                DaysRemainingLabel.Show();
                DaysUntilLabel.Show();
                EventNameLabel.Show();
                _daysUntilEventsIndex = _daysUntilEventsIndex >= daysUntilEvents.Count ? 0 : _daysUntilEventsIndex;
                var daysUntilEvent = daysUntilEvents[_daysUntilEventsIndex++];
                DaysRemainingLabel.Text = $"{daysUntilEvent.DaysUntil}";
                EventNameLabel.Text = daysUntilEvent.Name;
            }
            else
            {
                DaysRemainingLabel.Hide();
                DaysUntilLabel.Hide();
                EventNameLabel.Hide();
            }
        }

        private void timer30mins_Tick(object sender, EventArgs e) {
            UpdateChart();
        }

        private void timer10mins_Tick(object sender, EventArgs e) {
            UpdateWeather();
        }

        private void timer5mins_Tick(object sender, EventArgs e)
        {
            UpdateBalances();
            UpdateDaysUntil();
        }

        private void timer1sec_Tick(object sender, EventArgs e) {
            UpdateNetgraph();
        }
    }
}
