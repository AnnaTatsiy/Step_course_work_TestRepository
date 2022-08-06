using System.Data.Entity.ModelConfiguration;
using Step_course_work1_Anna_Tatsiy_.Models;

namespace Step_course_work1_Anna_Tatsiy_.Configuration
{
    internal class CarBrandConfig: EntityTypeConfiguration<CarBrand>
    {
        public CarBrandConfig()
        {
            HasKey(c => c.Id);

            Property(c=>c.NameCarBrand)
                .IsRequired()
                .IsVariableLength();
        }
    }
}
