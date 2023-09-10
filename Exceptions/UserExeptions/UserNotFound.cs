namespace ChatChirp.Exceptions.UserExceptions;
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}
