using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();
            // Add services to the container.
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//sessionn
            builder.Services.AddControllersWithViews();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(120);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //app.Environment.EnvironmentName = Microsoft.AspNetCore.Hosting.EnvironmentName.Production; 
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();//sessionn
            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Filter}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "MyRoute",
                pattern: "Yahya/{controller=Home}/{action=Index2}/{id?}");



            app.Run();
        }
    }
}