using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Zrozumcsharp.Data;

namespace Zrozumcsharp.Services
{
    public interface IFirstRunSetup
    {
        Task<bool> IsFirstRunSetupRequiredAsync();
        Task<bool> DoesContextRequrireSetupAsync();
        Task<bool> DoesAdminAccountRequireSetupAsync();
    }

    public class FirstRunSetup : IFirstRunSetup
    {
        private readonly IServiceProvider provider;
        private bool setupCompleted = false;

        public FirstRunSetup(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public async Task<bool> IsFirstRunSetupRequiredAsync()
        {
            if (setupCompleted)
                return false;

            var testContext = await DoesContextRequrireSetupAsync() == false;
            var testAdmin = await DoesAdminAccountRequireSetupAsync() == false;

            setupCompleted = testContext && testAdmin;

            return !setupCompleted;
        }

        public async Task<bool> DoesContextRequrireSetupAsync()
        {
            using (var scope = provider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ZrozumcsharpContext>();
                var doesAnyPendingMigrationExists = (await context.Database.GetPendingMigrationsAsync()).Any();
                return doesAnyPendingMigrationExists;
            }
        }

        public async Task<bool> DoesAdminAccountRequireSetupAsync()
        {
            using (var scope = provider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();
                var doesAnyUserExists = await userManager.Users.AnyAsync();
                return !doesAnyUserExists;
            }
        }
    }
}
