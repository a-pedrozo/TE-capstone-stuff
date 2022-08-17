using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface ITransferDAO
    {
        public bool UpdateBalances(Transfer transfer);

        public Transfer StartTransfer(Transfer newTransfer);

        public Transfer GetTransferById(int transferId);
    }

}
