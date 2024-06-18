using CyberFab.Database.Automation.Models.Net8;
using Microsoft.EntityFrameworkCore;

namespace CyberFab.Database.Automation.Context.Net8
{	
    public partial class AutomationDatabaseContext : DbContext
    {
        private const string ConnectionStringEnvironmentVariable = "CYBERFAB_DATABASE_AUTOMATION_CONNECTION_STRING";

        public DbSet<Item> Items { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Operation> Operations { get; set; }

        public DbSet<OperationItemInput> OperationItemInputs { get; set; }

        public DbSet<OperationItemOutput> OperationItemOutputs { get; set; }

        public DbSet<ScheduledOperation> ScheduledOperations { get; set; }

        public DbSet<WorkStation> WorkStations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Retrieve the connection string from an environment variable.
            // var connectionString = Environment.GetEnvironmentVariable(ConnectionStringEnvironmentVariable);
            var connectionString = "Server=.\\SQLEXPRESS;Database=automation;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

            // Use the connection string.
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Item

            modelBuilder.Entity<Item>()
               .HasKey(Item => Item.Name);

            #endregion

            #region Job

            modelBuilder.Entity<Job>()
                .HasKey(Job => Job.Name);

            #endregion

            #region Job Operation

            modelBuilder.Entity<JobOperation>()
                .HasKey(JobOperation => new
                {
                    JobOperation.JobName,
                    JobOperation.OperationName
                });

            modelBuilder.Entity<JobOperation>()
                .HasOne(JobOperation => JobOperation.Job)
                .WithMany(Job => Job.JobOperations)
                .HasForeignKey(JobOperation => JobOperation.JobName);

            modelBuilder.Entity<JobOperation>()
                .HasOne(JobOperation => JobOperation.Operation)
                .WithMany(Operation => Operation.JobOperations)
                .HasForeignKey(JobOperation => JobOperation.OperationName);

            #endregion

            #region Operation

            modelBuilder.Entity<Operation>()
                .HasKey(Operation => Operation.Name);

            #endregion

            #region Operation Item Input

            modelBuilder.Entity<OperationItemInput>()
                .HasKey(OperationItemInput => new
                {
                    OperationItemInput.ItemName,
                    OperationItemInput.OperationName
                });

            modelBuilder.Entity<OperationItemInput>()
                .HasOne(OperationItemInput => OperationItemInput.Item)
                .WithMany(Item => Item.OperationItemInputs)
                .HasForeignKey(OperationItemInput => OperationItemInput.ItemName);

            modelBuilder.Entity<OperationItemInput>()
                .HasOne(OperationItemInput => OperationItemInput.Operation)
                .WithMany(Operation => Operation.OperationItemInputs)
                .HasForeignKey(OperationItemInput => OperationItemInput.OperationName);

            #endregion

            #region Operation Item Output

            modelBuilder.Entity<OperationItemOutput>()
                .HasKey(OperationItemOutput => new
                {
                    OperationItemOutput.ItemName,
                    OperationItemOutput.OperationName
                });

            modelBuilder.Entity<OperationItemOutput>()
                .HasOne(OperationItemOutput => OperationItemOutput.Item)
                .WithMany(Item => Item.OperationItemOutputs)
                .HasForeignKey(OperationItemOutput => OperationItemOutput.ItemName);

            modelBuilder.Entity<OperationItemOutput>()
                .HasOne(OperationItemOutput => OperationItemOutput.Operation)
                .WithMany(Operation => Operation.OperationItemOutputs)
                .HasForeignKey(OperationItemOutput => OperationItemOutput.OperationName);

            #endregion

            #region Operation Workstation

            modelBuilder.Entity<OperationWorkstation>()
               .HasKey(OperationWorkstation => new
               {
                   OperationWorkstation.OperationName,
                   OperationWorkstation.WorkstationName
               });

            modelBuilder.Entity<OperationWorkstation>()
                .HasOne(OperationWorkstation => OperationWorkstation.Operation)
                .WithMany(Operation => Operation.OperationWorkstations)
                .HasForeignKey(OperationWorkstation => OperationWorkstation.OperationName);

            modelBuilder.Entity<OperationWorkstation>()
                .HasOne(OperationWorkstation => OperationWorkstation.Operation)
                .WithMany(WorkStation => WorkStation.OperationWorkstations)
                .HasForeignKey(OperationWorkstation => OperationWorkstation.OperationName);

            #endregion

            #region Scheduled Operation

            modelBuilder.Entity<ScheduledOperation>()
                .HasKey(ScheduledOperation => new
                {
                    ScheduledOperation.OperationName,
                    ScheduledOperation.WorkstationName,
                    ScheduledOperation.Start
                });

            modelBuilder.Entity<ScheduledOperation>()
                .HasOne(ScheduledOperation => ScheduledOperation.OperationWorkstation)
                .WithMany(OperationWorkstation => OperationWorkstation.ScheduledOperations)
                .HasForeignKey(ScheduledOperation => new
                {
                    ScheduledOperation.WorkstationName,
                    ScheduledOperation.OperationName
                });

            modelBuilder.Entity<ScheduledOperation>()
                .HasOne(ScheduledOperation => ScheduledOperation.Job)
                .WithMany(Job => Job.ScheduledOperations)
                .HasForeignKey(ScheduledOperation => ScheduledOperation.JobName);

            #endregion

            #region Workstation

            modelBuilder.Entity<WorkStation>()
              .HasKey(WorkStation => WorkStation.Name);

            #endregion
        }
    }
}
