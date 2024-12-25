using System;
using System.Collections.Generic;

namespace NiceOut.Business.Impacts
{
    public class VisibilityImpact : IImpact
    {
        KeyValuePair<int, string> IImpact.GetImpact(int devation)
        {
            var message = "";
            var impact = -Math.Abs(Convert.ToInt32(devation / 1000));
            switch (devation)
            {
                case > 7000:
                    impact -= 25;
                    message = "Way too much visibility";
                    break;
                case > 5000:
                    impact -= 20;
                    message = "Visibility too high";
                    break;
                case > 3000:
                    impact -= 10;
                    message = "Visibility a bit too hight";
                    break;
                case > 1000:
                    message = "Visibility a bit high";
                    break;
                case > -1000:
                    message = "Good Visibility";
                    break;
                case > -5000:
                    impact -= 10;
                    message = "Visibility low";
                    break;
                case >= -7000:
                    impact -= 20;
                    message = "Visibility quite low";
                    break;
                case < -7000:
                    impact -= 25;
                    message = "Visibility very low";
                    break;

            }

            return new KeyValuePair<int, string>(impact, message);
        }
    }
}
