using System.Collections.Generic;
using CommonMathLibrary.Interface;
using System.Linq;

namespace CommonMathLibrary
{
    public class Vector : List<double>, IVector
    {
        public IVector Clone()
        {
            var newVector = new Vector();
            foreach (var el in this) newVector.Add(el);
            return newVector;
        }
    }
}
