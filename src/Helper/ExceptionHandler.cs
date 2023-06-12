using System;

class ExceptionHandler: Exception
{
    private string _message;

    public ExceptionHandler(string message)
    {
        _message = message;
    }

    public static ExceptionHandler FileException(string? message)
    {
        return new ExceptionHandler(message ?? "Error in file handling");
    }
    public static ExceptionHandler EmailException()
    {
        return new ExceptionHandler("Email already existed");
    }
}