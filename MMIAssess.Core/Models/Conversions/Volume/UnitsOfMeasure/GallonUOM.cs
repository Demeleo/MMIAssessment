using MMIAssess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMIAssess.Core.Models.UnitsOfMeasure
{
    public class GallonUOM : UnitOfMeasure
    {
        public GallonUOM()
        {
            Description = "Gallon";
            Symbol = "gal";
        }

        public override IConversionResult ConvertTo(decimal value, IUnitOfMeasure toUnit)
        {
            var result = base.ConvertTo(value, toUnit);
            switch (toUnit.GetUnitDescription())
            {
                case "Litre":
                    result.SetConvertedValue(value * (decimal)4.546);
                    break;
                default:
                    result.SetConvertedValue(value);
                    break;
            }
            return result;
        }
    }
}
