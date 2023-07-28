using Data;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Extension
{
    public class ServiceExtensions
    {
        public static void AddIdentity(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<DataContext>()
             .AddDefaultTokenProviders();
        }

        public static void AddDbContext(IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"))
            );
        }

        
    }
}
