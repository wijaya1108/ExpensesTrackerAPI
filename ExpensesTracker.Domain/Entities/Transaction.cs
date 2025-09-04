using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Domain.Entities
{
    public class Transaction
    {
        public Guid UID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }

        public Guid UserUID { get; set; }
        public User User { get; set; }

        public int TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
