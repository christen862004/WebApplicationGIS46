using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplicationGIS46.Models;
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
            //builder.Services.AddControllersWithViews(options=>options.Filters.Add(new ErrorHandelAttribute()));
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
                options.IdleTimeout = TimeSpan.FromMinutes(30)); ;//registre sessives using defaiutl
            builder.Services.AddDbContext<ITIContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CS"));//connectionstring

            });//register ITIContext,dbContextOption
            //web api authorize token
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(optios => //identity
            {
                optios.Password.RequireUppercase = true;
                optios.Password.RequiredLength = 4;
                optios.Password.RequireNonAlphanumeric = false;
                optios.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ITIContext>();



















        
            //3) Custom Service ,and need to register
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepsitory>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepository>();
           // builder.Services.AddSingleton<IService, Service>();//create one object to all request 1
           // builder.Services.AddTransient<IService, Service>();//create new object wiach inject  4
            builder.Services.AddScoped<IService, Service>();//create new object with each request  2
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.//Middlewares
            #region inline middlware "delcare degleg (custom)
            //app.Use(async (httpcontext, nextrMidleware) => {
            //    await httpcontext.Response.WriteAsync("1- Middleware 1\n");//1
            //    await nextrMidleware.Invoke();//2<=
            //    await httpcontext.Response.WriteAsync("1-1 Middleware 1-1\n");//3
            //});
            //app.Use(async (httpcontext, nextrMidleware) => {
            //    await httpcontext.Response.WriteAsync("2- Middleware 2\n");//4
            //    await nextrMidleware.Invoke();//5
            //    await httpcontext.Response.WriteAsync("2-2 Middleware 2-2\n");//6
            //});
            //app.Run(async httpcontext =>
            //{
            //   await  httpcontext.Response.WriteAsync("3- Terminate\n");//7
            //});
            //1,2,4,5,7,6,3
            #endregion
            //2) Component middlware (built in)
            #region defult pipline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            
            app.UseStaticFiles();//try to handel request from wwwroot folder 

            app.UseRouting();//security MApping 

            app.UseAuthorization();

            app.UseSession();//creat esession wrote , read ==>use some servbices ==>need to register

            #region Custom Route 1)Naming Convension route - route constarin - default route parameter
            //app.MapControllerRoute(name: "Rout1", 
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            //r1/Method1
            //r1/Method2


            //app.MapControllerRoute(name: "emp1",
            //    pattern: "e1/{action}", defaults: new { controller = "Employee", action = "Index" });


            //app.MapControllerRoute(name: "Rout1",
            //    pattern: "r1/{age:int:range(20,60)}/{name?}",
            //    defaults: new { controller = "Route", action = "Method1" });

            //app.MapControllerRoute(name: "Rout2",
            //    pattern: "r2",
            //    defaults: new { controller = "Route", action = "Method2" });
            #endregion
            //the last route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");//staff (decalre ,execute)//Employee/Index
            #endregion
            app.Run();
        }
    }
}
