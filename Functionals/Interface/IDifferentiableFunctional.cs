using Functions.Interface;
using CommonMathLibrary.Interface;

namespace Functionals.Interface
{
    public interface IDifferentiableFunctional : IFunctional
    {
        IVector Gradient(IFunction function);
    }
}
