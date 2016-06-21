namespace BikeDataModels
{
    using System;
    public partial class trommel
    {
        public int id { get; set; }
        public double x_location { get; set; }
        public double y_location { get; set; }
        public string date { get; set; }
        public string area { get; set; }
        public string neighbourhood { get; set; }
        public string street { get; set; }
        public int street_number { get; set; }
        public DateTime datetime { get; set; }
    }
}
