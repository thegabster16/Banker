using System;
using System.Collections.Generic;
using System.Linq;

namespace Capgemini
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initiali
            List<string> menu = new List<string>(new string[] {"1. Balance", "2. Deposit", "3. Withdrawal", "4. Recent Transactions", "5. Exit"});
            Dictionary<string, int> userInfo = new Dictionary<string, int>();
            userInfo.Add("1234569812456975", 5595);
            userInfo.Add("1654415154815753", 1234);
            userInfo.Add("4515481453151251", 4587);
            userInfo.Add("1545148413448597", 2353);

            Dictionary<string, double> userAcc =  new Dictionary<string, double>();
            userAcc.Add("1234569812456975", 1000.00);
            userAcc.Add("1654415154815753", 2050.00);
            userAcc.Add("4515481453151251", 7500.00);
            userAcc.Add("1545148413448597", 500.00);

            List<string> userHist = new List<string>();

            Console.WriteLine("Welcome to your local ATM!");
            Console.WriteLine("*****************************");
            Console.WriteLine("Please enter your debit/credit card number: ");

            string userInput = Console.ReadLine();
            int userPin = 0;

            if(userInput.Length < 16 || userInput.Any(x => !char.IsNumber(x)))
            {
                Console.WriteLine("Invalid card number. Program will now exit. Goodbye.");
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("An associated account has been found. Please enter PIN number: ");
                userPin = Int32.Parse(Console.ReadLine());

                if(userInfo[userInput] == userPin)
                {
                    bool cont = true;
                    int counter = 0;

                    while(cont)
                    {
                        Console.WriteLine("Account verified. How may we assist you?");
                        foreach (var m in menu)
                        {
                            Console.WriteLine(m);
                        }
                        Console.Write("Please choose an option from the list above: ");
                        switch(Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine(userAcc[userInput]); 
                                userHist.Add(menu[0] + " - " + userAcc[userInput]);
                                counter++;
                                break;
                            case "2":
                                Console.Write("Please enter the amount being deposited: ");
                                int userDepos = Int32.Parse(Console.ReadLine());
                                userAcc[userInput] += userDepos;
                                userHist.Add(menu[1] + " - " + userDepos);
                                counter++;
                                break;
                            case "3":
                                Console.WriteLine("ONLY $1000 CAN BE WITHDRAWN DURING A SINGULAR TRANSACTION. PLEASE BE ADVISED THAT A MAXIMUM OF 10 TRANSACTIONS PER DAY ARE ALLOWED!");
                                Console.Write("Please enter the amount you would like to withdraw: ");
                                int userWith = Int32.Parse(Console.ReadLine());

                                if(userWith > userAcc[userInput])
                                {
                                    Console.WriteLine("Insufficient funds available. Program will now exit.");
                                    System.Environment.Exit(0);
                                }
                                else if (userWith > 1000)
                                {
                                    Console.WriteLine("Withdrawal amount exceeds maximum limit. Program will now exit.");
                                    System.Environment.Exit(0);
                                }
                                else if (counter > 10)
                                {
                                    Console.WriteLine("Maximum withdrawal transactions have been reached. Program will now exit.");
                                    System.Environment.Exit(0);
                                }
                                else
                                {
                                    userAcc[userInput] -= userWith;
                                }
                                userHist.Add(menu[2] + " - " + userWith);
                                counter++;
                                break;
                            case "4":
                                Console.WriteLine("Transaction History: ");
                                Console.WriteLine("***********************");
                                if(userHist.Count > 5)
                                {
                                    for(int i = 0; i < userHist.Count; i++)
                                    {
                                        if(userHist.Count == 5)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            userHist.RemoveAt(i);
                                        }
                                    }
                                }
                                foreach(var h in userHist)
                                {
                                    Console.WriteLine(h.Substring(h.IndexOf(' ') + 1));
                                }
                                break;
                            default:
                                cont = false;
                                Console.WriteLine("Program will now exit. Have a great day! :) ");
                                break;
                        }
                    }  
                }
                else
                {
                    Console.WriteLine("Invalid card number. Program will now exit. Goodbye.");
                    System.Environment.Exit(0);
                }
            }
        }
    }
}
