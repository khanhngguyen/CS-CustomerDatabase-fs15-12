using System;
namespace Helper;

class FileHelper
{
    // private string _path;

    // public FileHelper(string path)
    // {
    //     _path = path;
    // }

    public static string[] GetData()
    {
        try 
        {
            var data = File.ReadAllLines("src/customers.csv");
            return data;
        }
        catch (Exception e)
        {
            throw ExceptionHandler.FileException(e.Message);
        }
    }
    public static void AddCustomer(string customer)
    {
        File.AppendAllText("src/customers.csv", "\n" + customer);
    }
    // public static void DeleteCustomer(string customer)
    // {
    //     var data = File.ReadAllLines("src/customers.csv");
    //     var filteredData = data.Where(val => val != customer);
    //     File.WriteAllLines("src/customers.csv", filteredData);
    // }
}