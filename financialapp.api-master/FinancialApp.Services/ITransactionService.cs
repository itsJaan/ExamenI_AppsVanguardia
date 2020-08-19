using FinancialApp.Core;
using FinancialApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialApp.Services
{
    public interface ITransactionService
    {
        ServiceResult<TransactionDataTransferObject> AddTransaction(TransactionDataTransferObject transaction);
        ServiceResult<IEnumerable<TransactionDataTransferObject>> GetTransactions();
        ServiceResult<IEnumerable<TransactionDataTransferObject>> GetTransactionByAccount(long id);
        ServiceResult<ResumeDataTransferObject> GetResume(long id);
    }
}
