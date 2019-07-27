using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zrozumcsharp.Data;
using Zrozumcsharp.Models;

namespace Zrozumcsharp.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ZrozumcsharpContext _context;

        public IndexModel(ZrozumcsharpContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get; set; }

        public async Task OnGetAsync()
        {
            Course = await _context.Course.ToListAsync();
        }
    }
}
