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

        async Task<Plugin.Geolocator.Abstractions.Position> getLocation() {
            try
            {
                var Position = await CrossGeolocator.Current.GetPositionAsync(10000);
                return Position;
            }
            catch {
                return null;
            }
        }
    }

}
