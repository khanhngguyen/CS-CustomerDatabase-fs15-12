// See https://aka.ms/new-console-template for more information
using System;
using Features;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Create 4 example customers, a database then add 4 customers into database");
        Customer cus1 = new Customer("Anna", "Andre", "anna@mail.com", "Anna address");
        Customer cus2 = new Customer("Billy", "Bronya", "billy@mail.com", "Billy address");
        Customer cus3 = new Customer("Chris", "Christine", "chris@mail.com", "Chris address");
        Customer cus4 = new Customer("Dyanne", "Doe", "dyanne@mail.com", "Dyanne address");
        CustomerDatabase database = new CustomerDatabase();
        database.AddCustomer(cus1);
        database.AddCustomer(cus2);
        database.AddCustomer(cus3);
        database.AddCustomer(cus4);
        Console.WriteLine(database);
        Console.WriteLine("Database after updating information of 2 customers and delete 1 customer");
        database.UpdateCustomer(cus1, "Anna", "Allan", "allan@mail.com", "Anna address");
        database.UpdateCustomer(cus2, "Billy", "Bill", "billybill@mail.com", "Billy address");
        database.DeleteCustomer(cus3);
        Console.WriteLine(database);
        Console.WriteLine("Undo deleting customer");
        database.Undo();
        Console.WriteLine(database);
        Console.WriteLine("Then redo the latest action - deleting customer");
        database.Redo();
        Console.WriteLine(database);
        Console.WriteLine("Search customer by id: 2");
        Console.WriteLine(database.SearchById(2));
    }
}