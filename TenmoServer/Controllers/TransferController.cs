using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TenmoServer.DAO;
using TenmoServer.Models;


namespace TenmoServer.Controllers
{
    [Route("Transfer/")] 
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferDAO transferDAO;
        public TransferController(ITransferDAO transferDAO)
        {
            this.transferDAO = transferDAO;
        }

        [HttpPut("Account")]
        [Authorize]

        public IActionResult UpdateBalances( [FromBody] Transfer transfer)
        {
            bool balanceGood = transferDAO.UpdateBalances(transfer);
            if ( balanceGood == false)
            {
                return BadRequest("Could not update accounts");
            }
            return Ok();
        }


        [HttpPost("Create")]
        [AllowAnonymous]

        public IActionResult StartTransfer(Transfer newTransfer)
        {
            Transfer returntransfer = transferDAO.StartTransfer(newTransfer);
            if (newTransfer == null)
            {
                return BadRequest("No transfer");
            }
            return Ok(returntransfer);
        }
    }
}
