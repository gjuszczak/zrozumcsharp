using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zrozumcsharp.Data;

namespace Zrozumcsharp.Pages.Account.Admin
{
    public class ManageUsersModel : PageModel
    {
        private readonly ZrozumcsharpContext _context;

        public ManageUsersModel(ZrozumcsharpContext context)
        {
            _context = context;
        }

        public IList<IdentityUser> AllUsers { get; set; }

        public async Task OnGetAsync()
        {
            AllUsers = await _context.Users.ToListAsync();
        }
    }
}
