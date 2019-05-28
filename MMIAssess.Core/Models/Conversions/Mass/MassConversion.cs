
using MMIAssess.Core.Models.UnitsOfMeasure;

namespace MMIAssess.Core.Models.Conversions
{
    public class MassConversion : Conversion
    {
        public MassConversion()
        {
            Type = Shared.ConversionType.Mass;
            AddUnits(new KilogramUOM { Type = this.Type});
            AddUnits(new PoundUOM { Type = this.Type});
        }
    }
}
