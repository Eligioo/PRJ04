using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace Project4.GeoLocation
{
    /// <summary>
    /// Class that contains all geo methods we are using
    /// </summary>
    public class Geo
    {
        private Geocoder geoCoder;
        public Tuple<string, string> Location;
        private Plugin.Geolocator.Abstractions.Position Position;
        private IEnumerable<string> possibleAddresses;
        public Geo()
        {
            geoCoder = new Geocoder();
        }
        /// <summary>
        /// requests current location and returns it as a tuple of strings
        /// </summary>
        /// <returns></returns>
        public async Task<Tuple<string, string>> GetLocation() {
            try
            {
                this.Position = await CrossGeolocator.Current.GetPositionAsync(10000);
                Location = new Tuple<string, string>(Position.Latitude.ToString().Replace(",", "."), Position.Longitude.ToString().Replace(",", "."));
                return Location;
            }
            catch {
                return null;
            }
        }
        /// <summary>
        /// requests current location and returns it as a tuple of doubles
        /// </summary>
        /// <returns></returns>
        public async Task<Tuple<double, double>> GetLocationDouble()
        {
            try
            {
                this.Position = await CrossGeolocator.Current.GetPositionAsync(10000);
                var Location = new Tuple<double, double>(Position.Latitude, Position.Longitude);
                return Location;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// requests current location and returns a task of string with the best known address
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAddress() {
            try
            {
                possibleAddresses = await geoCoder.GetAddressesForPositionAsync(new Position(this.Position.Latitude, this.Position.Longitude));
                return possibleAddresses.First().ToString();
            }
            catch {
                return $"{this.Position.Latitude},{this.Position.Longitude}";
            }
        }
        /// <summary>
        /// needs location and returns a task of string with the best known address
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public async Task<string> GetAddress(double latitude, double longitude )
        {
            try
            {
                possibleAddresses = await geoCoder.GetAddressesForPositionAsync(new Position(latitude, longitude));
                return possibleAddresses.First().ToString();
            }
            catch
            {
                return $"{latitude.ToString().Replace(",", ".")},{longitude.ToString().Replace(",", ".")}";
            }
        }
        public string generateNavigation(string navloc1, string navloc2)
        {
            if (Device.OS == TargetPlatform.iOS)
            {
                return string.Format("http://maps.apple.com/?saddr={0}&daddr={1}", navloc1, navloc2);
            } else
            {
                return string.Format("http://maps.google.com/maps?saddr={0}&daddr={1}", navloc1, navloc2);
            }
        }
    }

}
