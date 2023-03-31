using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RSGymAdministrative_DAL.Model
{
    public class _DatabaseContext : DbContext
    {
        public _DatabaseContext() : base("RSGymDataBase_JPSv1")
        { 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //public DbSet<ZipCode> ZipCode { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<PersonalTrainer> PersonalTrainer { get; set; }
        public DbSet<Request> Request { get; set; }
    }
}
