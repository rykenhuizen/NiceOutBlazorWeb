using System;
using System.Collections.Generic;

namespace NiceOut.Business.Impacts
{
    public class PopImpact : IImpact
    {
        KeyValuePair<int, string> IImpact.GetImpact(int devation)
        {
            var message = "";
            var impact = -Math.Abs(Convert.ToInt32(devation / 10));
            switch (devation)
            {
                case > 70:
                    impact -= 20;
                    message = "Likely pecipitation";
                    break;
                case > 50:
                    impact -= 20;
                    message = "Decent chance of pecipitation";
                    break;
                case > 30:
                    impact -= 15;
                    message = "Chance of pecipitation";
                    break;
                case > 5:
                    impact -= 5;
                    message = "Small chance of pecipitation";
                    break;
                case > -5:
                    break;

                case > -10:
                    impact -= 5;
                    message = "pecipitation Unlikely";
                    break;
                case > -30:
                    impact -= 15;
                    message = "pecipitation Unlikely";
                    break;
                case >= -50:
                    impact -= 20;
                    message = "pecipitation Very Unlikely";
                    break;
                case < -50:
                    impact -= 25;
                    message = "pecipitation: doubtfull";
                    break;

            }

            return new KeyValuePair<int, string>(impact, message);
        }
    }
}
