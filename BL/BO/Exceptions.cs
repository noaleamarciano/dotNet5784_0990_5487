namespace BO;


[Serializable]
public class BlDoesNotExistException : Exception //Exception does not exist
{
    public BlDoesNotExistException(string? message) : base(message) { }
    public BlDoesNotExistException(string message, Exception innerException)
                : base(message, innerException) { }
}

[Serializable]
public class BlNullPropertyException : Exception //Exception an attribute with a null value
{
    public BlNullPropertyException(string? message) : base(message) { }
}

[Serializable]
public class BlAlreadyExistsException : Exception //Exception of an object that is already exist
{
    public BlAlreadyExistsException(string? message) : base(message) { }
    public BlAlreadyExistsException(string message, Exception innerException)
    : base(message, innerException) { }
}
