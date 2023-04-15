using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RSGymAdministrative_DAL.Model
{
    public class _DatabaseContext : DbContext
    {
        public _DatabaseContext() : base("RSGymDataBase_JPS")
        { 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Request>()
            .HasRequired(r => r.PersonalTrainer)
            .WithMany()
            .HasForeignKey(r => r.PersonalTrainerID)
            .WillCascadeOnDelete(false);
        }

        public DbSet<ZipCode> ZipCode { get; set; }
        public DbSet<PersonalTrainer> PersonalTrainer { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<User> User { get; set; }

    }
}
