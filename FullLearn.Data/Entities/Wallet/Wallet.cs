using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using FullLearn.Data.Entities.User;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullLearn.Data.Entities.Wallet
{
    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [Display(Name = "نوع تراکنش")]
        public int TypeId { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [Display(Name = "کاربر")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [Display(Name = "مبلغ")]
        public int Amount { get; set; }
        [MaxLength(200,ErrorMessage ="{0}نمیتواند بیشتر از {1} کاراکتر باشد.")]
        [Display(Name = "شرح")]
        public string Description { get; set; }
        [Display(Name = "تایید شده")]
        public bool IsPay { get; set; }
        [Display(Name = "تاریخ")]
        public DateTime CreateDate { get; set; }

        public User.User User { get; set; }
        [ForeignKey("TypeId")]
        public WalletType WalletType { get; set; }

    }
}
