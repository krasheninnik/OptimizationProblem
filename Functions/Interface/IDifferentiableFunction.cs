using CommonMathLibrary.Interface;

namespace Functions.Interface
{
    public interface IDifferentiableFunction : IFunction
    {
        IVector Gradient(IVector point);
    }
}
