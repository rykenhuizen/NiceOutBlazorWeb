using System;
using System.Collections.Generic;

namespace NiceOut.Business.Impacts
{
    public class WindImpact : IImpact
    {
        KeyValuePair<int, string> IImpact.GetImpact(int devation)
        {
            var message = "";
            var impact = -Math.Abs(Convert.ToInt32(devation / 10));
            switch (devation)
            {
                case > 60:
                    impact -= 9;
                    message = "Way too windy";
                    break;
                case > 30:
                    impact -= 4;
                    message = "Too Windy";
                    break;
                case > -10:

                    break;

                case < -30:
                    impact -= 5;
                    message = "Not enough wind";
                    break;
            }

            return new KeyValuePair<int, string>(impact, message);

    }
    }
}
