using pfa_mvc5.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace pfa_mvc5.DAL
{
    public class PfaContext : DbContext
    {
        public PfaContext() : base("PFA")
        {

        }
        public DbSet<Auth> auth { get; set; }
        public DbSet<Chef_dep> chef_departement { get; set; }
        public DbSet<classes> classes {get;set;}
        public DbSet<competence> competences {get;set;}
        public DbSet<Disponibilité> Disponibilités{get;set;}
        public DbSet<Etudiant> etudiant {get;set;}
        public DbSet<matiere> matieres {get;set;}
        public DbSet<planning> planning {get;set;}
        public DbSet< Professeur> Professeurs {get;set;}
        public DbSet<Recrutement> Recrutement {get;set;}
        public DbSet<Sceance> sceance {get;set;}
        public DbSet<Semestre> Semestre {get;set;}
        public DbSet<type_prof> type_prof {get;set;}
       
protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}