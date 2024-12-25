using System.Collections.Generic;

namespace NiceOut.Business.Impacts
{
    public class NightImpact : IImpact
    {
        public readonly bool _night;

        public NightImpact(bool night)
        {
            _night = night;
        }

        KeyValuePair<int, string> IImpact.GetImpact(int devation)
        {
            var message = "";
            var impact = 0;
            if (devation == 1)
            {
                impact -= 20;
                message = _night ? "The light, it burns!" : "Nighttime";
            }

            return new KeyValuePair<int, string>(impact, message);

    }
    }
}
