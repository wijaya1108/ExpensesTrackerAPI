using ExpensesTracker.Application.DTO.Transactions;
using ExpensesTracker.Application.Mappers;
using ExpensesTracker.Domain.Entities;
using ExpensesTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<List<TransactionResponse>> GetTransactionsByUserAndTransactionTypeID(Guid userUID, int transactionTypeId)
        {
            var transactionResponseList = new List<TransactionResponse>();

            var transactionsList = await _transactionRepository.GetTransactionsByUserAndTransactionTypeID(userUID, transactionTypeId);

            if (transactionsList.Any())
            {
                foreach (var transaction in transactionsList)
                {
                    transactionResponseList.Add(transaction.MapToTransactionResponse());
                }
            }

            return transactionResponseList;
        }

        public async Task<TransactionResponse> InsertTransaction(CreateTransactionRequest request)
        {
            Transaction transaction = request.MapToTransaction();
            var newTransaction = await _transactionRepository.InsertTransaction(transaction);

            var transactionResponse = newTransaction.MapToTransactionResponse();

            return transactionResponse;
        }

        public async Task<TransactionResponse?> GetTransactionByUID(Guid transactionUID)
        {
            var transaction = await _transactionRepository.GetTransactionByUID(transactionUID);

            return transaction?.MapToTransactionResponse(); 
        }
    }
}
