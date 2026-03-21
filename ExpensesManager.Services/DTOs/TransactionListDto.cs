using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Services.DTOs
{
    public class TransactionListDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
    }
}
