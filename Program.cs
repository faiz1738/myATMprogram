using System;
using System.Collections.Generic;
using System.Linq;

public class cardHolder
{
    //here i am declaring all of the variables
    String cardNum;
    String firstName;
    String lastName;
    int pin;
    double balance;


    //initliase constuctor and pass in the parameters
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        //instantiated as objects
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    //these just return the numbers/values i want
    public String getNum()
    {return cardNum;}
    public int getPin()
    {return pin;}
    public String getFirstName()
    {return firstName;
    }
    public String getLastName()
    { return lastName;
    }
    public double getBalance()
    { return balance;
    }
    //just creates new numbers
    public void setNum(String newCardNum)
    {cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {pin = newPin;
    }
    public void setFirstName(String newFirstName)
    {firstName = newFirstName;
    }
    public void setLastName(String newLastName)
    {lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {balance = newBalance;
    }

    //main method
    public static void Main(String[] args)
    {
        //gives users menu of options after they have entered their card numbers
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following:");
            Console.WriteLine("1. Withdraw");
            Console.WriteLine("2. Show balance");
            Console.WriteLine("3. Exit");
        }

        //name the user, pass in the whole object
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("Select the amount to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //money check
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient funds! ");
            }
            else
            {
                //when they do have enough money
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Success");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Your balance at the moment is showing as: " + currentUser.getBalance());
        }

        //specify the object to contain, its card holders
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("111", 1111, "Faiz", "Anwar", 299.99));
        cardHolders.Add(new cardHolder("222", 2222, "John", " ", 6000000));
        cardHolders.Add(new cardHolder("333", 3333, "Nikola", "Zigic", 100.00));

        //prompt user
        Console.WriteLine("Welcome to this machine");
        Console.WriteLine("This machine charges £3.95 to use");
        Console.WriteLine("Please type your card number");
        //initliased but not equal to anything yet
        String debitCardNum = "";
        cardHolder currentUser;

       
        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check
                //current user, then ref our list, then fod method cycles through each item in list
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Error! try again!"); }
            }
            catch { Console.WriteLine("Sorry, we cannot process your request right now. "); }
        }

        Console.WriteLine("ENTER YOUR PIN NOW! ");
        int userPin = 0;

        while (true)
        {
            //used try and catch to define code for testing and then in case of error
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //we already have a current user so no need to check again
                //we're checking against database
                if (currentUser.getPin() == userPin) { break; }
                //if its right, break out of loop
                else { Console.WriteLine("Error! try again!"); }
            }
            catch { Console.WriteLine("Sorry, we cannot process your request right now. "); }
        }
        
        Console.WriteLine("Welcome " + currentUser.getFirstName() + " , it is a beautiful day today");
        int option = 0;
        do
        //do bc it runs code then exits 
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            //if (option == 1) { deposit(currentUser); }
            if (option == 1) { withdraw(currentUser); }
            else if (option == 2) { balance(currentUser); }
            else if (option == 3) { break; }
            else { option = 0; }

        }
        while (option != 3);
        Console.WriteLine("Thank you, come again!");

        
    }
}