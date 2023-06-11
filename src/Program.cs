// See https://aka.ms/new-console-template for more information
using System;
using Features;

internal class Program
{
    private static void Main(string[] args)
    {
        Customer cus1 = new Customer("Chup", "Vu", "chup@mail.com", "hihi");
        Console.WriteLine(cus1.FirstName);
        cus1.FirstName = "Bim";
        Console.WriteLine(cus1.FirstName);
    }
}