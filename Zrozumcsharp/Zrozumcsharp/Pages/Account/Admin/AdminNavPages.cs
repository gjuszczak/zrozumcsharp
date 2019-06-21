using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Zrozumcsharp.Pages.Account.Admin
{
    public static class AdminNavPages
    {
        public static string ManageUsers => "ManageUsers";

        public static string ManageUsersNavClass(ViewContext viewContext) => PageNavClass(viewContext, ManageUsers);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}