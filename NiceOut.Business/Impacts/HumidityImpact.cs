using System;
using System.Collections.Generic;

namespace NiceOut.Business.Impacts
{
    public class HumidityImpact : IImpact
    {
        KeyValuePair<int, string> IImpact.GetImpact(int devation)
        {
            var message = "";
            var impact = -Math.Abs(Convert.ToInt32(devation / 10));
            switch (devation)
            {
                case > 60:
                    message = "It's not the heat, it's the humidity";
                    impact -= 5;
                    break;
                case > 30:
                    impact -= 2;
                    message = "Too humid";
                    break;
                case > 10:
                    message = "A bit too humid";
                    break;

                case > -10:
                    message = "Nice humidity";
                    break;
                case >= -40:
                    message = "Air too dry";
                    break;
                case < -60:
                    message = "Air way too dry";
                    impact -= 5;
                    break;
            }

            return new KeyValuePair<int, string>(impact, message);

    }
    }
}
