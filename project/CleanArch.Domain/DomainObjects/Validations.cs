
namespace CleanArch.Domain.DomainObjects
{
    public static class Validations
    {
        public static void IsNullOrEmpty(string value, string message)
        {
            if (value is null || value == "")
                throw new DomainException(message);
        }
    }
}
