using System;
using System.Data.SqlClient;
using TenmoServer.Models;
using TenmoServer.Security;

namespace TenmoServer.DAO
{
    public class TransferSqlDAO : ITransferDAO
    {
        private readonly string connectionString;


        public TransferSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Transfer StartTransfer(Transfer newTransfer) // making instance of transfer/record
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO transfers(transfer_type_id, transfer_status_id, account_from, account_to, amount) " +
                                                "VALUES(@typeId, @statusId, @accountFrom, @accountTo, @amount); SELECT @@IDENTITY;", conn);
                cmd.Parameters.AddWithValue("@typeId", newTransfer.TransferTypeId);
                cmd.Parameters.AddWithValue("@statusId", newTransfer.TransferStatusId);
                cmd.Parameters.AddWithValue("@accountFrom", newTransfer.AccountFrom);
                cmd.Parameters.AddWithValue("@accountTo", newTransfer.AccountTo);
                cmd.Parameters.AddWithValue("@amount", newTransfer.Amount);


                int id = Convert.ToInt32(cmd.ExecuteScalar()); //returns the first cell, first column, first row in the database. gets from select @@ identity 
                newTransfer.TransferId = id;
                return newTransfer;
            }
        }

        public Transfer GetTransferDataFromReader(SqlDataReader reader) // converts values from SQL fields into Object properties 
        {
            return new Transfer()
            {
                TransferTypeId = Convert.ToInt32(reader["transfer_type_id"]),
                TransferStatusId = Convert.ToInt32(reader["transfer_status_id"]),
                AccountFrom = Convert.ToInt32(reader["account_from"]),
                AccountTo = Convert.ToInt32(reader["account_to"]),
                Amount = Convert.ToDecimal(reader["amount"])

            };
        }
        public bool UpdateBalances(Transfer transfer)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE accounts SET balance += @amount WHERE account_id = @accountToId;" +
                     "UPDATE accounts SET balance -= @amount WHERE account_id = @accountFromId; ", conn);
                cmd.Parameters.AddWithValue("@accountToId", transfer.AccountTo);
                cmd.Parameters.AddWithValue("@amount", transfer.Amount);
                cmd.Parameters.AddWithValue("@accountFromId", transfer.AccountFrom);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 2) // affecting two accounts , nuke the nips
                {
                    return true;
                }
            }
            return false;
        }


        public Transfer GetTransferById(int transferId)
        {
            Transfer returnTransfer = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("select transfer_id, transfer_type_id, transfer_status_id, account_from, " +
                    "account_to, amount from transfers where transfer_id = @transferId", conn);
                cmd.Parameters.AddWithValue("@transferId", transferId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    returnTransfer = GetTransferDataFromReader(reader);
                }
            }
            return returnTransfer;
        }
    }
}
