using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zrozumcsharp.Data;
using Zrozumcsharp.Models;

namespace Zrozumcsharp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly ZrozumcsharpContext _context;

        public IndexModel(ZrozumcsharpContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
