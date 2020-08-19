using FinancialApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using FinancialApp.Core.Models;
namespace FinancialApp.Services
{
    public interface IAccountService
    {
        ServiceResult<IEnumerable<AccountDataTransferObject>> GetAccounts();
    }
}

