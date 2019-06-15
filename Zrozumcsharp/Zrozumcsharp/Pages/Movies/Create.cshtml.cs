using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zrozumcsharp.Data;
using Zrozumcsharp.Models;

namespace Zrozumcsharp.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly ZrozumcsharpContext _context;

        public CreateModel(ZrozumcsharpContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}