namespace Domain
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string e) : base(e)
        {
        }

        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(error);
            }
        }
    }
}
