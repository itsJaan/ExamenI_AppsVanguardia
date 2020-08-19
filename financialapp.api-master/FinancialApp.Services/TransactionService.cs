using FinancialApp.Core;
using FinancialApp.Core.Models;
using FinancialApp.Data.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinancialApp.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Transaction> _transactionRepository;

        public TransactionService(IRepository<Transaction> transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public ServiceResult<TransactionDataTransferObject> AddTransaction(TransactionDataTransferObject transaction)
        {
            var entity = new Transaction
            {
                AccountId = transaction.AccountId,
                Amount = transaction.Amount,
                Description=transaction.Description
            };

            var result = _transactionRepository.Add(entity);
            _transactionRepository.SaveChanges();
            transaction.Id = result.Id;
            return ServiceResult<TransactionDataTransferObject>.SuccessResult(transaction);

        }
        public ServiceResult<IEnumerable<TransactionDataTransferObject>> GetTransactions()
        {
            var transactions = this._transactionRepository.All()
           .Select(x => new TransactionDataTransferObject
           {
               Id = x.Id,
               AccountId = x.AccountId,
               AccountName = x.Account.Name,
               Amount = x.Amount,
               Description = x.Description,
               TransactionDate = x.TransactionDate
           }).Take(5);
            return ServiceResult<IEnumerable<TransactionDataTransferObject>>.SuccessResult(transactions);
        }

        public ServiceResult<IEnumerable<TransactionDataTransferObject>> GetTransactionByAccount(long id)
        {
            var transactions = this._transactionRepository.All().Where(x => x.AccountId == id)
               .Select(x => new TransactionDataTransferObject
               {
                   Id = x.Id,
                   AccountId = x.AccountId,
                   AccountName = x.Account.Name,
                   Amount = x.Amount,
                   Description = x.Description,
                   TransactionDate = x.TransactionDate
               }).Take(5);
            return ServiceResult<IEnumerable<TransactionDataTransferObject>>.SuccessResult(transactions);
        }

        public ServiceResult<ResumeDataTransferObject> GetResume(long id)
        {
            //double conversionRate =1 ; //= this._transactionRepository. ;
            var transactions = this._transactionRepository.All().Where(x => x.AccountId == id)
                  .Select(x => new TransactionDataTransferObject
                  {
                      Id = x.Id,
                      AccountId = x.AccountId,
                      AccountName = x.Account.Name,
                      Amount = x.Amount,
                      Description = x.Description,
                      TransactionDate = x.TransactionDate,
                      conversionRate = x.Account.ConversionRate
                  });
            //Saco la suma del amount donde son mayores que 0 considerando que 0 no es negativo
            double income = (from x in transactions where x.Amount >=0 select (x.Amount * x.conversionRate)).Sum();
            //Saco la suma del amount donde son menores que 0
            double expenses = (from x in transactions where x.Amount < 0 select (x.Amount * x.conversionRate)).Sum();

            double total = income + expenses;

            var result = new ResumeDataTransferObject
            {
                Income = income,
                Expenses = expenses,
                Total = total
            };
            return ServiceResult<ResumeDataTransferObject>.SuccessResult(result);
        }
    }
}
