using System;
using System.Collections.Generic;
using System.Text;
using MMIAssess.Core.Interfaces;

namespace MMIAssess.Core.Models.UnitsOfMeasure
{
    public class KilometerUOM : UnitOfMeasure
    {
        public KilometerUOM()
        {
            Description = "Kilometer";
            Symbol = "km";
        }

        public override IConversionResult ConvertTo(decimal value, IUnitOfMeasure toUnit)
        {
            var result = base.ConvertTo(value, toUnit);
            switch (toUnit.GetUnitDescription())
            {
                case "Mile":
                    result.SetConvertedValue(value / (decimal)1.609);
                    break;
                default:
                    result.SetConvertedValue(value);
                    break;
            }
            return result;
        }
    }
}
