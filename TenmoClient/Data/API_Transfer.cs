using System;
using System.Collections.Generic;
using System.Text;

namespace TenmoClient.Data
{
    public class API_Transfer
    {
        public API_Transfer() { } // accountFrom use token , get all usersmethod make to list
        public API_Transfer(decimal amount, int accountFrom, int accountTo) // accountTo use innerjoin sql statement
        {
            this.Amount = amount;
            this.AccountFrom = accountFrom;
            this.AccountTo = accountTo;
            //this.TransferTypeId = transferTypeId;
            //this.TransferStatusId = transferStatusId; save selected id into variable
        }
        public int TransferId { get; set; }
        public decimal Amount { get; set; }
        public int AccountFrom { get; set; }
        public int AccountTo { get; set; }
        public int TransferTypeId { get; set; } = 1001; // set to send request 
        public int TransferStatusId { get; set; } = 2001; // set to approved 
     
       
    }
}
