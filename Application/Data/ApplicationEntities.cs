using Data.Infrastructure;
using Data.Mapping;
using Microsoft.AspNet.Identity.EntityFramework;
using Model;
using System.Data.Entity;

namespace Data
{
    public class ApplicationEntities : IdentityDbContext<ApplicationUser>, IUnitOfWork
    {
        public ApplicationEntities()
            : base("ApplicationEntities")
        {
        }

        public DbSet<Student> Students { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new StudentMap());
        }
    }
}