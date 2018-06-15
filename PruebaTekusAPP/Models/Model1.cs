namespace PruebaTekusAPP.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Servicios> Servicios { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<ServiciosCliente> ServiciosCliente { get; set; }
        public virtual DbSet<PaisServicio> PaisServicio { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Clientes>()
            //    .HasMany(e => e.ServiciosCliente)
            //    .WithRequired(e => e.Clientes)
            //    .HasForeignKey(e => e.IdCliente)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Servicios>()
            //    .Property(e => e.ValorHora)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Servicios>()
            //    .HasMany(e => e.ServiciosCliente)
            //    .WithRequired(e => e.Servicios)
            //    .HasForeignKey(e => e.IdServicio)
            //    .WillCascadeOnDelete(false);
        }
    }
}
