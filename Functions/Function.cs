using Functions.Interface;
using CommonMathLibrary.Interface;
using System;

namespace Functions
{
    public class Function : IFunction
    {
        protected readonly Func<IVector, double> F;

        public Function(Func<IVector, double> f)
        {
            F = f;
        }

        public double Value(IVector point) => F(point);
    }
}
