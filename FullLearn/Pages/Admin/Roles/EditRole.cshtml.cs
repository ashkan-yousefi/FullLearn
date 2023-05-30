using FullLearn.Core.Security;
using FullLearn.Core.Services.Interfaces;
using FullLearn.Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FullLearn.Web.Pages.Admin.Roles
{
    [PermissionChecker(9)]
    public class EditRoleModel : PageModel
    {
        private readonly IPermissionService _permissionService;
        public EditRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public Role Role { get; set; }
        public void OnGet(int id)
        {
            Role = _permissionService.GetRoleById(id);
            ViewData["Permissions"] = _permissionService.GetAllPermission();
            ViewData["SelectedPermission"] = _permissionService.SelectedPermissionsRole(id);
        }
        public IActionResult OnPost(List<int> SelectedPermission)
        {

            _permissionService.UpdateRole(Role);

            _permissionService.UpdatePermissionsRole(Role.RoleId, SelectedPermission);



            return RedirectToPage("Index");
        }
    }
}
