namespace BikeDataModels
{
    public partial class thefts
    {
        public int id { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string street { get; set; }
        public string code { get; set; }
        public string type { get; set; }
        public string ismotorized { get; set; }
        public string bikemodel { get; set; }
        public int district_id { get; set; }
        public string neighbourhood { get; set; }
    }
}
