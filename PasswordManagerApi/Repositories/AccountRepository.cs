using PasswordManagerApi.Data;
using PasswordManagerApi.Interfaces;
using PasswordManagerApi.Models;

namespace PasswordManagerApi.Repositories
{
    public class AccountRepository(ApplicationDbContext applicationDbContext) : IAccountRepository
    {
        public List<AccountModel> GetAllAccounts()
        {
            return applicationDbContext.Accounts.ToList();
        }

        public AccountModel? GetAccountById(int id)
        {
            return applicationDbContext.Accounts.Find(id);
        }

        public AccountModel CreateAccount(AccountModel account)
        {
            applicationDbContext.Accounts.Add(account);
            applicationDbContext.SaveChanges();
            return account;
        }

        public AccountModel? UpdateAccount(int id, AccountModel account)
        {
            var accountToUpdate = applicationDbContext.Accounts.Find(id);

            if (accountToUpdate == null)
            {
                return null;
            }

            accountToUpdate.Title = account.Title;
            accountToUpdate.Url = account.Url;
            accountToUpdate.Email = account.Email;
            accountToUpdate.Username = account.Username;
            accountToUpdate.Password = account.Password;
            accountToUpdate.Notes = account.Notes;
            accountToUpdate.Favorite = account.Favorite;

            applicationDbContext.SaveChanges();
            return accountToUpdate;
        }

        public AccountModel? DeleteAccount(int id)
        {
            var accountToDelete = applicationDbContext.Accounts.Find(id);

            if (accountToDelete == null)
            {
                return null;
            }

            applicationDbContext.Remove(accountToDelete);
            applicationDbContext.SaveChanges();
            return accountToDelete;
        }
    }
}
