using ExpensesManager.Services.DTOs;
using ExpensesManager.Storage.Enums;

namespace ExpensesManager.Services.Interfaces;

public interface IWalletService
{
    Task<IEnumerable<WalletListDto>> GetAllAsync();
    Task<WalletDetailsDto> GetByIdAsync(Guid id);
    Task<WalletListDto> AddAsync(string name, Currency currency);
    Task UpdateAsync(Guid id, string name, Currency currency);
    Task DeleteAsync(Guid id);
}