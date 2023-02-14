﻿using FlashCards;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient;

namespace Flashcards;

class Program
{
    static void Main()
    {
        bool endApp = false;

        while (!endApp)
        {
            Console.Clear();
            Console.WriteLine("\n-------------------------------\n");
            Console.WriteLine("\tFLASHCARDS");
            Console.WriteLine("\n-------------------------------");
            Console.WriteLine("1. Manage Stacks");            
            Console.WriteLine("2. Study");
            Console.WriteLine("3. Study Session");
            Console.WriteLine("4. Exit");
            Console.WriteLine("-------------------------------");
            Console.Write("Your option: ");

            var userOption = Console.ReadLine();
            switch (userOption)
            {
                case "1":
                    StackMenu();
                    break;
                case "2":
                    break; 
                case "3":
                    break;
                case "4":
                    break;
                default:
                    break;
            }
        }
    }
    internal static void StackMenu()
    {
        Console.Clear();
        Console.WriteLine("\n-------------------------------\n");
        Console.WriteLine("\tMANAGE STACKS");
        Console.WriteLine("\n-------------------------------");
        Console.WriteLine("-------------------------------");
        Console.WriteLine("1. Create a new stack");
        Console.WriteLine("2. Update stack");
        Console.WriteLine("3. Delete stack");
        Console.WriteLine("4. Manage cards");
        Console.WriteLine("-------------------------------");
        Console.Write("Your option: ");

        var userOption = Console.ReadLine();
        switch (userOption)
        {
            case "1":
                UserInputs ip = new();
                var cardTableName = ip.GetStringInputs("Your stack name is: ");
                DatabaseCreate db = new(cardTableName);
                Console.ReadLine();
                break;
            case "2":
                break;
            case "3":
                break;
            case "4":
                CardMenu();
                break;
            default:
                break;
        }
    }
    internal static void CardMenu()
    {
        Console.Clear();
        //GetComponent();
        Console.WriteLine("\n-------------------------------\n");
        Console.Write("Pick a stack: ");
        
    }
}