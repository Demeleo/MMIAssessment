
using MMIAssess.Core.Models.UnitsOfMeasure;

namespace MMIAssess.Core.Models.Conversions
{
    public class LengthConversion: Conversion
    {
        public LengthConversion()
        {
            Type = Shared.ConversionType.Length;
            AddUnits(new KilometerUOM { Type = this.Type});
            AddUnits(new MileUOM { Type = this.Type});
        }
    }
}
