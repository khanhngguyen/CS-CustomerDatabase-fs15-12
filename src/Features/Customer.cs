namespace Features;
using System.Net.Mail;
using Helper;

class Customer
{
    private int _id;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string _address;
    
    public int Id 
    {
        get { return _id; }
        set { _id = value; }
    }
    public string FirstName
    {
        get { return _firstName; }
        set 
        {
            if (String.IsNullOrEmpty(value)) throw ExceptionHandler.InvalidNameException();
            else _firstName = value;
        }
    }
    public string LastName 
    {
        get { return _lastName; }
        set
        {
            if (String.IsNullOrEmpty(value)) throw ExceptionHandler.InvalidNameException();
            else _lastName = value;
        }
    }
    public string Email 
    {
        get { return _email; }
        set
        {
            if (String.IsNullOrEmpty(value)) throw new Exception("Email can not be empty");
            else 
            {
                if (IsValidEmail(value))
                {
                    _email = value;
                    // Console.WriteLine("valid");
                }
                else throw new Exception("Email is not valid");
            }
        }
    }
    public string Address 
    {
        get { return _address; }
        set
        {
            if (String.IsNullOrEmpty(value)) throw new Exception("Address can not be empty");
            else _address = value;
        }
    }

    public Customer(string firstName, string lastName, string email, string address)
    {
        _firstName = firstName;
        _lastName = lastName;
        _email = email;
        _address = address;   
    }

    public static bool IsValidEmail(string email)
    {
        try
        {
            MailAddress mail = new MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public override string ToString()
    {
        return $"Customer info: first name: {this.FirstName}, last name: {this.LastName}, email: {this.Email}, address: {this.Address}";
    }
}
