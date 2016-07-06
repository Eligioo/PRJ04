﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace Project4.GeoLocation
{
    public class Geo{
        private Geocoder geoCoder;
        public Tuple<string, string> Location;
        private Plugin.Geolocator.Abstractions.Position Position;
        private IEnumerable<string> possibleAddresses;
        public Geo()
        {
            geoCoder = new Geocoder();
        }
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
