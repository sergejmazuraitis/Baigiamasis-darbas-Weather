using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas_Orai_Sergej
{
    public class WeatherForcast
    {
        public city city { get; set; }
        public List<list> list { get; set; } //numatomu oru prognozes sarašas
    }

    public class temp
    {
        public double day { get; set; }
       
    }

    public class weather
    {
        public string  main { get; set; }
        public string  description { get; set; }
    }

    public class city
    {
        public string name { get; set; }
    }

    public class list
    {
        public double dt { get; set; } //diena milisiekundiem
        public double pressure { get; set; } // spaudimas hPa
        public double humidity { get; set; } //driegnumas %
        public double speed { get; set; } //vėjo greitis km/h
        public temp temp { get; set; } //oro temperatura
        public List<weather> weather { get; set; } //oru sarašas

    }
}
