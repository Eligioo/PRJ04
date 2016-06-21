namespace BikesAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using BikeDataModels;
    public partial class Model : DbContext
    {
        public Model()
            : base("name=bikeModel")
        {
        }

        public virtual DbSet<thefts> thefts { get; set; }
        public virtual DbSet<trommel> trommel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<thefts>()
                .Property(e => e.date)
                .IsUnicode(false);

            modelBuilder.Entity<thefts>()
                .Property(e => e.time)
                .IsUnicode(false);

            modelBuilder.Entity<thefts>()
                .Property(e => e.street)
                .IsUnicode(false);

            modelBuilder.Entity<thefts>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<thefts>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<thefts>()
                .Property(e => e.ismotorized)
                .IsUnicode(false);

            modelBuilder.Entity<thefts>()
                .Property(e => e.bikemodel)
                .IsUnicode(false);

            modelBuilder.Entity<thefts>()
                .Property(e => e.neighbourhood)
                .IsUnicode(false);

            modelBuilder.Entity<trommel>()
                .Property(e => e.date)
                .IsUnicode(false);

            modelBuilder.Entity<trommel>()
                .Property(e => e.area)
                .IsUnicode(false);

            modelBuilder.Entity<trommel>()
                .Property(e => e.neighbourhood)
                .IsUnicode(false);

            modelBuilder.Entity<trommel>()
                .Property(e => e.street)
                .IsUnicode(false);
        }
    }
}
