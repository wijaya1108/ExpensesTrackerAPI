using ExpensesTracker.Application.DTO.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.Services.Transactions
{
    public interface ITransactionService
    {
        Task<TransactionResponse> InsertTransaction(CreateTransactionRequest request);
        Task<List<TransactionResponse>> GetTransactionsByUserAndTransactionTypeID(Guid userUID, int transactionTypeId);
        Task<TransactionResponse?> GetTransactionByUID(Guid transactionUID);
        Task<bool> UpdateTransaction(UpdateTransactionRequest request, Guid transactionUID);
        Task<bool> DeleteTransaction(Guid transactionUID);
    }
}
