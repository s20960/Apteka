using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apteka.Models.Configurations
{
    public class DoctorEfConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(y => y.IdDoctor);
            builder.Property(y => y.FirstName).IsRequired().HasMaxLength(100);
        }
    }
}
