using Functionals.Interface;
using Functions.Interface;
using CommonMathLibrary;
using CommonMathLibrary.Interface;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Functionals
{
    // L-infinity norm: gives the largest magnitude among each element of a vector.
    public class LInfFunctional : IFunctional
    {
        private readonly List<ValueInPoint> _vp;

        public LInfFunctional(List<ValueInPoint> vp)
        {
            if (!vp.Any())
                throw new ArgumentException("Пустой вектор точек и значений не допустим.");

            _vp = vp;
        }

        public double Value(IFunction func) => _vp.Max(x => Math.Abs(x.Value - func.Value(x.Point)));
    }
}
