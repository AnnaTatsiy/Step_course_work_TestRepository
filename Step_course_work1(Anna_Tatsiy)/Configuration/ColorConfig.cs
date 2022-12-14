using System.Data.Entity.ModelConfiguration;
using Step_course_work1_Anna_Tatsiy_.Models;

namespace Step_course_work1_Anna_Tatsiy_.Configuration
{
    internal class ColorConfig : EntityTypeConfiguration<Color>
    {
        public ColorConfig()
        {
            HasKey(c => c.Id);

            Property(c => c.NameColor)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsVariableLength();
        }
    }
}
