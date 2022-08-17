using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TenmoServer.DAO;
using TenmoServer.Models;
using TenmoServer.Security;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserDAO userDAO;
        private readonly IAccountDAO accountDAO;
        public AccountController(IUserDAO userDAO, IAccountDAO accountDAO)
        {
            this.userDAO = userDAO;
            this.accountDAO = accountDAO;
        }
       

        [HttpGet("Balance")]
        [Authorize]

        public IActionResult GetAccountBalance()
        {
            string username = User.Identity.Name; //this gets name of current user
            User user = userDAO.GetUser(username);
            if (user != null)
            {
                ReturnUser retUser = new ReturnUser()
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Balance = user.Balance
                };
                return Ok(retUser);
            }
            else
            {
                return BadRequest("This is a bad request");
            }
        }

        [HttpGet("AllAccounts")]
        [AllowAnonymous]
        public IActionResult GetAllUsers()
        {
            List<User> AllAccounts = userDAO.GetUsers();
            
            if(AllAccounts != null)
            {
                return Ok(AllAccounts);
            }
            else
            {
                return BadRequest("this did not work, try again");
            }
            
                
        }
        [HttpGet("Users/{userId}")]
        public IActionResult SelectUserById(int userId)
        {

            User user = userDAO.GetUserByAccountId(userId);
            if(user != null)
            {
                ReturnUser retuser = new ReturnUser()
                {
                    UserId = user.UserId,
                    Username = user.Username
                };
                    return Ok(retuser);
            }
            else
            {
                return BadRequest("this did not work try again");
            }

        }
        [HttpGet("Balance/{userId}")]
        [Authorize]
        public IActionResult GetBalanceByUserId() //not implimented 
        {
            int userId = 1;// something
            Account account = accountDAO.GetAccountBalanceByUserId(userId);
            if (account != null)
            {
                ReturnAccount retAccount = new ReturnAccount()
                {
                    AccountId = account.AccountId,
                    UserId = account.UserId,
                    Balance = account.Balance
                };
                return Ok(retAccount);
            }
            else
            {
                return BadRequest("this request is garbage");
            }
        }  
        
        [HttpGet("{userId}")]
        public IActionResult GetAccountIdByUserId(int userId)
        {
            Account account = accountDAO.GetAccountIdByUserId(userId);
            if (account != null)
            {
                return Ok(account);
            }
            else
            {
                return BadRequest("bad user ID");
            }
        }

    }
}
