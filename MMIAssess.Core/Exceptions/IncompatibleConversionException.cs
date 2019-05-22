using System;

namespace MMIAssess.Core.Exceptions
{
    public class IncompatibleConversionException : Exception
    {
        public IncompatibleConversionException()
        {

        }

        public IncompatibleConversionException(string type, string convertFrom, string convertTo)
            : base($"Cannot convert {convertFrom} to {convertTo} for conversion of type {type}")
        {

        }

    }
}