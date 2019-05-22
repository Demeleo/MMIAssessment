﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MMIAssess.Core.Interfaces
{
    public interface IConversion
    {
        IConversionResult DoConversion(IUnitOfMeasure fromUnit, IUnitOfMeasure toUnit, decimal value);
        void AddUnits(params IUnitOfMeasure[] units);
    }
}
