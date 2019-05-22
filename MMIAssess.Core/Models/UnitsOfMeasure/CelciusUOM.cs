using System;
using System.Collections.Generic;
using System.Text;
using MMIAssess.Core.Interfaces;

namespace MMIAssess.Core.Models.UnitsOfMeasure
{
    public class CelciusUOM : UnitOfMeasure
    {
        public CelciusUOM()
        {
            Description = "Celsius";
            Symbol = "°C";
        }

        public override IConversionResult ConvertTo(decimal value, IUnitOfMeasure toUnit)
        {
            var result = base.ConvertTo(value, toUnit);
            switch (toUnit.GetUnitDescription())
            {
                case "Kelvin":
                    result.SetConvertedValue(value + (decimal)273.15);
                    break;
                case "Fahrenheit":
                    result.SetConvertedValue((value * (9 / 5)) + 32);
                    break;
                default:
                    result.SetConvertedValue(value);
                    break;
            }
            return result;
        }
    }
}
