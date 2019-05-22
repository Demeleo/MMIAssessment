using MMIAssess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMIAssess.Core.Models.UnitsOfMeasure
{
    public class KelvinUOM : UnitOfMeasure
    {
        public KelvinUOM()
        {
            Description = "Kelvin";
            Symbol = "K";
        }

        public override IConversionResult ConvertTo(decimal value, IUnitOfMeasure toUnit)
        {
            var result = base.ConvertTo(value, toUnit);
            switch (toUnit.GetUnitDescription())
            {
                case "Fahrenheit":
                    result.SetConvertedValue((value - (decimal)273.15) * (9 / 5) + 32);
                    break;
                case "Celsius":
                    result.SetConvertedValue(value - (decimal)273.15);
                    break;
                default:
                    result.SetConvertedValue(value);
                    break;
            }
            return result;
        }
    }
}
