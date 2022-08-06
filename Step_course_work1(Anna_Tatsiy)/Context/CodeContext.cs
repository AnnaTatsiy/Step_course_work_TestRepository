using Step_course_work1_Anna_Tatsiy_.Models;
using Step_course_work1_Anna_Tatsiy_.Configuration;
using System.Data.Entity;

namespace Step_course_work1_Anna_Tatsiy_.Context
{
    internal class CodeContext : DbContext
    {
        public CodeContext() : base("CourseWorkDb") { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }    
        public DbSet<Worker> Workers { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Malfunction> Malfunctions { get; set; }    
        public DbSet<Repair> Repairs {get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ClientConfig());
            modelBuilder.Configurations.Add(new PersonConfig());
            modelBuilder.Configurations.Add(new CarBrandConfig());
            modelBuilder.Configurations.Add(new ColorConfig());
            modelBuilder.Configurations.Add(new WorkerConfig());
            modelBuilder.Configurations.Add(new SparePartConfig());
            modelBuilder.Configurations.Add(new CarConfig());
            modelBuilder.Configurations.Add(new RepairConfig());
            modelBuilder.Configurations.Add(new MalfunctionConfig());
            modelBuilder.Configurations.Add(new SpecializationConfig());
        }
    }
}
