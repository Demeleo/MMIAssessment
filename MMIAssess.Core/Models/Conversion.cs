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
        public IUnitOfMeasure FromUnit { get; protected set; }
        public IUnitOfMeasure ToUnit { get; protected set; }

        public decimal Value { get; set; }

        public void AddUnits(params IUnitOfMeasure[] units)
        {
            unitsOfMeasure.AddRange(units);
        }

        public IConversionResult DoConversion(string fromUnitDesc, string toUnitDesc, decimal value)
        {
            FromUnit = GetUnitByDescription(fromUnitDesc);
            ToUnit = GetUnitByDescription(toUnitDesc);

            if (FromUnit == null || ToUnit == null || Type != FromUnit.GetUnitConversionType() || Type != ToUnit.GetUnitConversionType())
            {
                throw new IncompatibleConversionException(this.Type.ToString(), fromUnitDesc, toUnitDesc);
            }

            return FromUnit.ConvertTo(value, ToUnit);
        }

        public IUnitOfMeasure GetUnitByDescription(string unitDescription)
        {
            return unitsOfMeasure.Find((unit) => {
                return unit.GetUnitDescription().ToLower() == unitDescription.ToLower();
            });
        }
    }
}




