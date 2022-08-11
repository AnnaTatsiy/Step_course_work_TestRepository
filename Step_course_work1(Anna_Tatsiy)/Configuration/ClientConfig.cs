using System.Data.Entity.ModelConfiguration;
using Step_course_work1_Anna_Tatsiy_.Models;

namespace Step_course_work1_Anna_Tatsiy_.Configuration
{
    internal class ClientConfig : EntityTypeConfiguration<Client>
    {
        public ClientConfig()
        {
            HasKey(c => c.Id);

            Property(c => c.Passport)
                .IsRequired()
                .HasMaxLength(11)
                .IsVariableLength();

            Property(c => c.DateOfBirth)
                .IsRequired();

            Property(c => c.Registration)
                .IsRequired()
                .IsVariableLength();
        }
    }
}
