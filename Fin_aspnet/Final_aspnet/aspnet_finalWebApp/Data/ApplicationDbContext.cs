using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using aspnet_final.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnet_final.Data
{
    public class ApplicationDbContext : IdentityDbContext       // 1. ASP.NET Identity : DbContext 쓰는것하고 동일 
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; }

        public DbSet<PortfolioModel> Portfolios { get; set; }
    }
}
