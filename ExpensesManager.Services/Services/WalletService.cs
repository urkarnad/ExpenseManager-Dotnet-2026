using System;
using System.Collections.Generic;
using System.Linq;
using ExpensesManager.Storage.Entities;
using ExpensesManager.Services.Storage;

namespace ExpensesManager.Services.Services;

public class WalletService
{
    public IEnumerable<Wallet> GetAllWallets()
    {
        return FakeStorage.Wallets;
    }

    public Wallet? GetWalletById(Guid id)
    {
        return FakeStorage.Wallets.FirstOrDefault(w => w.Id == id);
    }
}
