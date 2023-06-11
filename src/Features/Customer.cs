namespace Features;

class Customer
{
    //id, firstname, lastname, email, address
    private string _firstName;
    private readonly string _lastName;
    private readonly string _email;
    private readonly string _address;

    public string FirstName
    {
        get { return _firstName; }
        set 
        {
            if (value != null) _firstName = value;
            else throw new Exception("Name can not be empty");
        }
    }
    public string LastName 
    {
        get { return _lastName; }
    }
    public string Email 
    {
        get { return _email; }
    }
    public string Address 
    {
        get { return _address; }
    }

    public Customer(string firstName, string lastName, string email, string address)
    {
        _firstName = firstName;
        _lastName = lastName;
        _email = email;
        _address = address;   
    }
}