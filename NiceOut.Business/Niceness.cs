using NiceOut.Business.Impacts;
using NiceOut.Models;
using System.Collections.Generic;
using System.Linq;
using static NiceOut.Models.WeatherApi;

namespace NiceOut.Business
{
    public class Niceness
    {

        private readonly DeviationFactory _deviationFactory;
        public Niceness(DeviationFactory df)
        {
            _deviationFactory = df;
        }

        public HourlyDetails GetNiceness(Hour hour)
        {
            var targetWeather = new TargetWeather();


            var items = new List<IDevationItem>
            {
                _deviationFactory.CreateDevationItem(targetWeather.Feels_like, hour.feelslike_c, new TempImpact()),
                //_deviationFactoryCreateDevationItem(targetWeather.Temp, hour.temp),
                _deviationFactory.CreateDevationItem(targetWeather.Humidity, hour.humidity, new HumidityImpact()),
                _deviationFactory.CreateDevationItem(targetWeather.Clouds, hour.cloud, new CloudImpact()),
                _deviationFactory.CreateDevationItem(targetWeather.Wind_speed, hour.wind_kph, new WindImpact()),
                _deviationFactory.CreateDevationItem(targetWeather.Pop, hour.chance_of_rain, new PopImpact()),
                _deviationFactory.CreateDevationItem(targetWeather.Visibility, hour.vis_km, new VisibilityImpact()),
                _deviationFactory.CreateDevationItem(targetWeather.Night, !Convert.ToBoolean(hour.is_day), new NightImpact(targetWeather.Night))
            };

            var detail = new HourlyDetails()
            {
                hour = DateTime.Parse(hour.time).Hour,
                niceFactor = MeasureNiceness(items),
                tooltips = GetToolTips(items)
            };


            return detail;
        }

        private static int MeasureNiceness(List<IDevationItem> di)
        {
            var niceness = 100;
            niceness += di.Sum(x => x.Impact);

            //TODO: not a great solution
            return niceness < 0 ? 5 : niceness;
        }

        private static string[] GetToolTips(List<IDevationItem> di)
        {
           
                return di.OrderBy(x => x.Impact).Where(x => !string.IsNullOrWhiteSpace(x.Message)).Select(x => x.Message).ToArray();
           
        }

    }
}
