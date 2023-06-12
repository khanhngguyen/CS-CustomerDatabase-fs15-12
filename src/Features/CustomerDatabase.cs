using System;
using Features;

class CustomerDatabase
{
    //collection of customers
    //adding, reading, updating, deleting
    private IDictionary<int, Customer> _customers = new Dictionary<int, Customer>();
    private HashSet<string> _emails = new HashSet<string>();
    private HashSet<int> _ids = new HashSet<int>();
    private Stack<Action> _undo = new Stack<Action>();
    private Stack<Action> _redo = new Stack<Action>();

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
            _ids.Add(id);

            _undo.Push(delegate()
            {
                this.DeleteCustomer(customer);
            });
            _redo.Clear();
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
            _emails.Remove(customer.Email);
            _emails.Add(email);
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
            _emails.Remove(customer.Email);
            _customers.Remove(customer.Id);
            _ids.Remove(customer.Id);
            
            _undo.Push(delegate()
            {
                _customers.Add(customer.Id, customer);
                _emails.Add(customer.Email);
                _ids.Add(customer.Id);
            });
            _redo.Clear();
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
    public void Undo()
    {
        if (_undo.Count() > 0)
        {
            Action undoAction = _undo.Pop();
            undoAction();
        }
        else throw new Exception("No actions to undo");
    }
}