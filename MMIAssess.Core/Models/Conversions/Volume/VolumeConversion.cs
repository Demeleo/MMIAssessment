
using MMIAssess.Core.Models.UnitsOfMeasure;

namespace MMIAssess.Core.Models.Conversions
{
    public class VolumeConversion : Conversion
    {
        public VolumeConversion()
        {
            Type = Shared.ConversionType.Volume;
            AddUnits(new LitreUOM { Type = this.Type});
            AddUnits(new GallonUOM { Type = this.Type});
        }
    }
}
