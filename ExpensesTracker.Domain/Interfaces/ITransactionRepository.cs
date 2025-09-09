using ExpensesTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> InsertTransaction(Transaction transaction);
        Task<List<Transaction>> GetTransactionsByUserAndTransactionTypeID(Guid userUID, int transactionTypeId);
    }
}
