using ExpensesTracker.Domain.Entities;
using ExpensesTracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Transaction>> GetTransactionsByUserAndTransactionTypeID(Guid userUID, int transactionTypeId)
        {
            var transactions = await _dbContext.Transactions
                .AsNoTracking()
                .Where(t => t.UserUID == userUID && t.TransactionTypeId == transactionTypeId &&!t.IsDeleted)
                .ToListAsync();

            return transactions;
        }

        public async Task<Transaction> InsertTransaction(Transaction transaction)
        {
            await _dbContext.AddAsync(transaction);
            await _dbContext.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction?> GetTransactionByUID(Guid transactionUID)
        {
            var transaction = await _dbContext.Transactions
                .AsNoTracking()
                .Where(t => t.UID == transactionUID && !t.IsDeleted)
                .Include(t => t.User)
                .FirstOrDefaultAsync();

            return transaction;
        }

        public async Task<bool> UpdateTransaction(Transaction transaction)
        {
            var existingTransaction = await _dbContext.Transactions
                .FirstOrDefaultAsync(t => t.UID == transaction.UID && !t.IsDeleted);

            if (existingTransaction != null)
            {
                existingTransaction.Name = transaction.Name;
                existingTransaction.Description = transaction.Description;
                existingTransaction.Amount = transaction.Amount;
                existingTransaction.ModifiedDate = DateTime.UtcNow;

                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
