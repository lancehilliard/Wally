namespace Wally.Core {
    public class CurrentConditions {
        public CurrentConditions(decimal fahrenheitTemperature, string description) {
            FahrenheitTemperature = fahrenheitTemperature;
            Description = description;
        }
        public decimal FahrenheitTemperature { get; }
        public string Description { get; }
    }
}