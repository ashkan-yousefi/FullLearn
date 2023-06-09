using FullLearn.Core.DTOs.User;
using FullLearn.Core.Security;
using FullLearn.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FullLearn.Web.Pages.Admin.Users
{
    [PermissionChecker(4)]
    public class EditUserModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;
        public EditUserModel(IUserService userService, IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }

        [BindProperty]
        public EditUserViewModel EditUserViewModel { get; set; }
        public void OnGet(int id)
        {
            EditUserViewModel = _userService.GetUserForShowInEditMode(id);
            ViewData["Roles"] = _permissionService.GetRoles();
        }

        public IActionResult OnPost(List<int> SelectedRoles)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _userService.EditUserFromAdmin(EditUserViewModel);

            //Edit Roles
            _permissionService.EditRolesUser(EditUserViewModel.UserId, SelectedRoles);
            return RedirectToPage("Index");
        }
    }
}
