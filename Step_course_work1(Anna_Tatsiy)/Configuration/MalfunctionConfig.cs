using System.Data.Entity.ModelConfiguration;
using Step_course_work1_Anna_Tatsiy_.Models;

namespace Step_course_work1_Anna_Tatsiy_.Configuration
{
    internal class MalfunctionConfig : EntityTypeConfiguration<Malfunction>
    {
        public MalfunctionConfig() {

            HasKey(m => m.Id);

            Property(m => m.NameMalfunction)
                    .IsRequired()
                    .IsVariableLength();

        }
    }
}
