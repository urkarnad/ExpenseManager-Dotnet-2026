# ExpenseManager-Dotnet-2026


**Expense Manager** is a console application for managing wallets (accounts) and their related transactions.

Each wallet contains a collection of transactions that logically belong to it.  
The application allows users to:

- View all wallets
- See detailed wallet information
- Browse related transactions
- Exit the application safely


## Solution Structure

The solution is divided into (4) projects, each responsible for a specific layer of the application.

### ExpensesManager.Storage

Contains entities and enums:

- `Wallet` — represents a wallet/account
- `Transaction` — represents a financial transaction
- `Currency` — enumeration related to `Wallet` (and `Transaction`)
- `TransactionCategory` — enumeration related to `Transaction`

This layer is responsible only for data storage structures.


### ExpensesManager.Services

Responsible for interaction with data storage.

Includes:

- `FakeStorage` — static storage pre-filled with data
- `WalletService` — provides access to wallet data
- `TransactionService` — provides access to transaction data

Only this layer has access to `FakeStorage`.  
Other projects interact with storage exclusively through services.


### ExpensesManager.Presentation

Responsible for creating, displaying, and interacting with entities.

Includes:

- `WalletManager`
- `TransactionManager`

These classes use Services and do not work directly with Storage.


### ExpensesManager.ConsoleApp

The entry point of the application.

Responsible for:

- Initializing services and managers
- Handling user input
- Displaying information in the console
- Managing application flow

