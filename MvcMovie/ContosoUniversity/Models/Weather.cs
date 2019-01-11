using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ContosoUniversity.Models
{
    public class Weather
    {
        [DisplayName("温度")]
        public string Temperature { get; set; }
        [DisplayName("城市")]
        public string City { get; set; }

        [DisplayName("湿度")]     
        public string Humidity { get; set; }
        [DisplayName("级别")]
        public string Wind_strength { get; set; }
        [DisplayName("时间")]
        public string date_y { get; set; }
    }
}
