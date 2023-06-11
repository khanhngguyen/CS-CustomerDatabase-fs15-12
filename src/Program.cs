// See https://aka.ms/new-console-template for more information
using System;
using Features;

internal class Program
{
    private static void Main(string[] args)
    {
        Customer cus1 = new Customer("Chup", "Vu", "chup@mail.com", "address");
        // Console.WriteLine(cus1.FirstName);
        // cus1.FirstName= "";
        // Console.WriteLine(cus1.FirstName);
        // cus1.Email = "chupgmail.com";
        // Console.WriteLine(cus1.Email);
        Customer cus2 = new Customer("Bim", "Vu", "bim@mail.com", "address");
        Customer cus3 = new Customer("Bo", "Kim", "bo@mail.com", "address");
        Customer cus4 = new Customer("Hi", "Ha", "hi@mail.com", "address");
        CustomerDatabase database = new CustomerDatabase();
        database.AddCustomer(cus1);
        database.AddCustomer(cus2);
        database.AddCustomer(cus3);
        // var data = database.Customers;
        // foreach (var item in data)
        // {
        //     Console.WriteLine(item);
        // }
        // Console.WriteLine(database.GetCustomer(4));
        database.UpdateCustomer(cus1, "Chub", "Vu", "chub@mail.com", "addressss");
        database.DeleteCustomer(cus1);
        // var data = database.Customers;
        // foreach (var item in data)
        // {
        //     Console.WriteLine(item);
        // }
        // Console.WriteLine(database);
        Console.WriteLine(database.SearchById(2));
    }
}