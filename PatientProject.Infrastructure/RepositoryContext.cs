using Microsoft.EntityFrameworkCore;
using PatientProject.Core.Entities;

namespace PatientProject.Infrastructure
{
    internal class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options) => Database.Migrate();

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Gender> Genders { get; set; }
    }
}
