using MMIAssess.Core.Factories;
using MMIAssess.Core.Interfaces;

namespace MMIAssess.Core.Models
{
    public class ConversionRequest : IConversionRequest
    {
        private IConversion _conversion;
        private string _from;
        private string _to;
        private decimal _value;

        public ConversionRequest(string type, string from, string to, decimal value)
        {
            _from = from;
            _to = to;
            _value = value;

            _conversion = ConversionFactory.GetConversionOfType(type);
        }

        public IConversionResult Convert()
        {
            return _conversion.DoConversion(_from, _to, _value);
        }
    }
}
