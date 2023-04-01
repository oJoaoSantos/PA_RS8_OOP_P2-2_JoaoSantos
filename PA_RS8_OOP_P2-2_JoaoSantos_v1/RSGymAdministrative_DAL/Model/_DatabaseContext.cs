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

            modelBuilder.Entity<Request>()
            .HasRequired(r => r.PersonalTrainer)
            .WithMany()
            .HasForeignKey(r => r.PersonalTrainerID)
            .WillCascadeOnDelete(false);

            // A segunda linha "modelBuilder.Entity<Request>()" está criando uma nova entidade no modelo de dados chamada "Request".
            // A terceira linha ".HasRequired(r => r.PersonalTrainer)" está definindo uma restrição para a entidade "Request". Isso significa que cada registro na tabela de "Request" deve ter um relacionamento com um "PersonalTrainer".
            // A quarta linha ".WithMany()" está especificando que cada registro em "PersonalTrainer" pode estar associado a vários registros em "Request". Isso é chamado de relacionamento de "muitos para um".
            // A quinta linha ".HasForeignKey(r => r.PersonalTrainerID)" está especificando que a chave estrangeira do relacionamento é o campo "PersonalTrainerID" na tabela de "Request".
            // A sexta linha ".WillCascadeOnDelete(false);" está especificando que, se um "PersonalTrainer" for excluído, os registros associados em "Request" não serão excluídos automaticamente. Isso é importante para manter a integridade dos dados em outras partes do aplicativo.
        }

        public DbSet<ZipCode> ZipCode { get; set; }
        public DbSet<PersonalTrainer> PersonalTrainer { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<User> User { get; set; }

    }
}
