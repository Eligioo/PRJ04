using System.Collections.Generic;

namespace BikeDataModels
{
    public class TheftAndTrommel
    {
        public int Thefts { get; set; }
        public int Trommels { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }

    public class CombinationofTheftTrommelAreaMonth
    {
        public string Neighbourhood { get; set; }
        public IEnumerable<TheftAndTrommel> Rows {get;set;}
        
    }
}
