namespace BikesAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BikeContainer")]
    public partial class BikeContainer
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public double XLocation { get; set; }

        [Key]
        [Column(Order = 2)]
        public double YLocation { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string Area { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string Street { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StreetNumber { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "date")]
        public DateTime Date { get; set; }
    }
}
