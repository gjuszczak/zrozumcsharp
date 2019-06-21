using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Zrozumcsharp.Pages.Account.Manage
{
    public static class ManageNavPages
    {
        public static string UpdateProfile => "UpdateProfile";

        public static string ChangePassword => "ChangePassword";

        public static string PersonalData => "PersonalData";

        public static string UpdateProfileNavClass(ViewContext viewContext) => PageNavClass(viewContext, UpdateProfile);

        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

        public static string PersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, PersonalData);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}