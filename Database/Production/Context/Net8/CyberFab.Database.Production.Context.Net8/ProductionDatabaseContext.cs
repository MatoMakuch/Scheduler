using CyberFab.Database.Production.Models.Net8;
using Microsoft.EntityFrameworkCore;

namespace CyberFab.Database.Production.Context.Net8
{	
    public partial class ProductionDatabaseContext : DbContext
    {
        private const string ConnectionStringEnvironmentVariable = "CYBERFAB_DATABASE_PRODUCTION_CONNECTION_STRING";

        public DbSet<Blueprint> Blueprints { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<MaterialType> MaterialTypes { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Template> Templates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Retrieve the connection string from an environment variable.
            // var connectionString = Environment.GetEnvironmentVariable(ConnectionStringEnvironmentVariable);
            var connectionString = "Server=.\\SQLEXPRESS;Database=production;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

            // Use the connection string.
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Blueprint

            modelBuilder.Entity<Blueprint>()
                .HasKey(Blueprint => Blueprint.Name);

            modelBuilder.Entity<Blueprint>()
                .HasOne(Blueprint => Blueprint.SmallImage)
                .WithMany(image => image.TemplateSmallImages)
                .HasForeignKey(Blueprint => Blueprint.SmallImageName);

            modelBuilder.Entity<Blueprint>()
                .HasOne(Blueprint => Blueprint.LargeImage)
                .WithMany(image => image.TemplateLargeImages)
                .HasForeignKey(Blueprint => Blueprint.LargeImageName);


            #endregion

            #region Image

            modelBuilder.Entity<Image>()
                .HasKey(image => image.Name);

            #endregion

            #region Material

            modelBuilder.Entity<Material>()
                .HasKey(material => new
                {
                    material.MaterialTypeName,
                    material.Specification
                });

            modelBuilder.Entity<Material>()
                .HasOne(material => material.MaterialType)
                .WithMany(materialType => materialType.Materials)
                .HasForeignKey(material => material.MaterialTypeName);

            #endregion

            #region Material type

            modelBuilder.Entity<MaterialType>()
                .HasKey(MaterialType => MaterialType.Name);

            #endregion

            #region Stock

            modelBuilder.Entity<Stock>()
                .HasKey(Stock => Stock.SerialNumber);

            modelBuilder.Entity<Stock>()
                .HasOne(Stock => Stock.Template)
                .WithMany(Template => Template.Stocks)
                .HasForeignKey(Stock => new
                {
                    Stock.MaterialTypeName,
                    Stock.MaterialSpecificationName,
                    Stock.BlueprintName
                });

            modelBuilder.Entity<Stock>()
                .HasOne(Stock => Stock.Supplier)
                .WithMany(Supplier => Supplier.Stocks)
                .HasForeignKey(Stock => Stock.SupplierName);

            #endregion

            #region Supplier

            modelBuilder.Entity<Supplier>()
                .HasKey(Supplier => Supplier.Name);

            #endregion

            #region Template

            modelBuilder.Entity<Template>()
                .HasKey(Template => new
                {
                    Template.BlueprintName,
                    Template.MaterialTypeName,
                    Template.MaterialSpecificationName
                });

            modelBuilder.Entity<Template>()
                .HasOne(Template => Template.Blueprint)
                .WithMany(Blueprint => Blueprint.Templates)
                .HasForeignKey(Template => Template.BlueprintName);

            modelBuilder.Entity<Template>()
                .HasOne(Template => Template.Material)
                .WithMany(Material => Material.Templates)
                .HasForeignKey(Template => new
                {
                    Template.MaterialTypeName,
                    Template.MaterialSpecificationName
                });

            #endregion
        }
    }
}
