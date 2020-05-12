using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace BaigiamasisDarbas_Orai_Sergej
{
    public partial class Form1 : Form
    {
        const string APPID = "5ccd79b8f77ca0ae8636212e47a38db0";
        string cityName = "Kaunas";
        public Form1()
        {
            InitializeComponent();
            getWeather("Lietuva"); //orai vienai dienai
            getForcast("Lietuva"); //daugiau nei vienai dienai
        }

        void getWeather(string city)
        {
            using (WebClient web = new WebClient())
            {

                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&cnt=3", cityName, APPID);

                var json = web.DownloadString(url);

                var result = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                WeatherInfo.root outPut = result;
                lbl_cityName.Text = string.Format("{0}", outPut.name);
                lbl_country.Text = string.Format("{0}", outPut.sys.country);
                lbl_Temp.Text = string.Format("{0} \u00B0" + "C", outPut.main.temp);
            }

        }
        public void getForcast(string city)
        {
            int day = 5;
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={2}&units=metric&cnt={1}", cityName, day, APPID);
            using (WebClient web = new WebClient())
            {
                var json = web.DownloadString(url);
                var Object = JsonConvert.DeserializeObject<WeatherForcast>(json);

                WeatherForcast forcast = Object;

                lbl_Conditions.Text = string.Format("{0}", forcast.list[4].weather[0].main); //oro būsena
                lbl_description.Text = string.Format("{0}", forcast.list[1].weather[0].description); //oro aprašimas
                lbl_daysTemp.Text = string.Format("{0}", forcast.list[1].temp.day); //oro temperatūra
                lbl_WindSpeed.Text = string.Format("{0} km/h", forcast.list[1].speed); //vėjo greitis

            }
        }
    }
}
