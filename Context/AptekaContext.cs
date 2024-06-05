using Apteka.Models;
using Apteka.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Apteka.Context
{
    public class AptekaContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicamens { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        public AptekaContext() 
        {

        }

        public AptekaContext(DbContextOptions<AptekaContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Refleksja
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AptekaContext).Assembly);

            //modelBuilder.ApplyConfiguration(new DoctorEfConfig());

            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Doctor>(x =>
            //{
            //    x.HasKey(y=>y.IdDoctor);
            //    x.Property(y=>y.FirstName).IsRequired().HasMaxLength(100);
            //});
        }
    }
}
//dotnet ef migrations add InitialMigration
//dotnet ef database update