using System.Data.Entity.ModelConfiguration;
using Step_course_work1_Anna_Tatsiy_.Models;

namespace Step_course_work1_Anna_Tatsiy_.Configuration
{
    internal class PersonConfig: EntityTypeConfiguration<Person>
    {
        public PersonConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.Name)//Имя
                .IsRequired()
                .HasMaxLength(30)
                .IsVariableLength();

            Property(p => p.Surename)//Фамилия
                .IsRequired()
                .HasMaxLength(30)
                .IsVariableLength();

            Property(p => p.Patronymic) //Отчество
               .IsRequired()
               .HasMaxLength(30)
               .IsVariableLength();

        }
    }
}
