using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking_System_OOP_Project
{
    //dfvtgbyhnujm
    public class person
    {
        public string firstname { get; set; }
        protected string lastname { get; set; }
        protected string birthdate { get; set; }
        protected string nationalid { get; set; }
    }

    public class card_holder : person 
    {
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

        public card_holder(string firstname, string lastname, int cardnumber, int pin, double Balance)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.cardnumber = cardnumber;
            this.pin = pin;
            this.Balance = Balance;
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
    }

    /* points
     * depoist !
     * withdraw !
     * login !
     * card history
     * transaction feed
     * pointing system
     * deals
     * loan system
     * multiple card system
     */

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
                Console.WriteLine("Deposit complete, new balance : " + current.Balance);
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
                Console.WriteLine("Current balance " + current.Balance);
            }

            List<card_holder> card_Holders = new List<card_holder>();
            card_Holders.Add(new card_holder("John", "Smith", 123456, 4321, 159.8));
            card_Holders.Add(new card_holder("William", "Affton", 123432, 1432, 259.86));
            card_Holders.Add(new card_holder("Mark", "Jones", 123321, 1143, 20.1));
            card_Holders.Add(new card_holder("Dawn", "Jhonsen", 654321, 4432, 1290.78));

            Console.WriteLine("ATM");
            Console.WriteLine("Enter card number");
            int debit = 0;
            card_holder currentuser;

            while (true)
            {
                try
                {
                    debit = int.Parse(Console.ReadLine());

                    currentuser = card_Holders.FirstOrDefault(a => a.cardnumber == debit);
                    if (currentuser != null)
                        break;
                    else
                        Console.WriteLine("Card not recognized, try again.");
                }
                catch { Console.WriteLine("Card not recognized, try again."); }
            }

            Console.WriteLine("Enter pin");
            int pin = 0;

            while (true)
            {
                try
                {
                    pin = int.Parse(Console.ReadLine());

                    if (currentuser.pin == pin)
                        break;
                    else
                        Console.WriteLine("incorrect pin, try again.");
                }
                catch { Console.WriteLine("incorrect pin, try again."); }
            }

            Console.WriteLine("Welcome " + currentuser.firstname);
            int option = 0;

            do
            {
                printoptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }

                if (option == 1) { deposit(currentuser); }
                else if (option == 2) { withdraw(currentuser); }
                else if (option == 3) { show(currentuser); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
            while (option != 4);
            Console.WriteLine("Have a nice day!");
        }
    }
}