using PasswordManagerApi.Models;

namespace PasswordManagerApi.Interfaces
{
    public interface IAccountRepository
    {
        List<AccountModel> GetAllAccounts();
        AccountModel? GetAccountById(int id);
        AccountModel CreateAccount(AccountModel account);
        AccountModel? UpdateAccount(int id, AccountModel account);
        AccountModel? DeleteAccount(int id);
    }
}
