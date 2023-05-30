using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullLearn.Data.Entities.Wallet
{
    public class WalletType
    {
        public WalletType()
        {

        }
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TypeId { get; set; }
        [Required]
        [MaxLength(150)]
        public string TypeTitle { get; set; }



        public List<Wallet> Wallets { get; set; }
    }
}
