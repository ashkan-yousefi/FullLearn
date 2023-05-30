using FullLearn.Core.DTOs.User;
using FullLearn.Data.Entities.User;
using FullLearn.Data.Entities.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullLearn.Core.Services.Interfaces
{
    public interface IUserService
    {
        #region User
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        int AddUser(User user);
        User LoginUser(LoginViewModel login);
        bool ActiveAccount(string activeCode);
        User GetUserByEmail(string email);
        User GetUserByActiveId(string ActiveCode);
        User GetUserByUserName(string userName);
        void UpdateUser(User user);
        int GetUserIdByUserName(string userName);
        #endregion
        #region UserPanel
        InformationUserViewModel GetUserInformation(string userName);
        InformationUserViewModel GetUserInformation(int userId);
        SideBarUserPanelViewModel GetSideBarUserPanelData(string userName);
        EditProfileViewModel GetDataFormEditProfileUser(string userName);
        void EditProfile(string userName, EditProfileViewModel profile);
        bool CompairOldPassword(string userName, string oldPassword);
        void ChangeUserPassword(string userName, string newPassword);
        User GetUserById(int userId);
        void DeleteUser(int userId);
        #endregion
        #region Wallet
        int BalanceUserWallet(string userName);
        List<WalletViewModel> GetWalletUser(string userName);
        int ChargeWallet(string userName, int amount,string description, bool IsPay = false);
        int AddWallet(Wallet wallet);
        Wallet GetWalletByWalletId(int walletId);
        void UpdateWallet(Wallet wallet);
        #endregion
        #region Admin Panel
        UsersForAdminViewModel GetUsers(int pageId=1,string filterEmail="",string filterUserName="");
        UsersForAdminViewModel GetDeleteUsers(int pageId=1,string filterEmail="",string filterUserName="");
        int AddUserFromAdmin(CreateUserViewModel user);
        EditUserViewModel GetUserForShowInEditMode(int userId);
        void EditUserFromAdmin(EditUserViewModel editUser);
        #endregion
    }
}
