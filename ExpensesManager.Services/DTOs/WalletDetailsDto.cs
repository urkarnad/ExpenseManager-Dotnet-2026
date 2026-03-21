using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager.Services.DTOs
{
    public class WalletDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }

        public List<TransactionListDto> Transactions { get; set; }
    }
}
