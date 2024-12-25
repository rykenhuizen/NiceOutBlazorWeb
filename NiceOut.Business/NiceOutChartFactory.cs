using NiceOut.Models;
using NiceOut.Data;
using static NiceOut.Models.WeatherApi;

namespace NiceOut.Business
{
    public class NiceOutChartFactory
    {

        public async Task<NiceOutChart> GetChartData()
        {
            var repo = new WeatherApiRepository();
            WeatherApiModel apiData = await repo.GetApiData();

            var hours = new List<HourlyDetails>();

            var df = new DeviationFactory();
            var _niceness = new Niceness(df);

            foreach (var hour in apiData.forecast.forecastday[0].hour)
            {
                var hd = _niceness.GetNiceness(hour);
                //var h = new HourlyDetails();
                //h.hour = DateTime.Parse(hour.time).Hour;
                //h.tooltips = new string[] { hour.condition.text };
                //h.niceFactor = 100 - hour.cloud;
                hours.Add(hd);
            }



            var chartData = new NiceOutChart(DateOnly.FromDateTime(DateTime.Parse(apiData.location.localtime)), apiData.location.name);
            //SmoothOutNiceFactor(hours);
            chartData.details = hours.ToArray();

            //chartData.details = new HourlyDetails[]
            //{
            //    new(){ hour = 1, niceFactor = 10,tooltips = ["tt1"] },
            //    new(){ hour = 2, niceFactor = 30,tooltips = ["tt2"] },
            //    new(){ hour = 3, niceFactor = 80,tooltips = ["tt3"] },
            //    new(){ hour = 4, niceFactor = 20,tooltips = ["tt4"] },
            //    new(){ hour = 5, niceFactor = 30,tooltips = ["tt5"] },
            //    new(){ hour = 6, niceFactor = 10,tooltips = ["tt6", "tt7"] },

            //};
            //var deets = new HourlyDetails(){hour = 1, niceFactor = 10, tooltips = ["tt1"]
            //};
            



            return chartData;
        }

        //private void SmoothOutNiceFactor(List<HourlyDetails> dr)
        //{
        //    //TODO: this is not a perfect solution, some sort of bell curve would be better.
        //    foreach (var d in dr)
        //    {
        //        var nfMin = dr.Min(x => x.niceFactor);
        //        var nfMax = dr.Max(x => x.niceFactor);
        //        if (nfMin < 0)
        //        {
        //            d.niceFactor = d.niceFactor.Select(i => i - nfMin).ToArray();

        //            for (int i = 0; d.niceFactor.Length > i; i++)
        //            {
        //                if (d.niceFactor[i] > 100)
        //                {
        //                    d.niceFactor[i] = 100;
        //                }
        //            }
        //        }
        //    }

        //}
    }
}
