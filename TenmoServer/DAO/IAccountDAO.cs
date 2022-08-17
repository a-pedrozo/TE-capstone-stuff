using System.Collections.Generic;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IAccountDAO
    {
        public Account GetAccountBalanceByUserId(int userId);
        public Account GetAccountIdByUserId(int userId);

    }
}
