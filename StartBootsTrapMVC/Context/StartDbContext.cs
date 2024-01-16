using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StartBootsTrapMVC.Models;

namespace StartBootsTrapMVC.Context
{
	public class StartDbContext : IdentityDbContext
	{
        public DbSet<Detail> Details { get; set; }
        public StartDbContext(DbContextOptions opt) : base(opt)
        {
        }
    }
}
