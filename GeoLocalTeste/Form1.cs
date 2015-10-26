using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Xml;
using System.Web;
using System.Reflection;
using Geocoding.Tests;

namespace GeoLocalTeste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //("AIzaSyCtci7zbdpXxUxczJPy9q2gD1t1vwVM2uo");
        private Coordenadas ResCoord(string endereco)
        {
            Coordenadas coord = new Coordenadas();
            Geocoding.IGeocoder geocoder = new Geocoding.Google.GoogleGeocoder() { };
            Geocoding.Address[] addresses = geocoder.Geocode(endereco).ToArray();
            foreach (Geocoding.Address adrs in addresses)
            {
                if (adrs.Coordinates.Latitude.ToString()!="")
                {
                    coord.Latitude = adrs.Coordinates.Latitude.ToString();
                }
                if (adrs.Coordinates.Longitude.ToString() != "")
                {
                    coord.Longitude = adrs.Coordinates.Longitude.ToString();
                }
            }
            return coord;

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            Coordenadas resultado = ResCoord(tbEndereco.Text);
            tbLatitude.Text = resultado.Latitude;
            tbLongitude.Text = resultado.Longitude;
            resultado.Latitude = "";
            resultado.Longitude = "";
        }
    }
}
