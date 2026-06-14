using WebApplicationGIS46.Repository;
using WebApplicationGIS46.ViewModel;

namespace WebApplicationGIS46
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //1) built in and already register
            //2) built in and need to register
            builder.Services.AddControllersWithViews();
            //3) Custom Service ,and need to register
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepsitory>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.//Middlewares
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
