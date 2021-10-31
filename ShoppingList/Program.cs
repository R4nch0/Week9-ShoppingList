using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootDirectory = @"C:\Users\...\samples";
            Console.WriteLine("Enter directory name:");
            string newDirectory = Console.ReadLine();
            Console.WriteLine("Enter file name:");
            string fileName = Console.ReadLine();
            string fileLocation = @"C:\Users\...\ShoppingList";
            string fileName2 = @"\\myShoppingList.txt";
            string[] arrayFromFile = File.ReadAllLines($"{fileLocation}{fileName2}");
            List<string> myShoppingList = arrayFromFile.ToList<string>();


            if (Directory.Exists($"{rootDirectory}\\{newDirectory}") && File.Exists($"{rootDirectory}\\{newDirectory}\\{fileName}"))
            {
                Console.WriteLine($"Directory and File exsist.");
            }
            else
            {
                Directory.CreateDirectory($"{rootDirectory}\\{newDirectory}");
                File.Create($"{rootDirectory}\\{newDirectory}\\{fileName}");
            }
           
            bool loopActive = true;

            while (loopActive)
            {
                Console.WriteLine("Would you like to add an item to shopping list? Y/N: ");
                char userInput = Convert.ToChar(Console.ReadLine().ToLower());

                if (userInput == 'y')
                {
                    Console.WriteLine("Enter your item:");
                    string userItem = Console.ReadLine();
                    myShoppingList.Add(userItem);
                }
                else
                {
                    loopActive = false;
                    Console.WriteLine("Take care!");
                }
            }

            Console.Clear();

            foreach (string item in myShoppingList)
            {
                Console.WriteLine($"Your item: {item}");
            }

            File.WriteAllLines($"{fileLocation}{fileName2}", myShoppingList);

        }
    }
}
