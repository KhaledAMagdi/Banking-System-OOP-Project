using System;
using System.Collections.Generic;

namespace Banking_System_OOP_Project
{
    public class card_holder
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int cardnumber { get; set; }
        public int pin { get; set; }
        private double balance;

        public double Balance
        {
            get { return balance; }
            set
            {
                if (value > 0)
                    balance = value;
            }
        }

        public card_holder(string firstname, string lastname, int cardnumber, int pin, double balance)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.cardnumber = cardnumber;
            this.pin = pin;
            this.balance = Balance;
        }

        public void deposit(double amount)
        {
            Balance += amount;
        }

        public bool withdraw(double amount)
        {
            if (Balance < amount)
                return false;
            else
            {
                Balance -= amount;
                return true;
            }
        }

        /* points
         * depoist
         * withdraw
         * login
         * card history
         * transaction feed
         * pointing system
         * deals
         * loan system
         * multiple card system
         */
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            void printoptions()
            {
                Console.WriteLine("Please choose from one of the following options...");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
            }

            void deposit(card_holder current)
            {
                Console.WriteLine("Enter amount of deposit: ");
                double amount = double.Parse(Console.ReadLine());
                current.deposit(amount);
                Console.Write("Deposit complete, new balance : " + current.Balance);
            }

            void withdraw(card_holder current)
            {
                Console.WriteLine("Enter amount of withdraw: ");
                double amount = double.Parse(Console.ReadLine());
                if (current.withdraw(amount))
                    Console.WriteLine("Withdraw complete, new balance " + current.Balance);
                else
                    Console.WriteLine("Withdraw error, Insuffient funds ");
            }

            void show(card_holder current)
            {
                Console.WriteLine("Current balance "+current.Balance);
            }

            List<card_holder> card_Holders = new List<card_holder>();
            card_Holders.Add(new card_holder("John", "Smith", 123456, 4321, 159.8));
            card_Holders.Add(new card_holder("William", "Affton", 123432, 1432, 259.86));
            card_Holders.Add(new card_holder("Mark", "Jones", 123321, 1143, 20.1));
            card_Holders.Add(new card_holder("Dawn", "Jhonsen", 654321, 4432, 1290.78));

            Console.WriteLine("ATM");
            Console.WriteLine("Enter card number");

        }
    }
}