using System;
using System.Collections.Generic;

namespace NiceOut.Business.Impacts
{
    public class CloudImpact : IImpact
    {
        KeyValuePair<int, string> IImpact.GetImpact(int devation)
        {
            var message = "";
            var impact = -Math.Abs(Convert.ToInt32(devation / 10));
            switch (devation)
            {
                case > 60:
                    impact -= 9;
                    message = "Way too many clouds";
                    break;
                case > 30:
                    impact -= 4;
                    message = "Too many clouds";
                    break;
                case > 10:
                    message = "Could be less clouds";
                    break;

                case > -10:
                    message = "Nice amount of clouds";
                    break;
                case >= -30:
                    message = "Could use a couple clouds";
                    break;
                case < -30:
                    impact -= 9;
                    message = "Need way more clouds";
                    break;
            }

            return new KeyValuePair<int, string>(impact, message);

    }
    }
}
