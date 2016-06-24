namespace BikeDataModels
{
    using System;
    public partial class BikeContainer
    {
        public int Id { get; set; }
        public double XLocation { get; set; }
        public double YLocation { get; set; }
        public string Area { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
