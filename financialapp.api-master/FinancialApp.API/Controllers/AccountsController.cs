using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialApp.Core;
using FinancialApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService , ITransactionService transactionService)
        {
            _accountService = accountService;
            _transactionService = transactionService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            var accountResult = _accountService.GetAccounts();
            if (accountResult.ResponseCode != ResponseCode.Success)
                return BadRequest(accountResult.Error);
            return Ok(accountResult.Result);
        }
        
        [HttpGet("{id}/Resume")]
        public ActionResult<string> Get(int id)
        {
            var accountResult = _transactionService.GetResume(id);
            if (accountResult.ResponseCode != ResponseCode.Success)
                return BadRequest(accountResult.Error);
            return Ok(accountResult.Result);
        }
    }
}
