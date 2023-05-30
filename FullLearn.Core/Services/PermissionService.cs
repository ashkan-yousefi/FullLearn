using FullLearn.Core.Services.Interfaces;
using FullLearn.Data.Context;
using FullLearn.Data.Entities.Permissions;
using FullLearn.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullLearn.Core.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly FullLearnContext _context;
        public PermissionService(FullLearnContext context)
        {
            _context = context;
        }

        public List<Permission> GetAllPermission()
        {
            return _context.Permission.ToList();
        }

        public int AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role.RoleId;
        }

        public void AddRolesToUser(List<int> roleIds, int userId)
        {
            foreach (int roleId in roleIds)
            {
                _context.UserRoles.Add(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userId
                });
            }

            _context.SaveChanges();
        }

        public void DeleteRole(Role role)
        {
            role.IsDelete = true;
            UpdateRole(role);
        }

        public void EditRolesUser(int usesId, List<int> rolesId)
        {
            //Delete All Roles User
            _context.UserRoles.Where(r => r.UserId == usesId).ToList().ForEach(r => _context.UserRoles.Remove(r));

            //Add New Roles
            AddRolesToUser(rolesId, usesId);
        }

        public Role GetRoleById(int roleId)
        {
            return _context.Roles.Find(roleId);
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public void UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public void AddPermissionsToRole(int roleId, List<int> permissions)
        {
            foreach (var p in permissions)
            {
                _context.RolePermission.Add(new RolePermission()
                {
                    PermissionId=p,RoleId=roleId
                });
            }
                _context.SaveChanges();
        }

        public List<int> SelectedPermissionsRole(int roleId)
        {
            return _context.RolePermission.Where(r => r.RoleId == roleId).Select(r=>r.PermissionId).ToList();
        }

        public void UpdatePermissionsRole(int roleId, List<int> Permissions)
        {
            _context.RolePermission.Where(p => p.RoleId == roleId).ToList().ForEach(p => _context.Remove(p));
            AddPermissionsToRole(roleId,Permissions);
        }

        public bool CheckPermission(int permissionId, string userName)
        {
            int userId = _context.Users.Single(u => u.UserName == userName).UserId;
            List<int> UserRoles = _context.UserRoles.Where(r => r.UserId == userId).Select(r => r.RoleId).ToList();
            if (!UserRoles.Any())
            {
                return false;
            }
            List<int> RolesPermission = _context.RolePermission.Where(p => p.PermissionId == permissionId).Select(p=>p.RoleId).ToList();
            return RolesPermission.Where(p => UserRoles.Contains(p)).Any();
        }
    }
}
