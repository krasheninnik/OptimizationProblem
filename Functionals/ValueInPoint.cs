using CommonMathLibrary.Interface;

namespace Functionals
{
    public class ValueInPoint
    {
        public ValueInPoint(IVector point, double value)
        {
            Point = point;
            Value = value;
        }

        public IVector Point { get; set; }
        public double Value { get; set; }
    }
}
