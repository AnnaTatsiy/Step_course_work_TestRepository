using System.Data.Entity.ModelConfiguration;
using Step_course_work1_Anna_Tatsiy_.Models;

namespace Step_course_work1_Anna_Tatsiy_.Configuration
{
    internal class WorkerConfig : EntityTypeConfiguration<Worker>
    {
        public WorkerConfig()
        {
            HasKey(w => w.Id);

            Property(w => w.IdPerson)
                .IsRequired();

            Property(w => w.IdSpecialization)
                .IsRequired();

            Property(w => w.Experience)
                .IsRequired();

            Property(w => w.WorkersСategory)
                .IsRequired();

        }
    }
}
