using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;


namespace Project4.GeoLocation
{
    public class Geo{
        Geocoder geoCoder = new Geocoder();
        public string Longitude;
        public string Latitude;
        public Plugin.Geolocator.Abstractions.Position Position;
        public async Task<Plugin.Geolocator.Abstractions.Position> GetLocation() {
            try
            {
                var Position = await CrossGeolocator.Current.GetPositionAsync(10000);
                this.Longitude = Position.Longitude.ToString().Replace(",", ".");
                this.Latitude = Position.Latitude.ToString().Replace(",", ".");
                this.Position = Position;
                return Position;
            }
            catch {
                return null;
            }
        }

        public async Task<string> GetAddress() {
            try
            {
                var location = new Position(this.Position.Latitude, this.Position.Longitude);
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(location);
                return possibleAddresses.First().ToString();
            }
            catch {
                return $"{this.Position.Latitude},{this.Position.Longitude}";
            }
        }
    }

}
