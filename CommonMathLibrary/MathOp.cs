using System;
using System.Linq;

namespace CommonMathLibrary
{
    public static class MathOp
    {
        public static double Sum<TIn>(TIn[] a, Func<TIn, double> f) => a.Aggregate(0d, (x, y) => x + f(y));

        public static double Sign(double a) => a >= 0 ? 1 : -1;

        public static double Dot(double[] a, double[] b)
        {
            if (a.Length != b.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            return a.Select((t, i) => b[i] * t).Sum();
        }

        public static int Compare(double a, double b)
        {
            if (a < b)
            {
                return -1;
            }

            return a > b ? 1 : 0;
        }
    }
}
