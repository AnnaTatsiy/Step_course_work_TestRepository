using System.Data.Entity.ModelConfiguration;
using Step_course_work1_Anna_Tatsiy_.Models;

namespace Step_course_work1_Anna_Tatsiy_.Configuration
{
    internal class RepairConfig : EntityTypeConfiguration<Repair>
    {
        public RepairConfig()
        {
            HasKey(r => r.Id);

            Property(r => r.IsFixed)
                .IsRequired();

            Property(r => r.DateOfDetection)
                 .IsRequired();

            Property(r => r.DateOfCorrection)
                .IsRequired();
        }
    }
}
