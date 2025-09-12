using ExpensesTracker.Application.DTO.Transactions;
using ExpensesTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.Mappers
{
    public static class TransactionMapper
    {
        public static Transaction MapToTransaction(this CreateTransactionRequest request)
        {
            return new Transaction
            {
                UID = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Amount = request.Amount,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                UserUID = request.UserUID,
                TransactionTypeId = request.TransactionTypeId
            };
        }

        public static TransactionResponse MapToTransactionResponse(this Transaction transaction)
        {
            return new TransactionResponse
            (
                transaction.UID,
                transaction.Name,
                transaction.Description,
                transaction.Amount,
                transaction.CreatedDate,
                transaction.ModifiedDate,
                transaction.UserUID,
                transaction.TransactionTypeId
            );
        }

        public static Transaction MapToTransaction(this UpdateTransactionRequest request, Guid transactionUID)
        {
            return new Transaction
            {
                UID = transactionUID,
                Name = request.Name,
                Description = request.Description,
                Amount = request.Amount
            };
        }
    }
}
