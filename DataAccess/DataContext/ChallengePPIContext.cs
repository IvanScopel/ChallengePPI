using Entities;
using Entities.Activos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataContext
{
    public partial class ChallengePPIContext : DbContext
    {
        public ChallengePPIContext() { }

        public ChallengePPIContext(DbContextOptions<ChallengePPIContext> options) : base(options) { }

        public virtual DbSet<Activo> Activos { get; set; }
        public virtual DbSet<Orden> Ordenes { get; set; }
        public virtual DbSet<TipoActivo> TipoActivos { get; set; }
        public virtual DbSet<TipoEstado> TipoEstados { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (options.IsConfigured == false)
                options.UseSqlServer("Server=localhost;Database=ChallengePPIDatabase;Trusted_Connection=True;TrustServerCertificate=True");
         
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }

            modelBuilder.Entity<Orden>().HasOne(e => e.Activo);
            modelBuilder.Entity<Orden>().HasOne(e => e.Estado);

            modelBuilder.Entity<Activo>().HasDiscriminator<string>("Tipo").HasValue<Bono>("Bono").HasValue<Accion>("Accion").HasValue<FCI>("FCI");
            modelBuilder.Entity<Activo>().HasOne(e => e.TipoActivo);
            
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}



