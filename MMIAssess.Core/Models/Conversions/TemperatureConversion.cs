
using MMIAssess.Core.Interfaces;
using MMIAssess.Core.Models.UnitsOfMeasure;

namespace MMIAssess.Core.Models.Conversions
{
    public class TemperatureConversion: Conversion
    {
        public TemperatureConversion()
        {
            Type = Shared.ConversionType.Temperature;
            AddUnits(new KelvinUOM { Type = this.Type, Value = 0});
            AddUnits(new FahrenheitUOM { Type = this.Type, Value = 0 });
            AddUnits(new CelciusUOM { Type = this.Type, Value = 0 });
        }

        public override IConversionResult DoConversion(IUnitOfMeasure fromUnit, IUnitOfMeasure toUnit, decimal value)
        {
            base.DoConversion(fromUnit, toUnit, value);
            return fromUnit.ConvertTo(value, toUnit);
        }
    }
}
