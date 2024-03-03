using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
    public class ITIEntity:DbContext
    {
        public ITIEntity():base()
        {

        }

        public ITIEntity(DbContextOptions options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-SMHGA8V\\SQL;Initial Catalog=Intake42Q3Assiut;Integrated Security=True");
            base.OnConfiguring(optionsBuilder); 
        }
    }
}
