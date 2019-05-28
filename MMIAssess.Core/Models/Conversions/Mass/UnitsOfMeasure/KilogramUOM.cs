using System;
using System.Collections.Generic;
using System.Text;
using MMIAssess.Core.Interfaces;

namespace MMIAssess.Core.Models.UnitsOfMeasure
{
    public class KilogramUOM : UnitOfMeasure
    {
        public KilogramUOM()
        {
            Description = "Kilogram";
            Symbol = "kg";
        }

        public override IConversionResult ConvertTo(decimal value, IUnitOfMeasure toUnit)
        {
            var result = base.ConvertTo(value, toUnit);
            switch (toUnit.GetUnitDescription())
            {
                case "Pound":
                    result.SetConvertedValue(value * (decimal)2.205);
                    break;
                default:
                    result.SetConvertedValue(value);
                    break;
            }
            return result;
        }
    }
}
