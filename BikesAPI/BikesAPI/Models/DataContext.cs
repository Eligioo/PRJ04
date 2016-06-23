namespace BikesAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<BikeContainer> BikeContainers { get; set; }
        public virtual DbSet<Theft> Thefts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BikeContainer>()
                .Property(e => e.Area)
                .IsUnicode(false);

            modelBuilder.Entity<BikeContainer>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Theft>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Theft>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Theft>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Theft>()
                .Property(e => e.IsMotorized)
                .IsUnicode(false);

            modelBuilder.Entity<Theft>()
                .Property(e => e.Bikemodel)
                .IsUnicode(false);

            modelBuilder.Entity<Theft>()
                .Property(e => e.Neighbourhood)
                .IsUnicode(false);

        }
    }
}
