using Functions.Interface;
using CommonMathLibrary;
using CommonMathLibrary.Interface;
using System;
using System.Linq;



namespace Functions
{
    /// <summary>
    /// Линейная функция в n-мерном пространстве
    /// </summary>
    public class LinearNFunction: IParametricFunction
    {
        public IVector Gradient(IVector parametrs, IVector point)
        {
            ThrowIfNonValid(parametrs, point);

            return parametrs;
        }

        public double Value(IVector parametrs, IVector point)
        {
            ThrowIfNonValid(parametrs, point);

            double res = parametrs.Last(); // учтем свободный член
            for (int i = 0; i < point.Count; i++) res += parametrs[i] * point[i];
            return res;
        }

        private void ThrowIfNonValid(IVector parametrs, IVector point)
        {
            if (point.Count != parametrs.Count - 1) throw new ArgumentException($"В point ожидается {parametrs.Count - 1} значений, но полученно: {point.Count}");
        }

        public IFunction Bind(IVector parametrs) => new DifferentiableFunction(point => Value(parametrs, point),
                                                                                point => Gradient(parametrs, point));
    }
}
