using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zrozumcsharp.Data;
using Zrozumcsharp.Models;

namespace Zrozumcsharp.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly ZrozumcsharpContext _context;

        public DetailsModel(ZrozumcsharpContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
