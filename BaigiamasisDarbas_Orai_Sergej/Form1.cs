using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.CodeDom;
using System.Net.Http;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BaigiamasisDarbas_Orai_Sergej
{
    public partial class Form1 : Form
    {
        const string APPID = "5ccd79b8f77ca0ae8636212e47a38db0";
        string cityName = "";
        string IconChangeVar = null;
        double SunriseNow = 0;
        double SunsetNow = 0;
        double TimeNow = 0;
        string DayNight2 = null;
        string DayNight3 = null;
        string DayNight4 = null;
        string DayNight5 = null;


        public Form1()
        {
            InitializeComponent();
            StartWithMyCity();
        }

        void getWeather()
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
                lbl_Conditions1.Text = string.Format("{0}", outPut.weather[0].main);
                lbl_Description1.Text = string.Format("{0}", outPut.weather[0].description);
                lbl_WindSpeed1.Text = string.Format("{0} km/h", outPut.wind.speed);

                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pc\source\repos\BaigiamasisDarbas_Orai_Sergej\BaigiamasisDarbas_Orai_Sergej\City.mdf;Integrated Security=True";
                SqlConnection sql = new SqlConnection(connectionString);
                string querry = "SELECT TOP 1 * FROM IconsTable";
                SqlCommand command = new SqlCommand(querry, sql);
                sql.Open();
                SqlDataReader takeIcon = command.ExecuteReader();
                while (takeIcon.Read())
                {
                    IconsTable iconsTable = new IconsTable();
                    iconsTable.Icons = takeIcon["Icons"].ToString();
                    IconChangeVar = iconsTable.Icons;
                }
                sql.Close();

                SunriseNow = outPut.sys.sunrise;
                SunsetNow = outPut.sys.sunset;
                TimeNow = outPut.dt;


                if (IconChangeVar == null)
                {
                    string iconNr1 = outPut.weather[0].icon;

                    string url1 = string.Format("http://openweathermap.org/img/wn/{0}@2x.png", iconNr1);

                    WebRequest request1 = WebRequest.Create(url1);
                    using (var response1 = request1.GetResponse())
                    {
                        using (var str1 = response1.GetResponseStream())
                        {
                            pictureBox1.Image = Bitmap.FromStream(str1);
                        }
                    }

                }
                else
                {
                    ChangeIcon1();
                }

                if (outPut.dt >= outPut.sys.sunrise && outPut.dt <= outPut.sys.sunset)
                {
                    BackgroundImage = Properties.Resources.day;
                }
                else
                {
                    BackgroundImage = Properties.Resources.night;
                }


            }

        }
        void getForcast()
        {
            int day = 10;
            string url = string.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&units=metric&cnt={1}&APPID={2}", cityName, day, APPID);
            using (WebClient web = new WebClient())
            {
                var json = web.DownloadString(url);
                var Object = JsonConvert.DeserializeObject<WeatherForcast>(json);

                WeatherForcast forcast = Object;

                DayNight2 = forcast.list[0].sys.pod;
                DayNight3 = forcast.list[3].sys.pod;
                DayNight4 = forcast.list[6].sys.pod;
                DayNight5 = forcast.list[9].sys.pod;



                lbl_Days2.Text = string.Format("{0}", forcast.list[0].dt_txt);
                lbl_Conditions2.Text = string.Format("{0}", forcast.list[0].weather[0].main); //oro būsena
                lbl_Description2.Text = string.Format("{0}", forcast.list[0].weather[0].description); //oro aprašimas
                lbl_daysTemp2.Text = string.Format("{0} \u00B0" + "C", forcast.list[0].main.temp); //oro temperatūra
                lbl_WindSpeed2.Text = string.Format("{0} km/h", forcast.list[0].wind.speed); //vėjo greitis



                lbl_Days3.Text = string.Format("{0}", forcast.list[3].dt_txt);
                lbl_Conditions3.Text = string.Format("{0}", forcast.list[3].weather[0].main); //oro būsena
                lbl_Description3.Text = string.Format("{0}", forcast.list[3].weather[0].description); //oro aprašimas
                lbl_daysTemp3.Text = string.Format("{0} \u00B0" + "C", forcast.list[3].main.temp); //oro temperatūra
                lbl_WindSpeed3.Text = string.Format("{0} km/h", forcast.list[3].wind.speed); //vėjo greitis



                lbl_Days4.Text = string.Format("{0}", forcast.list[6].dt_txt);
                lbl_Conditions4.Text = string.Format("{0}", forcast.list[6].weather[0].main);
                lbl_Description4.Text = string.Format("{0}", forcast.list[6].weather[0].description);
                lbl_daysTemp4.Text = string.Format("{0} \u00B0" + "C", forcast.list[6].main.temp);
                lbl_WindSpeed4.Text = string.Format("{0} km/h", forcast.list[6].wind.speed);

                lbl_Days5.Text = string.Format("{0}", forcast.list[9].dt_txt);
                lbl_Conditions5.Text = string.Format("{0}", forcast.list[9].weather[0].main);
                lbl_Description5.Text = string.Format("{0}", forcast.list[9].weather[0].description);
                lbl_daysTemp5.Text = string.Format("{0} \u00B0" + "C", forcast.list[9].main.temp);
                lbl_WindSpeed5.Text = string.Format("{0} km/h", forcast.list[9].wind.speed);


                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pc\source\repos\BaigiamasisDarbas_Orai_Sergej\BaigiamasisDarbas_Orai_Sergej\City.mdf;Integrated Security=True";
                SqlConnection sql = new SqlConnection(connectionString);
                string querry = "SELECT TOP 1 * FROM IconsTable";
                SqlCommand command = new SqlCommand(querry, sql);
                sql.Open();
                SqlDataReader takeIcon = command.ExecuteReader();
                while (takeIcon.Read())
                {
                    IconsTable iconsTable = new IconsTable();
                    iconsTable.Icons = takeIcon["Icons"].ToString();
                    IconChangeVar = iconsTable.Icons;
                }
                sql.Close();


                if (IconChangeVar == null)
                {
                    string iconNr2 = forcast.list[0].weather[0].icon;

                    string url2 = string.Format("http://openweathermap.org/img/wn/{0}@2x.png", iconNr2);

                    WebRequest request2 = WebRequest.Create(url2);
                    using (var response2 = request2.GetResponse())
                    {
                        using (var str2 = response2.GetResponseStream())
                        {
                            pictureBox2.Image = Bitmap.FromStream(str2);
                        }
                    }

                    string iconNr3 = forcast.list[3].weather[0].icon;

                    string url3 = string.Format("http://openweathermap.org/img/wn/{0}@2x.png", iconNr3);

                    WebRequest request3 = WebRequest.Create(url3);
                    using (var response3 = request3.GetResponse())
                    {
                        using (var str3 = response3.GetResponseStream())
                        {
                            pictureBox3.Image = Bitmap.FromStream(str3);
                        }
                    }

                    string iconNr4 = forcast.list[6].weather[0].icon;

                    string url4 = string.Format("http://openweathermap.org/img/wn/{0}@2x.png", iconNr4);

                    WebRequest request4 = WebRequest.Create(url4);
                    using (var response4 = request4.GetResponse())
                    {
                        using (var str4 = response4.GetResponseStream())
                        {
                            pictureBox4.Image = Bitmap.FromStream(str4);
                        }
                    }

                    string iconNr5 = forcast.list[9].weather[0].icon;

                    string url5 = string.Format("http://openweathermap.org/img/wn/{0}@2x.png", iconNr5);

                    WebRequest request5 = WebRequest.Create(url5);
                    using (var response5 = request5.GetResponse())
                    {
                        using (var str5 = response5.GetResponseStream())
                        {
                            pictureBox5.Image = Bitmap.FromStream(str5);
                        }
                    }
                }
                else
                {
                    ChangeIcon2();
                    ChangeIcon3();
                    ChangeIcon4();
                    ChangeIcon5();
                }
            }
        }


        public void ChangeIcon1()
        {
            switch (lbl_Conditions1.Text)
            {
                case "Clear":
                    if (TimeNow >= SunriseNow && TimeNow <= SunsetNow)
                    {
                        pictureBox1.Image = Properties.Resources.clear_sky;
                    }
                    else
                    {
                        pictureBox1.Image = Properties.Resources.night_clear_sky;

                    }

                    break;
                case "Clouds":
                    if (TimeNow >= SunriseNow && TimeNow <= SunsetNow)
                    {
                        if (lbl_Description1.Text == "few clouds")
                        {
                            pictureBox1.Image = Properties.Resources.few_clouds;
                        }
                        if (lbl_Description1.Text == "scattered clouds")
                        {
                            pictureBox1.Image = Properties.Resources.scattered_clouds;

                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.broken_clouds;

                        }

                    }
                    else
                    {
                        if (lbl_Description1.Text == "few clouds")
                        {
                            pictureBox1.Image = Properties.Resources.night_few_clouds;
                        }
                        if (lbl_Description1.Text == "scattered clouds")
                        {
                            pictureBox1.Image = Properties.Resources.scattered_clouds;

                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.broken_clouds;

                        }
                    }
                    break;
                case "Rain":
                    if (lbl_Description1.Text == "light intensity shower rain" || lbl_Description1.Text == "shower rain" || lbl_Description1.Text == "heavy intensity shower rain" || lbl_Description1.Text == "ragged shower rain")
                    {
                        pictureBox1.Image = Properties.Resources.shower_rain;
                    }
                    else if (lbl_Description1.Text == "freezing rain")
                    {
                        pictureBox1.Image = Properties.Resources.freezing_rain;
                    }
                    else
                    {
                        if (TimeNow >= SunriseNow && TimeNow <= SunsetNow)
                        {
                            pictureBox1.Image = Properties.Resources.rain;
                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.night_rain;
                        }
                    }
                    break;
                case "Thunderstorm ":
                    pictureBox1.Image = Properties.Resources.thunderstorm;
                    break;
                case "Snow ":
                    pictureBox1.Image = Properties.Resources.snow;
                    break;
                case "Drizzle ":
                    pictureBox1.Image = Properties.Resources.drizzle;
                    break;
                default:
                    pictureBox1.Image = Properties.Resources.mist;
                    break;

            }
        }

        public void ChangeIcon2()
        {
            switch (lbl_Conditions2.Text)
            {
                case "Clear":
                    if (DayNight2 == "d")
                    {
                        pictureBox2.Image = Properties.Resources.clear_sky;
                    }
                    else
                    {
                        pictureBox2.Image = Properties.Resources.night_clear_sky;

                    }

                    break;
                case "Clouds":
                    if (DayNight2 == "d")
                    {
                        if (lbl_Description2.Text == "few clouds")
                        {
                            pictureBox2.Image = Properties.Resources.few_clouds;
                        }
                        if (lbl_Description2.Text == "scattered clouds")
                        {
                            pictureBox2.Image = Properties.Resources.scattered_clouds;

                        }
                        else
                        {
                            pictureBox2.Image = Properties.Resources.broken_clouds;

                        }

                    }
                    else
                    {
                        if (lbl_Description2.Text == "few clouds")
                        {
                            pictureBox2.Image = Properties.Resources.night_few_clouds;
                        }
                        if (lbl_Description2.Text == "scattered clouds")
                        {
                            pictureBox2.Image = Properties.Resources.scattered_clouds;

                        }
                        else
                        {
                            pictureBox2.Image = Properties.Resources.broken_clouds;

                        }
                    }
                    break;
                case "Rain":
                    if (lbl_Description2.Text == "light intensity shower rain" || lbl_Description2.Text == "shower rain" || lbl_Description2.Text == "heavy intensity shower rain" || lbl_Description2.Text == "ragged shower rain")
                    {
                        pictureBox2.Image = Properties.Resources.shower_rain;
                    }
                    else if (lbl_Description2.Text == "freezing rain")
                    {
                        pictureBox2.Image = Properties.Resources.freezing_rain;
                    }
                    else
                    {
                        if (DayNight2 == "d")
                        {
                            pictureBox2.Image = Properties.Resources.rain;
                        }
                        else
                        {
                            pictureBox2.Image = Properties.Resources.night_rain;
                        }
                    }
                    break;
                case "Thunderstorm ":
                    pictureBox2.Image = Properties.Resources.thunderstorm;
                    break;
                case "Snow ":
                    pictureBox2.Image = Properties.Resources.snow;
                    break;
                case "Drizzle ":
                    pictureBox2.Image = Properties.Resources.drizzle;
                    break;
                default:
                    pictureBox2.Image = Properties.Resources.mist;
                    break;

            }
        }

        public void ChangeIcon3()
        {
            switch (lbl_Conditions3.Text)
            {
                case "Clear":
                    if (DayNight3 == "d")
                    {
                        pictureBox3.Image = Properties.Resources.clear_sky;
                    }
                    else
                    {
                        pictureBox3.Image = Properties.Resources.night_clear_sky;

                    }

                    break;
                case "Clouds":
                    if (DayNight3 == "d")
                    {
                        if (lbl_Description3.Text == "few clouds")
                        {
                            pictureBox3.Image = Properties.Resources.few_clouds;
                        }
                        if (lbl_Description3.Text == "scattered clouds")
                        {
                            pictureBox3.Image = Properties.Resources.scattered_clouds;

                        }
                        else
                        {
                            pictureBox3.Image = Properties.Resources.broken_clouds;

                        }

                    }
                    else
                    {
                        if (lbl_Description3.Text == "few clouds")
                        {
                            pictureBox3.Image = Properties.Resources.night_few_clouds;
                        }
                        if (lbl_Description3.Text == "scattered clouds")
                        {
                            pictureBox3.Image = Properties.Resources.scattered_clouds;

                        }
                        else
                        {
                            pictureBox3.Image = Properties.Resources.broken_clouds;

                        }
                    }
                    break;
                case "Rain":
                    if (lbl_Description3.Text == "light intensity shower rain" || lbl_Description3.Text == "shower rain" || lbl_Description3.Text == "heavy intensity shower rain" || lbl_Description3.Text == "ragged shower rain")
                    {
                        pictureBox3.Image = Properties.Resources.shower_rain;
                    }
                    else if (lbl_Description3.Text == "freezing rain")
                    {
                        pictureBox3.Image = Properties.Resources.freezing_rain;
                    }
                    else
                    {
                        if (DayNight3 == "d")
                        {
                            pictureBox3.Image = Properties.Resources.rain;
                        }
                        else
                        {
                            pictureBox3.Image = Properties.Resources.night_rain;
                        }
                    }
                    break;
                case "Thunderstorm ":
                    pictureBox3.Image = Properties.Resources.thunderstorm;
                    break;
                case "Snow ":
                    pictureBox3.Image = Properties.Resources.snow;
                    break;
                case "Drizzle ":
                    pictureBox3.Image = Properties.Resources.drizzle;
                    break;
                default:
                    pictureBox3.Image = Properties.Resources.mist;
                    break;

            }
        }

        public void ChangeIcon4()
        {
            switch (lbl_Conditions4.Text)
            {
                case "Clear":
                    if (DayNight4 == "d")
                    {
                        pictureBox4.Image = Properties.Resources.clear_sky;
                    }
                    else
                    {
                        pictureBox4.Image = Properties.Resources.night_clear_sky;

                    }

                    break;
                case "Clouds":
                    if (DayNight4 == "d")
                    {
                        if (lbl_Description4.Text == "few clouds")
                        {
                            pictureBox4.Image = Properties.Resources.few_clouds;
                        }
                        if (lbl_Description4.Text == "scattered clouds")
                        {
                            pictureBox4.Image = Properties.Resources.scattered_clouds;

                        }
                        else
                        {
                            pictureBox4.Image = Properties.Resources.broken_clouds;

                        }

                    }
                    else
                    {
                        if (lbl_Description4.Text == "few clouds")
                        {
                            pictureBox4.Image = Properties.Resources.night_few_clouds;
                        }
                        if (lbl_Description4.Text == "scattered clouds")
                        {
                            pictureBox4.Image = Properties.Resources.scattered_clouds;

                        }
                        else
                        {
                            pictureBox4.Image = Properties.Resources.broken_clouds;

                        }
                    }
                    break;
                case "Rain":
                    if (lbl_Description4.Text == "light intensity shower rain" || lbl_Description4.Text == "shower rain" || lbl_Description4.Text == "heavy intensity shower rain" || lbl_Description4.Text == "ragged shower rain")
                    {
                        pictureBox4.Image = Properties.Resources.shower_rain;
                    }
                    else if (lbl_Description4.Text == "freezing rain")
                    {
                        pictureBox4.Image = Properties.Resources.freezing_rain;
                    }
                    else
                    {
                        if (DayNight4 == "d")
                        {
                            pictureBox4.Image = Properties.Resources.rain;
                        }
                        else
                        {
                            pictureBox4.Image = Properties.Resources.night_rain;
                        }
                    }
                    break;
                case "Thunderstorm ":
                    pictureBox4.Image = Properties.Resources.thunderstorm;
                    break;
                case "Snow ":
                    pictureBox4.Image = Properties.Resources.snow;
                    break;
                case "Drizzle ":
                    pictureBox4.Image = Properties.Resources.drizzle;
                    break;
                default:
                    pictureBox4.Image = Properties.Resources.mist;
                    break;

            }
        }

        public void ChangeIcon5()
        {
            switch (lbl_Conditions5.Text)
            {
                case "Clear":
                    if (DayNight5 == "d")
                    {
                        pictureBox5.Image = Properties.Resources.clear_sky;
                    }
                    else
                    {
                        pictureBox5.Image = Properties.Resources.night_clear_sky;

                    }

                    break;
                case "Clouds":
                    if (DayNight4 == "d")
                    {
                        if (lbl_Description5.Text == "few clouds")
                        {
                            pictureBox5.Image = Properties.Resources.few_clouds;
                        }
                        if (lbl_Description5.Text == "scattered clouds")
                        {
                            pictureBox5.Image = Properties.Resources.scattered_clouds;

                        }
                        else
                        {
                            pictureBox5.Image = Properties.Resources.broken_clouds;

                        }

                    }
                    else
                    {
                        if (lbl_Description5.Text == "few clouds")
                        {
                            pictureBox5.Image = Properties.Resources.night_few_clouds;
                        }
                        if (lbl_Description5.Text == "scattered clouds")
                        {
                            pictureBox5.Image = Properties.Resources.scattered_clouds;

                        }
                        else
                        {
                            pictureBox5.Image = Properties.Resources.broken_clouds;

                        }
                    }
                    break;
                case "Rain":
                    if (lbl_Description5.Text == "light intensity shower rain" || lbl_Description5.Text == "shower rain" || lbl_Description5.Text == "heavy intensity shower rain" || lbl_Description5.Text == "ragged shower rain")
                    {
                        pictureBox5.Image = Properties.Resources.shower_rain;
                    }
                    else if (lbl_Description5.Text == "freezing rain")
                    {
                        pictureBox5.Image = Properties.Resources.freezing_rain;
                    }
                    else
                    {
                        if (DayNight4 == "d")
                        {
                            pictureBox5.Image = Properties.Resources.rain;
                        }
                        else
                        {
                            pictureBox5.Image = Properties.Resources.night_rain;
                        }
                    }
                    break;
                case "Thunderstorm ":
                    pictureBox5.Image = Properties.Resources.thunderstorm;
                    break;
                case "Snow ":
                    pictureBox5.Image = Properties.Resources.snow;
                    break;
                case "Drizzle ":
                    pictureBox5.Image = Properties.Resources.drizzle;
                    break;
                default:
                    pictureBox5.Image = Properties.Resources.mist;
                    break;

            }
        }

        private void YourCityButton_Click(object sender, EventArgs e)
        {
            CityTable myCity = new CityTable();
            myCity.City = CityText.Text;
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pc\source\repos\BaigiamasisDarbas_Orai_Sergej\BaigiamasisDarbas_Orai_Sergej\City.mdf;Integrated Security=True";
            SqlConnection sql = new SqlConnection(connectionString);
            string querry = "Insert into CityTable(City) VALUES(@City)";
            SqlCommand command = new SqlCommand(querry, sql);

            command.Parameters.AddWithValue("@City", CityText.Text);
            sql.Open();
            var atsakymas = command.ExecuteNonQuery();
            if (atsakymas < 0)
            {
                MessageBox.Show("Error");
            }
            sql.Close();
            MessageBox.Show("Your city saved");
            StartWithMyCity();
        }

        private void StartWithMyCity()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pc\source\repos\BaigiamasisDarbas_Orai_Sergej\BaigiamasisDarbas_Orai_Sergej\City.mdf;Integrated Security=True";
            SqlConnection sql = new SqlConnection(connectionString);
            string querry = "SELECT TOP 1 * FROM CityTable order by Id DESC";
            SqlCommand command = new SqlCommand(querry, sql);
            sql.Open();
            SqlDataReader takeCity = command.ExecuteReader();
            while (takeCity.Read())
            {
                CityTable cityTable = new CityTable();
                cityTable.City = takeCity["City"].ToString();
                cityName = cityTable.City;
            }
            sql.Close();
            try
            {
                getWeather();
                getForcast();

            }
            catch (WebException ex)
            {
                string querry1 = "DELETE FROM CityTable";
                SqlCommand command1 = new SqlCommand(querry1, sql);
                sql.Open();
                var atsakymas1 = command1.ExecuteNonQuery();
                if (atsakymas1 < 0)
                {
                    MessageBox.Show("Error");
                }

                sql.Close();

                MessageBox.Show("Your city is wrong, please try again");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not expected exception");
            }


        }

        private void IconButton2_Click(object sender, EventArgs e)
        {
            ChangeIcon1();
            ChangeIcon2();
            ChangeIcon3();
            ChangeIcon4();
            ChangeIcon5();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pc\source\repos\BaigiamasisDarbas_Orai_Sergej\BaigiamasisDarbas_Orai_Sergej\City.mdf;Integrated Security=True";
            SqlConnection sql = new SqlConnection(connectionString);
            string querry = "Insert into IconsTable(Icons) VALUES(@Icons)";
            SqlCommand command = new SqlCommand(querry, sql);

            command.Parameters.AddWithValue("@Icons", "New");
            sql.Open();
            var atsakymas = command.ExecuteNonQuery();
            if (atsakymas < 0)
            {
                MessageBox.Show("Error");
            }

            sql.Close();

        }

        private void IconButton1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pc\source\repos\BaigiamasisDarbas_Orai_Sergej\BaigiamasisDarbas_Orai_Sergej\City.mdf;Integrated Security=True";
            SqlConnection sql = new SqlConnection(connectionString);
            string querry = "DELETE FROM IconsTable";
            SqlCommand command = new SqlCommand(querry, sql);
            sql.Open();
            var atsakymas = command.ExecuteNonQuery();

            if (atsakymas < 0)
            {
                MessageBox.Show("Error");
            }
            sql.Close();

            IconChangeVar = null;

            getWeather();
            getForcast();

        }

        private void EnterButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                cityName = CityText.Text;
                getWeather();
                getForcast();

            }
            catch (WebException ex)
            {

                MessageBox.Show("Try again");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not expected exception");
            }

        }


    }
}
