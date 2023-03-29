// See https://aka.ms/new-console-template for more information
using BankNUnit;

Console.WriteLine("Hello, Bank!");

var account = new BankAccount();
account.Deposit(0);

Console.WriteLine(account.Balance);
