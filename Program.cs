using System;
using System.Diagnostics;
using InventoryManagementSystem;
using InventoryManagementSystem.Models;
using myconsoleapp.Helpers;

class Program
{
    static void Main()
    {

        InventoryManager manager = new();
        ErrorHandler errorHandler = new();
        Stopwatch stopwatch = new();

        Console.WriteLine("Welcome to Inventory Management System!");
        Console.WriteLine("Commands:");
        Console.WriteLine("  add electronics <name> <quantity> <price> <warranty_months>");
        Console.WriteLine("  add food <name> <quantity> <price> <expiry_days_from_now>");
        Console.WriteLine("  list");
        Console.WriteLine("  remove <item_id>");
        Console.WriteLine("  exit");
        int exceptionCount = 0;

        while (true)
        {

            Console.Write("\nEnter command: ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                continue;

            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var command = parts[0].ToLower();

            try
            {
                stopwatch.Restart();

                if (command == "add" && parts.Length > 1)
                {
                    if (parts[1].ToLower() == "electronics" && parts.Length == 6)
                    {
                        string name = parts[2];
                        int quantity = int.Parse(parts[3]);
                        double price = double.Parse(parts[4]);
                        int warrantyMonths = int.Parse(parts[5]);

                        var item = new Electronics(name, quantity, price, warrantyMonths);
                        manager.AddItem(item);
                        Console.WriteLine($"Added Electronics item: {name}");
                    }
                    else if (parts[1].ToLower() == "food" && parts.Length == 6)
                    {
                        string name = parts[2];
                        int quantity = int.Parse(parts[3]);
                        double price = double.Parse(parts[4]);
                        int expiryDays = int.Parse(parts[5]);

                        var expiryDate = DateTime.Now.AddDays(expiryDays);
                        var item = new Food(name, quantity, price, expiryDate);
                        manager.AddItem(item);
                        Console.WriteLine($"Added Food item: {name}");
                    }
                    else
                    {
                        exceptionCount++;
                        Console.WriteLine($"exception_count:{exceptionCount}");
                        Console.WriteLine("Invalid add command format.");
                    }
                }
                else if (command == "list")
                {
                    manager.ListItems();
                }
                else if (command == "remove" && parts.Length == 2)
                {
                    int id = int.Parse(parts[1]);
                    manager.RemoveItmes(id);
                    Console.WriteLine($"Removed item with ID {id}");
                }
                else if (command == "exit")
                {
                    Console.WriteLine("Exiting program.");
                    break;
                }
                else
                {

                    Console.WriteLine("Unknown command or invalid parameters.");

                        exceptionCount++;
                        Console.WriteLine($"exception_count:{exceptionCount}");
                    
                }

                stopwatch.Stop();
                Console.WriteLine($"Command execution took: {stopwatch.ElapsedMilliseconds} ms");
            }
            catch (Exception ex)
            {
                exceptionCount++;

                stopwatch.Stop();
                errorHandler.Handle(ex);
                Console.WriteLine($"Command failed after {stopwatch.ElapsedMilliseconds} ms");
                Console.WriteLine($"exception_count:{exceptionCount}");
            }
        }

        Console.WriteLine($"Total Items Created: {Item.TotalItems}");
    }
}
