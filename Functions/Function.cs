using Functions.Interface;
using CommonMathLibrary.Interface;
using System;

namespace Functions
{
    public class Function : IFunction
    {
        protected readonly Func<IVector, double> _f;

        public Function(Func<IVector, double> f)
        {
            _f = f;
        }

        public double Value(IVector point) => _f(point);
    }
}
