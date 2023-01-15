using ATM_Bank_Final;
using System.Net.NetworkInformation;
using System.Security.Principal;

// List<Transaction> transactions = new List<Transaction>();

// Method to perform a deposit
// below three method will keep to clear information about Deposit, Withdraw and transfer.

//static void Deposit(Account account, double amount)
//{
//    account.balance += amount;
//    account.transactions.Add(new Transaction
//    {
//        type = "Deposit",
//        amount = amount,
//        accountName = account.accountName,
//        timestamp = DateTime.Now
//    });
//}

//// Method to perform a withdraw
//static void Withdraw(Account account, double amount)
//{
//    account.balance -= amount;
//    account.transactions.Add(new Transaction
//    {
//        type = "Withdraw",
//        amount = amount,
//        accountName = account.accountName,
//        timestamp = DateTime.Now
//    });
//}

//// Method to perform a transfer
//static void Transfer(Account fromAccount, Account toAccount, double amount)
//{
//    fromAccount.balance -= amount;
//    toAccount.balance += amount;
//    fromAccount.transactions.Add(new Transaction
//    {
//        type = "Transfer",
//        amount = amount,
//        accountName = fromAccount.accountName,
//        timestamp = DateTime.Now
//    });
//    toAccount.transactions.Add(new Transaction
//    {
//        type = "Transfer",
//        amount = amount,
//        accountName = toAccount.accountName,
//        timestamp = DateTime.Now
//    });
//}

// group list has bee made can call each user. Since each user hold different amount of bank account.

var user = new List<Users>()
        {
            new Users
            {
                UserName = "kristian",
                Pin = 4455,
                Accounts = new List<Account>
                {
                    new Account{AccountName = "kristian-isk",     Balance = 100.59 },
                    new Account{AccountName = "kristian-savings", Balance = 200.59 },
                }
            },
            new Users
            {
                UserName = "tomas",
                Pin = 1122,
                Accounts = new List<Account>
                {
                    new Account{AccountName = "tomas-savings", Balance = 100.59 },
                    new Account{AccountName = "tomas-isk",     Balance = 200.59 },
                    new Account{AccountName = "tomas-salary",  Balance = 300.59 },
                }
            },
            new Users
            {
                UserName = "stefan",
                Pin = 2233,
                Accounts = new List<Account>
                {
                    new Account{AccountName = "stefan-savings", Balance = 100.59 },
                    new Account{AccountName = "stefan-isk",     Balance = 200.59 },
                    new Account{AccountName = "stefan-salary",  Balance = 300.59 },
                    new Account{AccountName = "stefan-child",   Balance = 400.59 },

                }
            },
            new Users
            {
                UserName = "dimitar",
                Pin = 3344,
                Accounts = new List<Account>
                {
                    new Account{AccountName = "dimitar-savings", Balance = 100.59 },
                    new Account{AccountName = "dimitar-isk",     Balance = 200.59 },
                    new Account{AccountName = "dimitar-salary",  Balance = 300.59 },
                    new Account{AccountName = "dimitar-child",   Balance = 400.59 },
                    new Account{AccountName = "dimitar-parent",  Balance = 500.59 },
                }
            },
            new Users
            {
                UserName = "krille",
                Pin = 5566,
                Accounts = new List<Account>
                {
                    new Account{AccountName = "krille-savings", Balance = 100.59 },
                    new Account{AccountName = "krille-isk",     Balance = 200.59 },
                    new Account{AccountName = "krille-salary",  Balance = 300.59 },
                    new Account{AccountName = "krille-child",   Balance = 400.59 },
                    new Account{AccountName = "krille-parent",  Balance = 500.59 },
                    new Account{AccountName = "krille-family",  Balance = 600.59 },
                }
            },
            new Users
            {
                UserName = "christofer",
                Pin = 6677,
                Accounts = new List<Account>
                {
                    new Account{AccountName = "christofer-savings", Balance = 100.59 },
                    new Account{AccountName = "christofer-isk",     Balance = 200.59 },
                    new Account{AccountName = "christofer-salary",  Balance = 300.59 },
                    new Account{AccountName = "christofer-child",   Balance = 400.59 },
                    new Account{AccountName = "christofer-parent",  Balance = 500.59 },
                    new Account{AccountName = "christofer-family",  Balance = 600.59 },
                    new Account{AccountName = "christofer-pension", Balance = 700.59 },
                }
            },
    // other users...
        };
Users[] users = user.ToArray();

// welcome note for user.
Console.WriteLine("**** Welcome to our Bank Management System ****\n");

bool isrunning = true;
int PIN;

while (isrunning)
{
    // This part will work for existing user logging.

    Console.WriteLine("1. Logging to existing accountholder -----");
    Console.WriteLine("2. Exit from the program------------------");
    Console.WriteLine("====>");
    var menuoption = Convert.ToInt32(Console.ReadLine());

    // logging failure.
    int loggingattempts = 0;

    // menuoption switch has been run only for logging and exit.
    switch (menuoption)
    {
        

        case 1:
            
            bool inlogging = true;

            while (inlogging)
            {
            login:
                
                // existing correct user input.

                Console.WriteLine("Enter your UserName:");
                string username = Console.ReadLine().ToLower(); // user can put capital or small letter it will convert to lower case.
                Console.WriteLine("Enter your PIN:");
                int pin = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("====>");

                // this function fork for call data from list.
                var userAccounts = users.FirstOrDefault(u => u.UserName == username && u.Pin == pin);

                //if you failed to put wrong username and pin app will continue the menu but unable to see exiting information.

                if (userAccounts != null)
                {
                    Console.WriteLine("\nExisting Accounts and Balance information are below. Please press following option.\n");
                    // varible has been declear above, so this case we need to use foreach loop to list data.
                    foreach (var account in userAccounts.Accounts)
                    {
                        Console.WriteLine($"Account: {account.AccountName}, Balance: {account.Balance}");
                    }

                    bool mainMenu = true;
                    while (mainMenu)
                    {
                        Console.WriteLine("\n1. Deposit Money -----------------------------------------------");
                        Console.WriteLine("2. Transfer between Account ------------------------------------");
                        Console.WriteLine("3. Withdraaw Money ---------------------------------------------");
                        Console.WriteLine("4. Transactions History ----------------------------------------");
                        Console.WriteLine("5. Log Out - if another accountholder wants to logging in! -----");
                        Console.WriteLine("====>\n");

                        string choice = Console.ReadLine();
                        

                        switch (choice)
                        {
                            case "1":
                                if (userAccounts != null)
                                {
                                    Console.WriteLine("Which account would you like to Deposit? Please write the one of the serial number.: \n");

                                    // for loop will print out existing account information. 
                                    for (int i = 0; i < userAccounts.Accounts.Count; i++)
                                    { 
                                        Console.WriteLine($"{i + 1}.{userAccounts.Accounts[i].AccountName}:- {userAccounts.Accounts[i].Balance}");
                                    }
                                    
                                    var selectedAccount = int.Parse(Console.ReadLine());
                                    if (selectedAccount > userAccounts.Accounts.Count)
                                    {
                                        Console.WriteLine("Invalid input. You have to write above serianl number.");
                                        break;
                                    }

                                    Console.WriteLine("Enter the amount you want to Deposit:");
                                    //var amount = double.Parse(Console.ReadLine());
                                    var amountIsConverted = int.TryParse(Console.ReadLine(), out var amountToDeposit);
                                    if (!amountIsConverted)
                                    {
                                        Console.WriteLine("Wrong input");
                                        break;
                                    }
                                    userAccounts.Accounts[selectedAccount - 1].Balance += amountToDeposit;
                                    
                                    Console.WriteLine($"Successfully deposited {amountToDeposit} to {userAccounts.Accounts[selectedAccount - 1].AccountName}");
                                        //transactions.Add(Deposit(selectedAccount, amount));
                                        userAccounts.Accounts[selectedAccount - 1].Transactions.Add(new Transaction
                                        {
                                            Type = "Deposit",
                                            Amount = amountToDeposit,
                                            AccountName = userAccounts.Accounts[selectedAccount - 1].AccountName,
                                            Timestamp = DateTime.Now
                                        });
                                    
                                }
                                
                                else
                                {
                                    Console.WriteLine("Invalid username or PIN.");
                                }

                                break;
                            case "2":
                                if (userAccounts != null)
                                {
                                    Console.WriteLine("Which account would you like to Transfer from? ");
                                    for (int i = 0; i < userAccounts.Accounts.Count; i++)
                                    { 
                                        Console.WriteLine($"{i + 1}. {userAccounts.Accounts[i].AccountName} :- {userAccounts.Accounts[i].Balance}");
                                    }

                                    var fromAccount = int.Parse(Console.ReadLine()) - 1;
                                    if (fromAccount > userAccounts.Accounts.Count)
                                    {
                                        Console.WriteLine("Invalid input. You have to write above serianl number.");
                                        break;
                                    }

                                    Console.WriteLine("Which account would you like to Transfer to?");
                                    for (int i = 0; i < userAccounts.Accounts.Count; i++)
                                    { 
                                        Console.WriteLine($"{i + 1}. {userAccounts.Accounts[i].AccountName} :- {userAccounts.Accounts[i].Balance}");
                                    }
                                    
                                    var toAccount = int.Parse(Console.ReadLine()) - 1;
                                    if (toAccount > userAccounts.Accounts.Count)
                                    {
                                        Console.WriteLine("Invalid input. You have to write above serianl number.");
                                        break;
                                    }

                                    Console.WriteLine("Enter the amount you want to transfer:");
                                    //var amount = double.Parse(Console.ReadLine());

                                    var transferIsConverted = int.TryParse(Console.ReadLine(), out var transferToDeposit);
                                    if (!transferIsConverted)
                                    {
                                        Console.WriteLine("Wrong input");
                                        break;
                                    }

                                    if (userAccounts.Accounts[fromAccount].Balance >= transferToDeposit)
                                    {
                                        userAccounts.Accounts[fromAccount].Balance -= transferToDeposit;
                                        userAccounts.Accounts[toAccount].Balance += transferToDeposit;
                                        Console.WriteLine($"Successfully transferred {transferToDeposit} from {userAccounts.Accounts[fromAccount].AccountName} to {userAccounts.Accounts[toAccount].AccountName}");
                                        
                                        userAccounts.Accounts[fromAccount].Transactions.Add(new Transaction
                                        {
                                            Type = "Transfer",
                                            Amount = transferToDeposit,
                                            AccountName = userAccounts.Accounts[fromAccount].AccountName,
                                            Timestamp = DateTime.Now
                                        });
                                    }
                                    else
                                    {
                                        Console.WriteLine("Insufficient funds!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid username or PIN.");
                                }

                                break;

                            case "3":
                                if (userAccounts != null)
                                {
                                    Console.WriteLine("Please confirm your pin.");
                                    PIN = Convert.ToInt32(Console.ReadLine());

                                    // need to put pin number, which is comes from list.
                                    if (PIN != pin)
                                    {
                                        Console.WriteLine("Invaild account NAME or PINCODE");
                                        break;
                                    }

                                    Console.WriteLine("\nWhich account would you like to Withdraw?");

                                    for (int i = 0; i < userAccounts.Accounts.Count; i++)
                                    { 
                                        Console.WriteLine($"{i + 1}. {userAccounts.Accounts[i].AccountName} :- {userAccounts.Accounts[i].Balance}");
                                    }
                                    
                                    var selectedAccount = int.Parse(Console.ReadLine()) - 1;
                                    if (selectedAccount > userAccounts.Accounts.Count)
                                    {
                                        Console.WriteLine("Invalid input. You have to write above serianl number.");
                                        break;
                                    }


                                    /*-1 is substracted from the parsed number, this is done to make sure that the user's input corresponds to the index of the account in the list.
                                    In most cases, when displaying a list of items to the user, the items are numbered starting from 1, but when working with lists in programming, the indexing usually starts at 0.
                                    So, by subtracting 1, you are mapping the user's input to the corresponding index in the list of accounts.*/

                                    Console.WriteLine("Enter the amount you want to withdraw:");
                                    //var amount = double.Parse(Console.ReadLine());

                                    var withdrawIsConverted = int.TryParse(Console.ReadLine(), out var withdrawToDeposit);
                                    if (!withdrawIsConverted)
                                    {
                                        Console.WriteLine("Wrong input");
                                        break;
                                    }

                                    if (userAccounts.Accounts[selectedAccount].Balance >= withdrawToDeposit)
                                    {
                                        userAccounts.Accounts[selectedAccount].Balance -= withdrawToDeposit;
                                        Console.WriteLine($"Successfully withdrew {withdrawToDeposit} from {userAccounts.Accounts[selectedAccount].AccountName}");
                                        
                                        userAccounts.Accounts[selectedAccount].Transactions.Add(new Transaction
                                        {
                                            Type = "Withdraw",
                                            Amount = withdrawToDeposit,
                                            AccountName = userAccounts.Accounts[selectedAccount].AccountName,
                                            Timestamp = DateTime.Now
                                        });
                                    }
                                    else
                                    {
                                        Console.WriteLine("Insufficient funds!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid username or PIN.");
                                }

                                break;
                            case "4":
                                if (userAccounts != null)
                                {
                                    Console.WriteLine("Which account would you like SEE the Transaction? Please select the option below:");
                                    
                                    for (int i = 0; i < userAccounts.Accounts.Count; i++)
                                    { 
                                        Console.WriteLine($"{i + 1}. {userAccounts.Accounts[i].AccountName} :- {userAccounts.Accounts[i].Balance}");
                                    }

                                    var selectedAccount = int.Parse(Console.ReadLine()) - 1;

                                    if (selectedAccount > userAccounts.Accounts.Count)
                                    {
                                        Console.WriteLine("Invalid input. You have to write above serianl number.");
                                        break;
                                    }

                                    var transactions = userAccounts.Accounts[selectedAccount].Transactions;

                                    if (transactions.Count > 0)
                                    {
                                        Console.WriteLine("Transaction history:");
                                        for (int i = 0; i < transactions.Count; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. Type: {transactions[i].Type}, Amount: {transactions[i].Amount}, Account: {transactions[i].AccountName}, Date: {transactions[i].Timestamp}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No transaction history found");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid username or PIN.");
                                }
                                break;

                            case "5":
                                goto login;

                            default:
                                Console.WriteLine("Invalid Input, please put 1 or 2 or 3 or 4 or 5");
                                break;
                        }
                    }
                }


                else if (userAccounts == null && loggingattempts <= 3)
                {

                    Console.WriteLine("Invalid input!! Please check valid information to go foreward. You will get max 3 times to logging.\n");
                    loggingattempts++;
                    //goto login;

                }
                else
                    break;
                
                

            }
            break;

        case 2:
            return;
    }
}