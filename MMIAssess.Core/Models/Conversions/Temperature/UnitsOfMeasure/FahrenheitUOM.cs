using MMIAssess.Core.Interfaces;

namespace MMIAssess.Core.Models.UnitsOfMeasure
{
    public class FahrenheitUOM: UnitOfMeasure
    {
        public FahrenheitUOM()
        {
            Description = "Fahrenheit";
            Symbol = "°F";
        }

        public override IConversionResult ConvertTo(decimal value, IUnitOfMeasure toUnit)
        {
            var result = base.ConvertTo(value, toUnit);
            switch (toUnit.GetUnitDescription())
            {
                case "Kelvin":
                    result.SetConvertedValue((value - 32) * (5 / 9) + (decimal)273.15);
                    break;
                case "Celsius":
                    result.SetConvertedValue((value - 32) * (5 / 9));
                    break;
                default:
                    result.SetConvertedValue(value);
                    break;
            }
            return result;
        }
    }
}
