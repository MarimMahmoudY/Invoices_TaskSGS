using Base.DAL;
using Microsoft.EntityFrameworkCore;
using Mid.BL;

namespace Client.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddServerSideBlazor();
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("InvoiceTask");
            builder.Services.AddDbContext<SystemContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IInvoicesRepo, InvoicesRepo>();
            builder.Services.AddScoped<IInvoiceManager, InvoiceManager>();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapBlazorHub();

            app.Run();
        }
    }
}