namespace BikesAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Theft")]
    public partial class Theft
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime DateTime { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string Street { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string Code { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string Type { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(255)]
        public string IsMotorized { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(255)]
        public string Bikemodel { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int District_id { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(255)]
        public string Neighbourhood { get; set; }
    }
}
