using System;
using System.Collections.Generic;
using System.Text;
using MMIAssess.Core.Interfaces;

namespace MMIAssess.Core.Models.UnitsOfMeasure
{
    public class LitreUOM : UnitOfMeasure
    {
        public LitreUOM()
        {
            Description = "Litre";
            Symbol = "l";
        }

        public override IConversionResult ConvertTo(decimal value, IUnitOfMeasure toUnit)
        {
            var result = base.ConvertTo(value, toUnit);
            switch (toUnit.GetUnitDescription())
            {
                case "Gallon":
                    result.SetConvertedValue(value / (decimal)4.546);
                    break;
                default:
                    result.SetConvertedValue(value);
                    break;
            }
            return result;
        }
    }
}
