using System;
using System.Collections.Generic;
using System.Linq;

//  Sets up user object
public class User
{
    // defines properties
    public string Prefix { get; set; }
    public string Suffix { get; set; }
    public string UserID { get; set; }

    public User(string prefix, string suffix, string userID)
    {
        
        Prefix = prefix;
        Suffix = suffix;
        UserID = userID;
    }
    // overrides inherited ToString()
    public override string ToString()
    {
        return "[Prefix = " + Prefix + ", Suffix = " + Suffix + ", userID = " + UserID + "]";
    }
}

public class ArrayListCRUD
{
    public static void Main()
    {
        // creates variable running of typle bool and sets equal to true
        bool running = true;
        // creates the variable users and sets it equal to a new instance of Dictionary
        var users = new Dictionary<string, User>();

        Console.WriteLine("Welcome to you user database! \n");
        Console.WriteLine("Please choose one of these menu options: ");

        do
        {
            Console.WriteLine("[ C - Create | R - Read | U - Update | D - Delete | P - Print | Q - Quit ]");
            Console.Write("Input: ");
            
            //takes in user input via Console.ReadLine() and calls the appropiate method based on the valid case
            switch (Console.ReadLine())
            {
                case "C":
                case "c":
                    CreateUser(users);
                    break;

                case "R":
                case "r":
                    ReadUser(users);
                    break;

                case "U":
                case "u":
                    UpdateUser(users);
                    break;

                case "D":
                case "d":
                    DeleteUser(users);
                    break;

                case "P":
                case "p":
                    PrintAll(users);
                    break;

                case "Q":
                case "q":
                    running = false; // assigns false value to the running variable and effectively exiting the 'do-while' loop
                    break;
            }
        } while (running);
    }
    // Defining CreateUser method
    static void CreateUser(IDictionary<string, User> users)
    {
        Console.Write("Please enter an ID: ");
        string userID = null;
        
        do
        {
            userID = Console.ReadLine();

            if (users.ContainsKey(userID))//verify if userID already exists
            {
                Console.WriteLine("\nA user with this ID already exists, please try again.\n");
            }
        } while (userID == null || users.ContainsKey(userID));
        
        Console.Write("Please enter a prefix: ");
        string prefix = Console.ReadLine();
        Console.Write("Please enter a suffix: ");
        string suffix = Console.ReadLine();


        var user = new User(prefix, suffix, userID);//new instance of User object
        users.Add(userID, user);
        Console.WriteLine("\n" + user + "\n");
    }
    //Defining ReadUser method
    static void ReadUser(IDictionary<string, User> users)
    {
        Console.Write("Please enter the user's ID: ");
        string userID = Console.ReadLine();

        if (users.ContainsKey(userID))
        {
            Console.WriteLine("\n" + userID + ": " + users[userID] + "\n");
        }
        else
        {
            Console.WriteLine("\n ***No such user*** \n");
        }
    }
    //Defining UpdateUser method
    static void UpdateUser(IDictionary<string, User> users)
    {
        Console.Write("Please enter the user's ID: ");
        string userID = Console.ReadLine();

        if (users.ContainsKey(userID))
        {
            //'Updates' by showing requested userID, removing it and creating a new record
            Console.WriteLine("\nCurrent information: " + users[userID]);
            users.Remove(userID); 
            CreateUser(users);
        }
    }
    //Defining DeleteUser method
    static void DeleteUser(IDictionary<string, User> users)
    {
        Console.Write("Please enter the user's ID: ");
        string userID = Console.ReadLine();
        Console.WriteLine();

        if (!users.Remove(userID)) Console.WriteLine("***No such user*** \n");
    }
    //Defining PrintAll method
    static void PrintAll(IDictionary<string, User> users)
    {
        if (users.Any())//if there are records in the Dictionary, loops over them to print each one using foreach loop
        {
            foreach (var user in users.Values.OrderBy(value => value.UserID))
            {
                Console.WriteLine(user);
            }
        }
        else
        {
            Console.WriteLine("To fill this empty table, enter 'C'.");
        }
    }
} 
