using FullLearn.Data.Entities.Permissions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullLearn.Data.Entities.User
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required(ErrorMessage ="لطفا {0} را وارد کنید.")]
        [Display(Name ="عنوان نقش")]
        [MaxLength(200,ErrorMessage ="{0}نمیتواند بیشتر از {1} کاراکتر باشد.")]
        public string RoleTitle { get; set; }
        public bool IsDelete { get; set; }


        #region Relations
        public List<UserRole> UserRoles { get; set; }
        public List<RolePermission> RolePermissions { get; set; }
        #endregion
    }
}
