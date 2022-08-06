using System.Data.Entity.ModelConfiguration;
using Step_course_work1_Anna_Tatsiy_.Models;

namespace Step_course_work1_Anna_Tatsiy_.Configuration
{
    internal class SpecializationConfig : EntityTypeConfiguration<Specialization>
    {
        public SpecializationConfig()
        {
            HasKey(s => s.Id);

            Property(m => m.NameSpecialization)
                .IsRequired()
                .HasMaxLength(40)
                .IsVariableLength();
        }
    }
}
