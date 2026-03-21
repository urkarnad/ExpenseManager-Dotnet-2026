using ExpensesManager.Services.DTOs;

namespace ExpensesManager.Services.Interfaces;

public interface IWalletService
{
    IEnumerable<WalletListDto> GetAll();
    WalletDetailsDto GetById(Guid id);
}