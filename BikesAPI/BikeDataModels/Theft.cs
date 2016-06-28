namespace BikeDataModels
{
    using System;
    public partial class Theft
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Street { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string IsMotorized { get; set; }
        public string Bikemodel { get; set; }
        public int District_id { get; set; }
        public string Neighbourhood { get; set; }
        public string Color { get; set; }
    }
}
