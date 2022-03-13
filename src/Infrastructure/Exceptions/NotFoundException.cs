namespace Infrastructure.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException()
        { }

        public NotFoundException(string message)
            : base(message)
        { }

        public NotFoundException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}