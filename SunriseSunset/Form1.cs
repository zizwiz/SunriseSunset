using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Metar_Taf_Viewer.common_data;

namespace SunriseSunset
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbobx_airport_info.SelectedIndex = 34;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //Get the data file from resources and write to file in same dir as the app.
            File.WriteAllText("airport_data.xml", Properties.Resources.airport_data);

            Text += " : v" + Assembly.GetExecutingAssembly().GetName().Version; // put in the version number

        }

        private void btn_calc_Click(object sender, System.EventArgs e)
        {
            rchtxbx_output.Text = "";

            double tsunrise, tsunset;

            string[] data = airport_data.GetAirportInfo(cmbobx_airport_info.Text);
            double lat = double.Parse(data[4]);
            double lng = double.Parse(data[6]);


            int year = dateTimePicker1.Value.Year; 
            int month = dateTimePicker1.Value.Month;
            int day = dateTimePicker1.Value.Day;

            ///////////////////////////////////////////////////////////////////////////////
            /// Standard Sunrise and Sunset
            /////////////////////////////////////////////////////////////////////////////// 
            // Parameters : year - month - day - lat (decimal) - long (decimal)
            Sunriset.SunriseSunset(year, month, day, lat, lng, out tsunrise, out tsunset);

            rchtxbx_output.SelectionFont = new Font("Ariel", 8, FontStyle.Underline);
            rchtxbx_output.AppendText("Standard Sunrise and Sunset\r");

            TimeSpan sunriseTime = TimeSpan.FromHours(tsunrise);
            string sunriseTimeString = sunriseTime.ToString(@"hh\:mm\:ss");
            rchtxbx_output.AppendText("Sunrise = " + sunriseTimeString + "\r");

            TimeSpan sunsetTime = TimeSpan.FromHours(tsunset);
            string sunsetTimeString = sunsetTime.ToString(@"hh\:mm\:ss");
            rchtxbx_output.AppendText("Sunset = " + sunsetTimeString + "\r\r");
            
            ///////////////////////////////////////////////////////////////////////////////
            /// Civil Twilight Sunrise and Sunset
            /////////////////////////////////////////////////////////////////////////////// 
            Sunriset.CivilTwilight(year, month, day, lat, lng, out tsunrise, out tsunset);

            rchtxbx_output.SelectionFont = new Font("Ariel", 8, FontStyle.Underline);
            rchtxbx_output.AppendText("Civil Twilight\r");

            TimeSpan CTsunriseTime = TimeSpan.FromHours(tsunrise);
            string CTsunriseTimeString = CTsunriseTime.ToString(@"hh\:mm\:ss");
            rchtxbx_output.AppendText("Sunrise = " + CTsunriseTimeString + "\r");

            TimeSpan CTsunsetTime = TimeSpan.FromHours(tsunset);
            string CTsunsetTimeString = CTsunsetTime.ToString(@"hh\:mm\:ss");
            rchtxbx_output.AppendText("Sunset = " + CTsunsetTimeString + "\r\r");

            ///////////////////////////////////////////////////////////////////////////////
            /// Nautical Twilight Sunrise and Sunset
            ///////////////////////////////////////////////////////////////////////////////
            Sunriset.NauticalTwilight(year, month, day, lat, lng, out tsunrise, out tsunset);

            rchtxbx_output.SelectionFont = new Font("Ariel", 8, FontStyle.Underline);
            rchtxbx_output.AppendText("Nautical Twilight\r");

            TimeSpan NTsunriseTime = TimeSpan.FromHours(tsunrise);
            string NTsunriseTimeString = NTsunriseTime.ToString(@"hh\:mm\:ss");
            rchtxbx_output.AppendText("Sunrise = " + NTsunriseTimeString + "\r");

            TimeSpan NTsunsetTime = TimeSpan.FromHours(tsunset);
            string NTsunsetTimeString = NTsunsetTime.ToString(@"hh\:mm\:ss");
            rchtxbx_output.AppendText("Sunset = " + NTsunsetTimeString + "\r\r");



            ///////////////////////////////////////////////////////////////////////////////
            /// Astronomical Twilight Sunrise and Sunset
            ///////////////////////////////////////////////////////////////////////////////
            Sunriset.AstronomicalTwilight(year, month, day, lat, lng, out tsunrise, out tsunset);

            rchtxbx_output.SelectionFont = new Font("Ariel", 8, FontStyle.Underline);
            rchtxbx_output.AppendText("Astronomical Twilight\r");

            TimeSpan ATsunriseTime = TimeSpan.FromHours(tsunrise);
            string ATsunriseTimeString = ATsunriseTime.ToString(@"hh\:mm\:ss");
            rchtxbx_output.AppendText("Sunrise = " + ATsunriseTimeString + "\r");

            TimeSpan ATsunsetTime = TimeSpan.FromHours(tsunset);
            string ATsunsetTimeString = ATsunsetTime.ToString(@"hh\:mm\:ss");
            rchtxbx_output.AppendText("Sunset = " + ATsunsetTimeString + "\r\r");
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            rchtxbx_output.Text = "";
        }
    }
}
