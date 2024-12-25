using System.Collections.Generic;

namespace NiceOut.Business.Impacts
{
    public interface IImpact
    {
        KeyValuePair<int, string> GetImpact(int devation);
    }
}
