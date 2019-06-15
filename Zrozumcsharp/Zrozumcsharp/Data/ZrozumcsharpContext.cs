using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zrozumcsharp.Models;

namespace Zrozumcsharp.Data
{
    public class ZrozumcsharpContext : IdentityDbContext<IdentityUser>
    {
        public ZrozumcsharpContext (DbContextOptions<ZrozumcsharpContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
