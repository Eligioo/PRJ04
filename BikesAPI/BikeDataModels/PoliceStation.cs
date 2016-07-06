using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//{
//      "seq": "A",
//      "titel": "Doelwater (Hoofdbureau)",
//      "latitude": "51.9232176",
//      "longitude": "4.47922600000004",
//      "bezoekAdres": "Doelwater 5, Rotterdam",
//      "meerInformatie": "Meer informatie",
//      "URL": "/mijn-buurt/politiebureaus/07/doelwater.html?geoquery=rotterdam&distance=5.0"
//    }

namespace BikeDataModels
{
    /// <summary>
    /// model is in dutch because the dataset is in dutch
    /// </summary>
    public class PoliceStation
    {
        /// <summary>
        /// Name of the police station
        /// </summary>
        public string Titel { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string BezoekAdres { get; set; }
        public string URL { get; set; }
    }
}
