using System;

namespace MMIAssess.Core.Exceptions
{
    public class ConversionNotFoundException : Exception
    {
        public ConversionNotFoundException()
        {

        }

        public ConversionNotFoundException(string type)
            : base($"CConversion of type {type} is not found.")
        {

        }

    }
}