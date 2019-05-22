using MMIAssess.Core.Interfaces;

namespace MMIAssess.Core.Models
{
    public class ConversionResult: IConversionResult
    {
        public string FromDescription { get; set; }
        public string ToDescription { get; set; }
        public string FromSymbol { get; set; }
        public string ToSymbol { get; set; }
        public decimal FromValue { get; set; }
        public decimal ConvertedResult { get; set; }

        public ConversionResult(IUnitOfMeasure fromUnit, IUnitOfMeasure toUnit, decimal fromValue, decimal conversionResult)
        {
            FromDescription = fromUnit.GetUnitDescription();
            ToDescription = toUnit.GetUnitDescription();
            FromSymbol = fromUnit.GetSymbol();
            ToSymbol = toUnit.GetSymbol();
            FromValue = fromValue;
            ConvertedResult = conversionResult;
        }

        public void SetConvertedValue(decimal value)
        {
            this.ConvertedResult = value;
        }
    }
}
