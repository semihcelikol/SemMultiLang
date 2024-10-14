using SemMultiLang.LanguageWEB.Middleware;
using System.Globalization;

namespace SemMultiLang.LanguageWEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                            .AddViewLocalization();

            // + localization
            builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "Resources";
            });

            builder.Services.Configure<RequestLocalizationOptions>(opt =>
            {
                opt.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("tr-TR");

                CultureInfo[] cultures = new CultureInfo[]
                {
                    new ("tr-TR"),
                    new ("en-US")
                };

                opt.SupportedCultures = cultures;
                opt.SupportedUICultures = cultures;
            });

            builder.Services.AddScoped<MiddlewareCookiesRequestLocalization>();
            // -

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // + localization
            app.UseRequestLocalization();
            app.UseRequestLocalizationCookies();
            // -

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
