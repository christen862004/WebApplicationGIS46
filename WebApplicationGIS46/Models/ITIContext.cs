using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationGIS46.Models
{
    public class ITIContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        //DBContextOptioons
        //DBMS "SQL SERVER"
        //Server NAme "."
        //Authantication
        //Databse name
        //public ITIContext():base()
        //{
            
        //}
        public ITIContext(DbContextOptions<ITIContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=GIS_MVC_46;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");//connectionstring
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
