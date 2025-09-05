using ExpensesTracker.Application.DTO.Transactions;
using ExpensesTracker.Application.Mappers;
using ExpensesTracker.Application.Services.Transactions;
using ExpensesTracker.Domain.Entities;
using ExpensesTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionResponse> InsertTransaction(CreateTransactionRequest request)
        {
            Transaction transaction = request.MapToTransaction();
            var newTransaction = await _transactionRepository.InsertTransaction(transaction);

            var transactionResponse = newTransaction.MapToTransactionResponse();

            return transactionResponse;
        }
    }
}
