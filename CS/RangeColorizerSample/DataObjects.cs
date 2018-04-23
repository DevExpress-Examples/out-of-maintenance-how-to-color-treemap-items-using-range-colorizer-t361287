using System.Collections.Generic;

namespace RangeColorizerSample {
    public class EnergyInfo {
        public string Type { get; set; }
        public double Value { get; set; }
    }

    public class CountryStatistics {
        public string Name { get; set; }

        List<EnergyInfo> energyStatistics = new List<EnergyInfo>();
        public List<EnergyInfo> EnergyStatistics { get { return energyStatistics; } }
    }
}
