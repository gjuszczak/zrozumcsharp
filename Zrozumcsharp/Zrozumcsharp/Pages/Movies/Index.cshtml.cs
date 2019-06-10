using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zrozumcsharp.Models;

namespace Zrozumcsharp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Zrozumcsharp.Models.ZrozumcsharpContext _context;

        public IndexModel(Zrozumcsharp.Models.ZrozumcsharpContext context)
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
