namespace BikesAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MostBikeContainer
    {
        public int Count { get; set; }
        public string Neighborhoods { get; set; }
    }
}
