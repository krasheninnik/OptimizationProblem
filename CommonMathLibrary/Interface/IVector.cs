using System.Collections.Generic;

namespace CommonMathLibrary.Interface
{
    public interface IVector : IList<double>
    {
        IVector Clone();
    }
}
