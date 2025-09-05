using ExpensesTracker.Domain.Entities;
using ExpensesTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _dbContext;
        public TransactionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Transaction> InsertTransaction(Transaction transaction)
        {
            await _dbContext.AddAsync(transaction);
            await _dbContext.SaveChangesAsync();
            return transaction;
        }
    }
}
