using System;

class ExceptionHandler: Exception
{
    private string _message;

    public ExceptionHandler(string message)
    {
        _message = message;
    }

    public override string ToString()
    {
        return _message;
    }

    public static ExceptionHandler FileException(string? message)
    {
        return new ExceptionHandler(message ?? "Error in file handling");
    }
    public static ExceptionHandler EmailException()
    {
        return new ExceptionHandler("Email already existed");
    }
    public static ExceptionHandler InvalidNameException()
    {
        return new ExceptionHandler("Name can not be empty");
    }
}