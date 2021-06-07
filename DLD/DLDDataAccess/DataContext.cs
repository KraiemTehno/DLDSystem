using DLD.DataAccess.Interfaces;
using DLDBussinesLayer.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DLD.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DbConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<ShiftPoint> ShiftPoints { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<ImagePage> ImagePages { get; set; }
        public virtual DbSet<ReportItem> ReportItems { get; set; }
        public virtual DbSet<Investigation> Investigations { get; set; }
    }
}
