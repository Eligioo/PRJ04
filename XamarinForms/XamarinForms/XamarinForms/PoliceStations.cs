using BikeDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net.Http;
using Newtonsoft.Json;

namespace Project4
{
    public class PoliceStations : IEnumerable<PoliceStation>
    {
        private IEnumerable<PoliceStation> stations;

        public PoliceStations()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var download = client.GetStringAsync("http://145.24.222.220/v2/PoliceStations").Result;
                    stations = JsonConvert.DeserializeObject<IEnumerable<PoliceStation>>(download);
                }
            }
            catch
            {

            }
        }

        public IEnumerator<PoliceStation> GetEnumerator()
        {
            return stations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Recieve the nearest police station based on you GPS-location.
        /// </summary>
        /// <param name="latitude">double containing the latitude</param>
        /// <param name="longtitude">double containing the longtitude</param>
        /// <returns>Returns the nearest police station</returns>
        public PoliceStation GetNearestStation(double latitude, double longtitude)
        {
            var sorted = stations
                .OrderBy(station =>Math.Pow(Math.Abs(longtitude - station.Longitude), 2) + Math.Pow(Math.Abs(latitude - station.Latitude), 2));

            return sorted.FirstOrDefault();
        }
    }
}
