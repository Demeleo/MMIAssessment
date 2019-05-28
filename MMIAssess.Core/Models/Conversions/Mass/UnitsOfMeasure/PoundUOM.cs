using MMIAssess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMIAssess.Core.Models.UnitsOfMeasure
{
    public class PoundUOM : UnitOfMeasure
    {
        public PoundUOM()
        {
            Description = "Pound";
            Symbol = "lb";
        }

        public override IConversionResult ConvertTo(decimal value, IUnitOfMeasure toUnit)
        {
            var result = base.ConvertTo(value, toUnit);
            switch (toUnit.GetUnitDescription())
            {
                case "Kilogram":
                    result.SetConvertedValue(value / (decimal)2.205);
                    break;
                default:
                    result.SetConvertedValue(value);
                    break;
            }
            return result;
        }
    }
}
