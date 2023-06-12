using System;
using Features;
using Helper;

class CustomerDatabase
{
    //collection of customers
    //adding, reading, updating, deleting
    private IDictionary<int, Customer> _customers = new Dictionary<int, Customer>();
    private HashSet<string> _emails = new HashSet<string>();
    private HashSet<int> _ids = new HashSet<int>();
    private Stack<(string type, Customer customer)> _undo = new Stack<(string type, Customer customer)>();
    private Stack<(string type, Customer customer)> _redo = new Stack<(string type, Customer customer)>();
    // private Stack<Action> _redo = new Stack<Action>();

    public IDictionary<int, Customer> Customers
    {
        get { return _customers; }
    }

    public bool AddCustomer(Customer customer)
    {
        if (_emails.Contains(customer.Email))
        {
            throw new Exception("Email already existed");
            // throw ExceptionHandler.EmailException();
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

            //undo stack
            var undoAction = ("delete", customer);
            _undo.Push(undoAction);
            // _undo.Push(delegate()
            // {
            //     this.DeleteCustomer(customer);
            // });
            _redo.Clear();

            //filehelper
            FileHelper.AddCustomer(customer.ToString());
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

            //undo stack
            var undoAction = ("add", customer);
            _undo.Push(undoAction);

            // _undo.Push(delegate()
            // {
            //     _customers.Add(customer.Id, customer);
            //     _emails.Add(customer.Email);
            //     _ids.Add(customer.Id);
            // });
            _redo.Clear();

            //filehelper
            // FileHelper.DeleteCustomer(customer.ToString());
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
        string text = "Database:";
        foreach (var item in _customers)
        {
            text = text + "\n" + item;
        }
        return text;
    }
    public void Undo()
    {
        if (_undo.Count <= 0) throw new Exception("No actions to undo");
        else
        {
            // Action undoAction = _undo.Pop();
            // undoAction();
            var undoAction = _undo.Pop();
            switch(undoAction.type)
            {
                case "delete":
                    this.DeleteCustomer(undoAction.customer);
                    //if undo is delete --> redo is add
                    var redoAddAction = ("add", undoAction.customer);
                    _redo.Push(redoAddAction);
                    break;
                case "add":
                    _customers.Add(undoAction.customer.Id, undoAction.customer);
                    _emails.Add(undoAction.customer.Email);
                    _ids.Add(undoAction.customer.Id);
                    //if undo is add --> redo is delete
                    var redoDeleteAction = ("delete", undoAction.customer);
                    _redo.Push(redoDeleteAction);
                    break;
            }
        }
    }
    public void Redo()
    {
        if (_redo.Count <= 0) throw new Exception("No actions to redo");
        else
        {
            var redoAction = _redo.Pop();
            switch(redoAction.type)
            {
                case "add":
                    _customers.Add(redoAction.customer.Id, redoAction.customer);
                    _emails.Add(redoAction.customer.Email);
                    _ids.Add(redoAction.customer.Id);
                    break;
                case "delete":
                    this.DeleteCustomer(redoAction.customer);
                    break;
            }
        }
    }
}