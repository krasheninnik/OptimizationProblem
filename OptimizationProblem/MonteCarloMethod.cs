using Functionals.Interface;
using Functions.Interface;
using OptimizationProblem.Interface;
using System;
using MathNet.Numerics.Distributions;
using CommonMathLibrary.Interface;
using CommonMathLibrary;
using System.Linq;

namespace OptimizationProblem
{
    /// <summary>
    /// Метод Монте-карло 
    /// </summary>
    public class MonteCarloMethod : IOptimizator
    {
        private double Eps { get; set; }

        private int? MaxIteration { get; set; }

        private double Mean { get; set; } = 0;

        private double StdDev { get; set; } = 1;

        public MonteCarloMethod(int? maxIteration, double eps)
        {
            MaxIteration = maxIteration;
            Eps = eps;
        }

        public IVector Minimize(IFunctional objective, IParametricFunction function, IVector initialParameters, IVector minimumParameters = null, IVector maximumParameters = null)
        {
            var k = 0;

            IVector xPrev = initialParameters.Clone();

            IVector xNew = initialParameters.Clone();

            var normalDist = new Normal(Mean, StdDev);

            double prevValue = objective.Value(function.Bind(xPrev));

            do
            {
                var t = 20d / Math.Log(k, Math.E);

                for (int i = 0; i < xPrev.Count; i++)
                {
                    var nR = normalDist.Sample() * t;

                    xNew[i] = xPrev[i]+ nR;
                }

                if (!(maximumParameters is null))
                {
                    for (int i = 0; i < xNew.Count; i++)
                    {
                        if (MathOp.Compare(xNew[i], maximumParameters[i]) == -1)
                        {
                            xNew[i] = maximumParameters[i];
                        }
                    }
                }

                if (!(minimumParameters is null))
                {
                    for (int i = 0; i < xNew.Count; i++)
                    {
                        if (MathOp.Compare(xNew[i], minimumParameters[i]) == 1)
                        {
                            xNew[i] = minimumParameters[i];
                        }
                    }
                }

                var newValue = objective.Value(function.Bind(xNew));

                var sub = newValue - prevValue;

                if (MathOp.Compare(sub, 0d) == -1)
                {
                    prevValue = newValue;

                    xPrev = xNew.Clone();
                }
            } while ((MaxIteration.HasValue && MaxIteration > k++ && MathOp.Compare(prevValue, Eps) == 1) || (!MaxIteration.HasValue && MathOp.Compare(prevValue, Eps) == 1));

            return xPrev;
        }
    }
}
