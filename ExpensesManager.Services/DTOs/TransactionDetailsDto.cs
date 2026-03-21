using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpensesManager.Storage.Enums;
using ExpensesManager.Storage.Interfaces;

namespace ExpensesManager.Services.DTOs
{
    public class TransactionDetailsDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public TransactionCategory Category { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
