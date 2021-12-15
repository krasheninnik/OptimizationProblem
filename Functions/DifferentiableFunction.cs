using Functions.Interface;
using CommonMathLibrary.Interface;
using System;

namespace Functions
{
    public class DifferentiableFunction : Function, IDifferentiableFunction
    {
        protected readonly Func<IVector, IVector> _grad;

        public DifferentiableFunction(Func<IVector, double> f, Func<IVector, IVector> grad) : base(f)
        {
            _grad = grad;
        }

        public IVector Gradient(IVector point) => _grad(point);
    }
}
