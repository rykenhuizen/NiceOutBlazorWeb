
namespace NiceOut.Business
{
    public class TargetWeather
    {
        public double Feels_like { get; set; } = 19;
        public double Temp { get; set; } = 19;
        public int Humidity { get; set; } = 30;
        public int Clouds { get; set; } = 20;
        public double Wind_speed { get; set; } = 20;
        public double Visibility { get; set; } = 10;
        public bool Rain { get; set; } = false;
        public int Pop
        {
            get => Rain ? 100 : 0;
        }
        public bool Night { get; set; } = false;


    }
}

