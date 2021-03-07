using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace antblazor.module
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
        public string Summary3 => Summary + "xx";

        public string Summary2 { get; set; }

        public void fillData()
        {
            this.Summary2 = Summary3 + "--2";
        }
        
        
        
        [DisplayName("Tags")]
        public List<string> Tags { get; set; }
    }
}