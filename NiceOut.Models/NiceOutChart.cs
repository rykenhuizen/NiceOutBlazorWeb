using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceOut.Models
{
    public class NiceOutChart
    {
        public DateOnly date { get; set; }
        public string location { get; set; }
        public HourlyDetails[] details { get; set; }

        public NiceOutChart(DateOnly d, string l)
        {
            date = d;
            location = l;
        }

       
    }

        public class HourlyDetails()
    {
        public int hour { get; set; }
        public int niceFactor { get; set; }
        public string[] tooltips { get; set; }

    }
    
}
