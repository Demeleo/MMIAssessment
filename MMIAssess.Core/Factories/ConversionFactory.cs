using MMIAssess.Core.Exceptions;
using MMIAssess.Core.Interfaces;
using MMIAssess.Core.Models.Conversions;
using MMIAssess.Core.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMIAssess.Core.Factories
{
    public static class ConversionFactory
    {
        public static IConversion GetConversionOfType(string type)
        {
            switch(type.ToLower())
            {
                case "temperature":
                    return new TemperatureConversion();
                case "length":
                    return new LengthConversion();
                case "volume":
                    return new VolumeConversion();
                case "mass":
                    return new MassConversion();
                case "speed":
                    return new SpeedConversion();
                default:
                    throw new ConversionNotFoundException(type);
            }
        }
    }
}
