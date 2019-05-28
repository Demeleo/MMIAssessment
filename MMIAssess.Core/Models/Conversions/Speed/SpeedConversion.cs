
using MMIAssess.Core.Models.UnitsOfMeasure;

namespace MMIAssess.Core.Models.Conversions
{
    public class SpeedConversion : Conversion
    {
        public SpeedConversion()
        {
            Type = Shared.ConversionType.Speed;
            AddUnits(new KmphUOM { Type = this.Type});
            AddUnits(new MphUOM { Type = this.Type});
        }
    }
}
