using Functionals.Interface;
using Functions.Interface;
using CommonMathLibrary;
using CommonMathLibrary.Interface;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Functionals
{
    public class L1Functional : IDifferentiableFunctional
    {
        private readonly List<ValueInPoint> _vp;

        public L1Functional(List<ValueInPoint> vp)
        {
            if (!vp.Any()) throw new ArgumentException("Пустой вектор точек и значений не допустим.");

            _vp = vp;
        }

        public IVector Gradient(IFunction func)
        {
            var f = func as IDifferentiableFunction;
            if (f is null) throw new ArgumentException("Ожидается функция, реализующая IDifferentiableFunction");

            IVector result = new Vector();
            foreach (var x in _vp) result.Add(f.Gradient(x.Point).Mult(MathOp.Sign(f.Value(x.Point) - x.Value)));
            return result;
        }

        // Считаем сумму абсолютной погрешности в точки между сохранённым значением (_vp) и значением функции
        public double Value(IFunction func) 
            => _vp.Aggregate(0d, (acc, next) => acc + Math.Abs(func.Value(next.Point) - next.Value));

    }
}
