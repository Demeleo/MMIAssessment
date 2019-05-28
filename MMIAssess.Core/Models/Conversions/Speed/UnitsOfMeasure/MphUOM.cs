using MMIAssess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMIAssess.Core.Models.UnitsOfMeasure
{
    public class MphUOM : UnitOfMeasure
    {
        public MphUOM()
        {
            Description = "Mph";
            Symbol = "mph";
        }

        public override IConversionResult ConvertTo(decimal value, IUnitOfMeasure toUnit)
        {
            var result = base.ConvertTo(value, toUnit);
            switch (toUnit.GetUnitDescription())
            {
                case "Kmph":
                    result.SetConvertedValue(value * (decimal)1.609);
                    break;
                default:
                    result.SetConvertedValue(value);
                    break;
            }
            return result;
        }
    }
}
