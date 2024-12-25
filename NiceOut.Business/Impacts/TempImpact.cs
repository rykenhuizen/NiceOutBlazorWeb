using System;
using System.Collections.Generic;

namespace NiceOut.Business.Impacts
{
    public class TempImpact : IImpact
    {
        KeyValuePair<int, string> IImpact.GetImpact(int devation)
        {
            var message = "";
            var impact = -(Math.Abs(devation));
            switch (devation)
            {
                case > 15:
                    impact -= 10;
                    message = "Friggin' hot";
                    break;
                case > 10:
                    impact -= 5;
                    message = "Way too warm";
                    break;
                case > 5:
                    message = "Too warm";
                    break;
                case > 3:
                    message = "A bit too warm";
                    break;
                case > -3:
                    message = "Nice Tempreture out!";
                    break;
                case > -5:
                    message = "A bit too cold";
                    break;
                case >= -10:
                    impact -= 5;
                    message = "Too cold out";
                    break;
                case < -10:
                    impact -= 10;
                    message = "Way too cold out";
                    break;
            }

            return new KeyValuePair<int, string>(impact, message);

    }
    }
}
