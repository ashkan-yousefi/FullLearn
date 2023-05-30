using FullLearn.Core.Security;
using FullLearn.Core.Services.Interfaces;
using FullLearn.Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FullLearn.Web.Pages.Admin.Roles
{
    [PermissionChecker(7)]
    public class CreateRoleModel : PageModel
    {
       private readonly IPermissionService _permissionService;
        public CreateRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public Role Role { get; set; }
        public void OnGet()
        {
            ViewData["Permissions"] = _permissionService.GetAllPermission();
        }
        public IActionResult OnPost(List<int> SelectedPermission)
        {

            Role.IsDelete = false;
            int roleId=_permissionService.AddRole(Role);


            _permissionService.AddPermissionsToRole(roleId,SelectedPermission);


            return RedirectToPage("Index");
        }
    }
}
