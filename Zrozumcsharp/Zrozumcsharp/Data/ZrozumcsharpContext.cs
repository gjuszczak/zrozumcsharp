using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Zrozumcsharp.Models
{
    public class ZrozumcsharpContext : DbContext
    {
        public ZrozumcsharpContext (DbContextOptions<ZrozumcsharpContext> options)
            : base(options)
        {
        }

        public DbSet<Zrozumcsharp.Models.Movie> Movie { get; set; }
    }
}
