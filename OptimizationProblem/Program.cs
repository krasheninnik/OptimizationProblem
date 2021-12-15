using Functionals;
using System;
using System.Collections.Generic;
using CommonMathLibrary.Interface;
using CommonMathLibrary;
using Functions;

namespace OptimizationProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var point1 = new Vector { 0d };
            var point2 = new Vector { 2d };
            var point3 = new Vector { 3d };
            var point4 = new Vector { 1d };

            var functional = new L1Functional(
                new List<ValueInPoint>
                {
                    new ValueInPoint(point1, 1d),
                    new ValueInPoint(point2, 9d),
                    new ValueInPoint(point3, 16d),
                    new ValueInPoint(point4, 4d),
                }
            );

            var initialParameters = new Vector { 1d, 0d };

            var optimizer = new MonteCarloMethod(1000, 1e-14);
            var value = optimizer.Minimize(functional, new LinearNFunction(), initialParameters);

            foreach (var v in value) Console.Write($"{v} ");
            Console.ReadLine();
        }
    }
}
