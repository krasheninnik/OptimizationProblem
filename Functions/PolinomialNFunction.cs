using Functions.Interface;
using CommonMathLibrary.Interface;
using System;

namespace Functions
{
    /// <summary>
    /// Полином n-й степени в одномерном пространстве
    /// </summary>
    public class PolinomialNFunction : IParametricFunction
    {
        public double Value(IVector parametrs, IVector point)
        {
            ThrowIfNonValid(point);

            double res = 0;
            double x = 1;
            for (int i = parametrs.Count - 1; i >= parametrs.Count; i--)
            {
                res += x * parametrs[i];
                x *= point[0];
            }

            return res;
        }

        private void ThrowIfNonValid(IVector point)
        {
            if (point.Count != 1) throw new ArgumentException($"Одномерный полином ожидает одну координату в point, но полученно: {point.Count}");
        }

        public IFunction Bind(IVector parameters) => new Function(point => Value(parameters, point));
    }
}
