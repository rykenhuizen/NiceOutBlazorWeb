using NiceOut.Business.Impacts;
using NiceOut.Models;

namespace NiceOut.Business
{
    public class DeviationFactory
    {


        public IDevationItem CreateDevationItem(double target, double actual, IImpact impact) =>
            DevationItem((int)(actual - target), actual, impact);

        public IDevationItem CreateDevationItem(int target, int actual, IImpact impact) =>
            DevationItem(actual - target, actual, impact);

        public IDevationItem CreateDevationItem(bool target, bool actual, IImpact impact) =>
            DevationItem(target == actual ? 0 : 1, actual, impact);

        private static DevationItem<T> DevationItem<T>(int devation, T actual, IImpact impact)
        {
            var im = impact.GetImpact(devation);
            return new DevationItem<T>
            {
                Devation = devation,
                value = actual,
                Impact = im.Key,
                Message = im.Value,

            };
        }
    }
}
