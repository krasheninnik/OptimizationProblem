using CommonMathLibrary.Interface;

namespace Functions.Interface
{
    public interface IParametricFunction
    {
        IFunction Bind(IVector parameters);
    }
}
