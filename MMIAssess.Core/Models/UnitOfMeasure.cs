using MMIAssess.Core.Interfaces;
using MMIAssess.Core.Shared;

namespace MMIAssess.Core.Models
{
    public class UnitOfMeasure : IUnitOfMeasure
    {
        public ConversionType Type { get; set; }
        public string Description { get; set; }
        public string Symbol { get; set; }

        public virtual IConversionResult ConvertTo(decimal value, IUnitOfMeasure toUnit)
        {
            var conversionResult = new ConversionResult(Type, this, toUnit, value, 0);
            return conversionResult;
        }

        public string GetSymbol()
        {
            return Symbol;
        }

        public ConversionType GetUnitConversionType()
        {
            return Type;
        }

        public string GetUnitDescription()
        {
            return Description;
        }
    }
}
