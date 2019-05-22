using MMIAssess.Core.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMIAssess.Core.Interfaces
{
    public interface IUnitOfMeasure
    {
        ConversionType GetUnitConversionType();
        string GetUnitDescription();
        string GetSymbol();
        IConversionResult ConvertTo(decimal value, IUnitOfMeasure toUnit);
    }
}
