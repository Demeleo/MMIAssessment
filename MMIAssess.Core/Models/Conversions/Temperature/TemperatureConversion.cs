
using MMIAssess.Core.Models.UnitsOfMeasure;

namespace MMIAssess.Core.Models.Conversions
{
    public class TemperatureConversion: Conversion
    {
        public TemperatureConversion()
        {
            Type = Shared.ConversionType.Temperature;
            AddUnits(new KelvinUOM { Type = this.Type});
            AddUnits(new FahrenheitUOM { Type = this.Type});
            AddUnits(new CelciusUOM { Type = this.Type });
        }
    }
}
