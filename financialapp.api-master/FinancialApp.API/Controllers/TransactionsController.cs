using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialApp.Core;
using FinancialApp.Core.Models;
using FinancialApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var transactionResult = _transactionService.GetTransactions();
            if (transactionResult.ResponseCode != ResponseCode.Success)
                return BadRequest(transactionResult.Error);
            return Ok(transactionResult.Result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var transactionResult = _transactionService.GetTransactionByAccount(id);
            if (transactionResult.ResponseCode != ResponseCode.Success)
                return BadRequest(transactionResult.Error);
            return Ok(transactionResult.Result);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] TransactionDataTransferObject value)
        {
            var transactionResult = _transactionService.AddTransaction(value);
            if (transactionResult.ResponseCode != ResponseCode.Success)
                return BadRequest(transactionResult.Error);
            return Ok(transactionResult.Result);
        }
    }
}
