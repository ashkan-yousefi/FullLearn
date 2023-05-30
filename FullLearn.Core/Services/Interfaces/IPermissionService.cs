using FullLearn.Data.Entities.Permissions;
using FullLearn.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullLearn.Core.Services.Interfaces
{
    public interface IPermissionService
    {
        #region Roles
        List<Role> GetRoles();
        int AddRole(Role role);
        Role GetRoleById(int roleId);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
        void AddRolesToUser(List<int> roleIds,int userId);
        void EditRolesUser(int usesId,List<int>rolesId);
        #endregion
        #region Permission
        List<Permission> GetAllPermission();
        void AddPermissionsToRole(int roleId,List<int> permissions);
        List<int> SelectedPermissionsRole(int roleId);
        bool CheckPermission(int permissionId,string userName);
        void UpdatePermissionsRole(int roleId,List<int> Permissions);
        #endregion
    }
}
