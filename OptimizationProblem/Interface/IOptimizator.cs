using Functionals.Interface;
using Functions.Interface;
using CommonMathLibrary.Interface;

namespace OptimizationProblem.Interface
{
    public interface IOptimizator
    {
        IVector Minimize(IFunctional objective,
                         IParametricFunction function,
                         IVector initialParameters,
                         IVector minimumParameters = default,
                         IVector maximumParameters = default);
    }
}
