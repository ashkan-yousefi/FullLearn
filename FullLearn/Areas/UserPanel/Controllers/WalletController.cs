using FullLearn.Core.DTOs.User;
using FullLearn.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FullLearn.Web.Areas.UserPanel.Controllers
{
    [Authorize]
    [Area("UserPanel")]
    public class WalletController : Controller
    {
        private IUserService _userService;
        public WalletController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("/UserPanel/Wallet")]
        public IActionResult Index()
        {
            ViewBag.ListWallet = _userService.GetWalletUser(User.Identity.Name);
            return View();
        }
        [HttpPost]
        [Route("/UserPanel/Wallet")]
        public IActionResult Index(ChargeWaletViewModel charge)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ListWallet = _userService.GetWalletUser(User.Identity.Name);
                return View(charge);
            }
            int walletId = _userService.ChargeWallet(User.Identity.Name, charge.Amount, "شارژ حساب");
            #region Oline Payment
            var payment = new ZarinpalSandbox.Payment(charge.Amount);
            var response = payment.PaymentRequest("شارژ کیف پول", "https://localhost:44340/OnlinePayment/" + walletId);
            if (response.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + response.Result.Authority);
            }
            #endregion

            return Redirect("/UserPanel/Wallet");

        }
    }
}
