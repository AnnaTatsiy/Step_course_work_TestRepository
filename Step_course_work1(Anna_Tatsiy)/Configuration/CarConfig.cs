using System.Data.Entity.ModelConfiguration;
using Step_course_work1_Anna_Tatsiy_.Models;

namespace Step_course_work1_Anna_Tatsiy_.Configuration
{
    internal class CarConfig : EntityTypeConfiguration<Car>
    {
        public CarConfig()
        {
            HasKey(c => c.Id);

            Property(c => c.YearOfRelease)
                .IsRequired();

            Property(c => c.StateNumber)
                .IsRequired()
                .HasMaxLength(20)
                .IsVariableLength();

        }
    }
}
