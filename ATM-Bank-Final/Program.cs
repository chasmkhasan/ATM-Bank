using ATM_Bank_Final;
using System.Net.NetworkInformation;

// List<Transaction> transactions = new List<Transaction>();

// Method to perform a deposit
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

var user = new List<Users>()
        {
            new Users
            {
                userName = "kristian",
                pin = 4455,
                accounts = new List<Account>
                {
                    new Account{accountName = "kristian-isk",     balance = 100.59 },
                    new Account{accountName = "kristian-savings", balance = 200.59 },
                }
            },
            new Users
            {
                userName = "tomas",
                pin = 1122,
                accounts = new List<Account>
                {
                    new Account{accountName = "tomas-savings", balance = 100.59 },
                    new Account{accountName = "tomas-isk",     balance = 200.59 },
                    new Account{accountName = "tomas-salary",  balance = 300.59 },
                }
            },
            new Users
            {
                userName = "stefan",
                pin = 2233,
                accounts = new List<Account>
                {
                    new Account{accountName = "stefan-savings", balance = 100.59 },
                    new Account{accountName = "stefan-isk",     balance = 200.59 },
                    new Account{accountName = "stefan-salary",  balance = 300.59 },
                    new Account{accountName = "stefan-child",   balance = 400.59 },

                }
            },
            new Users
            {
                userName = "dimitar",
                pin = 3344,
                accounts = new List<Account>
                {
                    new Account{accountName = "dimitar-savings", balance = 100.59 },
                    new Account{accountName = "dimitar-isk",     balance = 200.59 },
                    new Account{accountName = "dimitar-salary",  balance = 300.59 },
                    new Account{accountName = "dimitar-child",   balance = 400.59 },
                    new Account{accountName = "dimitar-parent",  balance = 500.59 },
                }
            },
            new Users
            {
                userName = "krille",
                pin = 5566,
                accounts = new List<Account>
                {
                    new Account{accountName = "krille-savings", balance = 100.59 },
                    new Account{accountName = "krille-isk",     balance = 200.59 },
                    new Account{accountName = "krille-salary",  balance = 300.59 },
                    new Account{accountName = "krille-child",   balance = 400.59 },
                    new Account{accountName = "krille-parent",  balance = 500.59 },
                    new Account{accountName = "krille-family",  balance = 600.59 },
                }
            },
            new Users
            {
                userName = "chritofer",
                pin = 6677,
                accounts = new List<Account>
                {
                    new Account{accountName = "chritofer-savings", balance = 100.59 },
                    new Account{accountName = "chritofer-isk",     balance = 200.59 },
                    new Account{accountName = "chritofer-salary",  balance = 300.59 },
                    new Account{accountName = "chritofer-child",   balance = 400.59 },
                    new Account{accountName = "chritofer-parent",  balance = 500.59 },
                    new Account{accountName = "chritofer-family",  balance = 600.59 },
                    new Account{accountName = "chritofer-pension", balance = 700.59 },
                }
            },
    // other users...
        };
Users[] users = user.ToArray();


Console.WriteLine("**** Welcome to our Bank Management System ****\n");

bool isrunning = true;
int PIN;
login:
while (isrunning)
{
    Console.WriteLine("1. Logging to existing accountholder -----");
    Console.WriteLine("2. Exit from the program----");
    Console.WriteLine("====>");
    var menuoption = Convert.ToInt32(Console.ReadLine());

    switch (menuoption)
    {
        case 1:

            bool inlogging = true;

            while (inlogging)
            {
                int loggingattempts = 0;

                Console.WriteLine("Enter your UserName:");
                string username = Console.ReadLine().ToLower();
                Console.WriteLine("Enter your PIN:");
                int pin = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("====>");

                var userAccounts = users.FirstOrDefault(u => u.userName == username && u.pin == pin);

                //if you failed to put wrong username and pin app will continue the menu but unable to see exiting information.

                if (userAccounts != null)
                {
                    Console.WriteLine("\nExisting Accounts and Balance information are below. Please press following option.\n");
                    foreach (var account in userAccounts.accounts)
                    {
                        Console.WriteLine($"Account: {account.accountName}, Balance: {account.balance}");
                    }

                    bool mainMenu = true;
                    while (mainMenu)
                    {
                        Console.WriteLine("\n1. Deposit Money -----------------------------------");
                        Console.WriteLine("2. Transfer Money ------------------------------------");
                        Console.WriteLine("3. Withdraaw Money -----------------------------------");
                        Console.WriteLine("4. Transactions History ------------------------------");
                        Console.WriteLine("5. Log Out - if another accountholder wants to logging in! ----");
                        Console.WriteLine("====>\n");

                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                if (userAccounts != null)
                                {
                                    Console.WriteLine("Which account would you like to Deposit? Please write below Account Name: \n");

                                    for (int i = 0; i < userAccounts.accounts.Count; i++)
                                        Console.WriteLine($"{i + 1}.{userAccounts.accounts[i].accountName} - {userAccounts.accounts[i].balance}");
                                    var selectedAccount = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Enter the amount you want to Deposit:");
                                    var amount = double.Parse(Console.ReadLine());
                                    userAccounts.accounts[selectedAccount - 1].balance += amount;
                                    Console.WriteLine($"Successfully deposited {amount} to {userAccounts.accounts[selectedAccount - 1].accountName}");
                                    //transactions.Add(Deposit(selectedAccount, amount));
                                    userAccounts.accounts[selectedAccount - 1].transactions.Add(new Transaction
                                    {
                                        type = "Deposit",
                                        amount = amount,
                                        accountName = userAccounts.accounts[selectedAccount - 1].accountName,
                                        timestamp = DateTime.Now
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
                                    for (int i = 0; i < userAccounts.accounts.Count; i++)
                                        Console.WriteLine($"{i + 1}. {userAccounts.accounts[i].accountName} - {userAccounts.accounts[i].balance}");
                                    var fromAccount = int.Parse(Console.ReadLine()) - 1;

                                    Console.WriteLine("Which account would you like to Transfer to?");
                                    for (int i = 0; i < userAccounts.accounts.Count; i++)
                                        Console.WriteLine($"{i + 1}. {userAccounts.accounts[i].accountName} - {userAccounts.accounts[i].balance}");
                                    var toAccount = int.Parse(Console.ReadLine()) - 1;

                                    Console.WriteLine("Enter the amount you want to transfer:");
                                    var amount = double.Parse(Console.ReadLine());

                                    if (userAccounts.accounts[fromAccount].balance >= amount)
                                    {
                                        userAccounts.accounts[fromAccount].balance -= amount;
                                        userAccounts.accounts[toAccount].balance += amount;
                                        Console.WriteLine($"Successfully transferred {amount} from {userAccounts.accounts[fromAccount].accountName} to {userAccounts.accounts[toAccount].accountName}");
                                        userAccounts.accounts[fromAccount].transactions.Add(new Transaction
                                        {
                                            type = "Transfer",
                                            amount = amount,
                                            accountName = userAccounts.accounts[fromAccount].accountName,
                                            timestamp = DateTime.Now
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

                                    if (PIN != pin)
                                    {
                                        Console.WriteLine("Invaild account NAME or PINCODE");
                                        break;
                                    }

                                    Console.WriteLine("\nWhich account would you like to Withdraw?");

                                    for (int i = 0; i < userAccounts.accounts.Count; i++)
                                        Console.WriteLine($"{i + 1}. {userAccounts.accounts[i].accountName} - {userAccounts.accounts[i].balance}");
                                    var selectedAccount = int.Parse(Console.ReadLine()) - 1;

                                    /*-1 is substracted from the parsed number, this is done to make sure that the user's input corresponds to the index of the account in the list.
                                    In most cases, when displaying a list of items to the user, the items are numbered starting from 1, but when working with lists in programming, the indexing usually starts at 0.
                                    So, by subtracting 1, you are mapping the user's input to the corresponding index in the list of accounts.*/

                                    Console.WriteLine("Enter the amount you want to withdraw:");
                                    var amount = double.Parse(Console.ReadLine());

                                    if (userAccounts.accounts[selectedAccount].balance >= amount)
                                    {
                                        userAccounts.accounts[selectedAccount].balance -= amount;
                                        Console.WriteLine($"Successfully withdrew {amount} from {userAccounts.accounts[selectedAccount].accountName}");
                                        userAccounts.accounts[selectedAccount].transactions.Add(new Transaction
                                        {
                                            type = "Withdraw",
                                            amount = amount,
                                            accountName = userAccounts.accounts[selectedAccount].accountName,
                                            timestamp = DateTime.Now
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
                                    for (int i = 0; i < userAccounts.accounts.Count; i++)
                                        Console.WriteLine($"{i + 1}. {userAccounts.accounts[i].accountName} - {userAccounts.accounts[i].balance}");
                                    var selectedAccount = int.Parse(Console.ReadLine()) - 1;
                                    var transactions = userAccounts.accounts[selectedAccount].transactions;

                                    if (transactions.Count > 0)
                                    {
                                        Console.WriteLine("Transaction history:");
                                        for (int i = 0; i < transactions.Count; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. Type: {transactions[i].type}, Amount: {transactions[i].amount}, Account: {transactions[i].accountName}, Date: {transactions[i].timestamp}");
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


                else if (userAccounts == null || loggingattempts <= 3)
                {
                    Console.WriteLine("Invalid input!! You will get max 3 times to logging.\n");
                    loggingattempts++;
                }
                else
                    goto login;


            }
            break;

        case 2:
            return;
    }
}