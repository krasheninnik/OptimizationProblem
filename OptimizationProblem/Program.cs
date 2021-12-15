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
        private static void Handler(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        static void Main(string[] args)
        {
            var point1 = new Vector { 0d };
            var point2 = new Vector { 2d };
            var point3 = new Vector { 4d };
            var point4 = new Vector { 6d };

            var l1Functional = new L1Functional(
                new List<ValueInPoint>
                {
                    new ValueInPoint(point1, 2d),
                    new ValueInPoint(point2, 4d),
                    new ValueInPoint(point3, 6d),
                    new ValueInPoint(point4, 8d),
                }
            );

            var lInfFunctional = new LInfFunctional(
                new List<ValueInPoint>
                {
                    new ValueInPoint(point1, 2d),
                    new ValueInPoint(point2, 4d),
                    new ValueInPoint(point3, 6d),
                    new ValueInPoint(point4, 8d),
                }
            );

            var initialParameters = new Vector { 15d, 14d };


            Console.WriteLine("MonteCarloMethod");
            Console.WriteLine("l1");
            try
            {
                Console.WriteLine("LinearFunction");
                var optimizer = new MonteCarloMethod(1000, 1e-14);
                var value = optimizer.Minimize(l1Functional, new LinearNFunction(), initialParameters);
                foreach (var v in value) Console.Write($"{v} ");
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                Handler(e);
            }

            try
            {
                Console.WriteLine("PolinomialNFunction");
                var optimizer = new MonteCarloMethod(1000, 1e-14);
                var value = optimizer.Minimize(l1Functional, new PolinomialNFunction(), initialParameters);
                foreach (var v in value) Console.Write($"{v} ");
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                Handler(e);
            }

            Console.WriteLine("MonteCarloMethod");
            Console.WriteLine("LInf");
            try
            {
                Console.WriteLine("LinearFunction");
                var optimizer = new MonteCarloMethod(1000, 1e-14);
                var value = optimizer.Minimize(lInfFunctional, new LinearNFunction(), initialParameters);
                foreach (var v in value) Console.Write($"{v} ");
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                Handler(e);
            }

            try
            {
                Console.WriteLine("PolinomialNFunction");
                var optimizer = new MonteCarloMethod(1000, 1e-14);
                var value = optimizer.Minimize(lInfFunctional, new PolinomialNFunction(), initialParameters);
                foreach (var v in value) Console.Write($"{v} ");
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                Handler(e);
            }


            Console.WriteLine("GradientDescentMethod");
            Console.WriteLine("L1");
            try
            {
                Console.WriteLine("LinearFunction");
                var optimizer = new GradientDescentMethod(1000, 1e-14);
                var value = optimizer.Minimize(l1Functional, new LinearNFunction(), initialParameters);
                foreach (var v in value) Console.Write($"{v} ");
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                Handler(e);
            }

            try
            {
                Console.WriteLine("PolinomialNFunction");
                var optimizer = new GradientDescentMethod(1000, 1e-14);
                var value = optimizer.Minimize(l1Functional, new PolinomialNFunction(), initialParameters);
                foreach (var v in value) Console.Write($"{v} ");
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                Handler(e);
            }

            Console.WriteLine("");
            Console.WriteLine("GradientDescentMethod");
            Console.WriteLine("LInf");
            try
            {
                Console.WriteLine("LinearFunction");
                var optimizer = new GradientDescentMethod(1000, 1e-14);
                var value = optimizer.Minimize(lInfFunctional, new LinearNFunction(), initialParameters);
                foreach (var v in value) Console.Write($"{v} ");
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                Handler(e);
            }

            try
            {
                Console.WriteLine("PolinomialNFunction");
                var optimizer = new GradientDescentMethod(1000, 1e-14);
                var value = optimizer.Minimize(lInfFunctional, new PolinomialNFunction(), initialParameters);
                foreach (var v in value) Console.Write($"{v} ");
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                Handler(e);
            }

            Console.ReadLine();
        }
    }
}
