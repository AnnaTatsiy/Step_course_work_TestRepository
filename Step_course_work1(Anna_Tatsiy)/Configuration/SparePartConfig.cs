using System.Data.Entity.ModelConfiguration;
using Step_course_work1_Anna_Tatsiy_.Models;

namespace Step_course_work1_Anna_Tatsiy_.Configuration
{
    internal class SparePartConfig : EntityTypeConfiguration<SparePart>
    {
        public SparePartConfig() {

            HasKey(s => s.Id);

            Property(s => s.NameSparePart)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsVariableLength();

            Property(s => s.Price).IsRequired();

        }
    }
}
