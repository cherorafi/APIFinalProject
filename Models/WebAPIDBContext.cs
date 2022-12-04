using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using WebAPI.Models;

namespace WebAPI.Models
{
    public class WebAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public WebAPIDBContext(DbContextOptions<WebAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("game_info");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;


    }
}
