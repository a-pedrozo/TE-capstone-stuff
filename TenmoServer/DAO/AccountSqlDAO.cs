using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TenmoServer.Models;
using TenmoServer.Security;

namespace TenmoServer.DAO
{
    public class AccountSqlDAO : IAccountDAO
    {
        private readonly string connectionString;


        public AccountSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public Account GetAccountBalanceByUserId(int userId)
        {
            Account returnAccount = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("select balance from accounts a inner join users u ON a.user_id = u.user_id" +
                    " where u.user_id = @userId", conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    returnAccount = GetAccountFromReader(reader);
                }
            }
            return returnAccount;
        }
        public Account GetAccountIdByUserId(int userId)
        {
            Account returnAccount = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("select user_id, account_id, balance from accounts where user_id = @userId", conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    returnAccount = GetAccountFromReader(reader);
                }
            }
            return returnAccount;
        }

        private Account GetAccountFromReader(SqlDataReader reader)
        {
            return new Account()
            {
                UserId = Convert.ToInt32(reader["user_id"]),
                AccountId = Convert.ToInt32(reader["account_id"]),
                Balance = Convert.ToDecimal(reader["balance"])
            };
        }
    }
}
