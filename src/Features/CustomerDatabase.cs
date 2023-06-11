using System;
using Features;

class CustomerDatabase
{
    //collection of customers
    //adding, reading, updating, deleting
    private IDictionary<int, Customer> _customers = new Dictionary<int, Customer>();
    private HashSet<int> _ids = new HashSet<int>();
    private HashSet<string> _emails = new HashSet<string>();

    public IDictionary<int, Customer> Customers
    {
        get { return _customers; }
    }

    public bool AddCustomer(Customer customer)
    {
        if (_emails.Contains(customer.Email))
        {
            throw new Exception("Email already existed");
        }
        else 
        {
            int id;
            if (_customers.Count() == 0) id = 1;
            else id = _customers.Count() + 1;
            customer.Id = id;
            _customers.Add(id, customer);
            _emails.Add(customer.Email);
            return true;
        }
    }

    public Customer GetCustomer(int id)
    {
        return _customers[id];
    }

    public void UpdateCustomer(Customer customer, string firstName, string lastName, string email, string address)
    {
        Customer existedCustomer = _customers[customer.Id];
        if (existedCustomer == null)
        {
            throw new Exception("Can not updated, customer is not in database");
        }
        else 
        {
            Customer newCustomer = new Customer(firstName, lastName, email, address);
            _customers[customer.Id] = newCustomer;
        }
    }
    public void DeleteCustomer(Customer customer)
    {
        Customer existedCustomer = _customers[customer.Id];
        if (existedCustomer == null)
        {
            throw new Exception("Can not delete, customer is not in database");
        }
        else 
        {
            _customers.Remove(customer.Id);
        }
    }
    public Customer SearchById(int number)
    {
        bool existed = _customers.ContainsKey(number);
        if (!existed)
        {
            throw new Exception($"Can not find customer with id {number}");
        }
        else return _customers[number];
    }
    public override string ToString()
    {
        string text = "Database:\n";
        foreach (var item in _customers)
        {
            text = text + item + "\n";
        }
        return text;
    }
}