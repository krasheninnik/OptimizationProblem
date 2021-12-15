using CommonMathLibrary.Interface;

namespace Functions.Interface
{
    public interface IFunction
    {
        double Value(IVector point);
    }
}
