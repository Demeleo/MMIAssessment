using MMIAssess.Core.Exceptions;
using MMIAssess.Core.Interfaces;
using MMIAssess.Core.Shared;
using System.Collections.Generic;

namespace MMIAssess.Core.Models
{
    public class Conversion: IConversion
    {
        protected List<IUnitOfMeasure> unitsOfMeasure;
        public Conversion()
        {
            unitsOfMeasure = new List<IUnitOfMeasure>();
        }

        public ConversionType Type { get; protected set; }
        public decimal Value { get; set; }

        public void AddUnits(params IUnitOfMeasure[] units)
        {
            unitsOfMeasure.AddRange(units);
        }

        public virtual IConversionResult DoConversion(IUnitOfMeasure fromUnit, IUnitOfMeasure toUnit, decimal value)
        {
            if (Type != fromUnit.GetUnitConversionType() || Type != toUnit.GetUnitConversionType())
            {
                throw new IncompatibleConversionException(this.Type.ToString(), fromUnit.GetUnitDescription(), toUnit.GetUnitDescription());
            }

            return null;
        }
    }
}




