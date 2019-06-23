using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Zrozumcsharp.Pages.Account.Admin
{
    public class DeleteUserModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<DeleteUserModel> _logger;

        public DeleteUserModel(
            UserManager<IdentityUser> userManager,
            ILogger<DeleteUserModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public IdentityUser SelectedUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SelectedUser = await _userManager.FindByIdAsync(id);
            if (SelectedUser == null)
            {
                return NotFound($"Unable to load user with ID '{id}'.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{id}'.");
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleteing user with ID '{id}'.");
            }

            _logger.LogInformation("User with ID '{UserId}' deleted by administrator.", id);

            return RedirectToPage("./ManageUsers");
        }
    }
}
