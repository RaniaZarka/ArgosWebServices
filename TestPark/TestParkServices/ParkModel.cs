namespace TestParkServices
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ParkModel : DbContext
    {
        public ParkModel()
            : base("name=ParkModel")
        {
        }

        public virtual DbSet<Animaux> Animauxes { get; set; }
        public virtual DbSet<AnimauxType> AnimauxTypes { get; set; }
        public virtual DbSet<Papa> Papas { get; set; }
        public virtual DbSet<PapaAnimaux> PapaAnimauxes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animaux>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Animaux>()
                .HasMany(e => e.PapaAnimauxes)
                .WithRequired(e => e.Animaux)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AnimauxType>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<AnimauxType>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<AnimauxType>()
                .Property(e => e.EndangeredLevel)
                .IsUnicode(false);

            modelBuilder.Entity<AnimauxType>()
                .HasMany(e => e.Animauxes)
                .WithRequired(e => e.AnimauxType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Papa>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Papa>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
