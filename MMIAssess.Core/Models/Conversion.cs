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
        private string _fromUnitDesc;
        private string _toUnitDesc;

        public decimal Value { get; set; }

        public void AddUnits(params IUnitOfMeasure[] units)
        {
            unitsOfMeasure.AddRange(units);
        }

        public IConversionResult DoConversion(string fromUnitDesc, string toUnitDesc, decimal value)
        {
            _fromUnitDesc = fromUnitDesc;
            _toUnitDesc = toUnitDesc;
            return DoConversion(GetUnitByDescription(_fromUnitDesc), GetUnitByDescription(_toUnitDesc), value);
        }

        public IConversionResult DoConversion(IUnitOfMeasure fromUnit, IUnitOfMeasure toUnit, decimal value)
        {
            if (fromUnit == null || toUnit == null || Type != fromUnit.GetUnitConversionType() || Type != toUnit.GetUnitConversionType())
            {
                throw new IncompatibleConversionException(this.Type.ToString(), _fromUnitDesc, _toUnitDesc);
            }

            return fromUnit.ConvertTo(value, toUnit);
        }

        public IUnitOfMeasure GetUnitByDescription(string unitDescription)
        {
            return unitsOfMeasure.Find((unit) => {
                return unit.GetUnitDescription().ToLower() == unitDescription.ToLower();
            });
        }
    }
}




