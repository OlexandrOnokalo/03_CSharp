namespace _04_IntroToOOP
{
    
    public partial class Freezer
    {
        
        private string brand;
        private int volume;
        private bool hasNoFrost;
        private double minTemperature;
        private int powerConsumption;

        
        public static int TotalCreated;
        public static int DefaultWarrantyYears;

        
        static Freezer()
        {
            TotalCreated = 0;
            DefaultWarrantyYears = 2;
        }

        
        public Freezer() : this("Unknown", 200, false, -18.0, 100) { }

        
        public Freezer(string brand, int volume) : this(brand, volume, false, -18.0, 100) { }

        
        public Freezer(string brand, int volume, bool hasNoFrost, double minTemperature, int powerConsumption)
        {
            this.brand = brand;
            this.volume = volume;
            this.hasNoFrost = hasNoFrost;
            this.minTemperature = minTemperature;
            this.powerConsumption = powerConsumption;

            TotalCreated++;
        }

        
        public override string ToString()
        {
            return $"Brand: {brand}\n" +
                   $"Volume: {volume} L\n" +
                   $"No Frost: {(hasNoFrost ? "Yes" : "No")}\n" +
                   $"Min Temperature: {minTemperature}°C\n" +
                   $"Power Consumption: {powerConsumption} kWh/year";
        }
    }
}
