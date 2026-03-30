CREATE DATABASE PersonalWallet
GO

USE PersonalWallet
Go

CREATE TABLE Accounts (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Type INT NOT NULL,                -- Enum: AccountType
    BalanceAmount DECIMAL(18,2) NOT NULL
    );
GO

CREATE TABLE Transactions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AccountId INT NOT NULL,
    Type INT NOT NULL,                 -- Enum: TransactionType
    Amount DECIMAL(18,2) NOT NULL,
    Date DATETIME NOT NULL,

    CONSTRAINT FK_Transactions_Accounts
        FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
);
GO
