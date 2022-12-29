
using CleanArch.Domain.DomainObjects;
using System.Text.RegularExpressions;

namespace CleanArch.Domain.DomainObjects
{
    public class Validation
    {
        public static void Equals(string value1, string value2, string message)
        {
            if (value1 == null || value2 == null)
                throw new Exception("Os parametros não podem ser nulos");

            var regex = new Regex(value1);

            if (!regex.IsMatch(value2) || value1 != value2)
                throw new DomainException(message);
        }

        public static void IsNotNullOrEmpty(string value, string message)
        {
            if (value == null || value.Trim().Length == 0)
                throw new DomainException(message);
        }

        public static void IsNotNullOrEmpty<T>(IList<T> value, string message)
        {
            if (value == null || value.Count == 0)
                throw new DomainException(message);
        }

        public static void IsNotNull(object object1, string message)
        {
            if (object1 == null)
                throw new DomainException(message);
        }

        public static void IsBiggerThan(int value, int minimo, string message)
        {
            if (value < minimo)
                throw new DomainException(message);
        }

        public static void IsBiggerThan(DateTime value1, DateTime value2, string message)
        {
            if (value1 < value2)
                throw new DomainException(message);
        }

        public static void IsEqualsOrBiggerThan(DateTime value1, DateTime value2, string message)
        {
            if (value1 != value2 && value1 < value2)
                throw new DomainException(message);
        }

        public static void IsValidGuid(string value, string message)
        {
            try
            {
                if (new Guid(value) == Guid.Empty)
                    throw new Exception();
            }
            catch (Exception)
            {
                throw new DomainException(message);
            }
        }

        public static void IsValidGuid(Guid value, string message) =>
            IsValidGuid(value.ToString(), message);

        public static void IsValidEmail(string email, string message = "Email inválido")
        {
            if (email == null)
                throw new DomainException(message);

            string pattern = @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$";

            var regex = new Regex(pattern);

            if (!regex.IsMatch(email))
                throw new DomainException(message);
        }

        public static void IsValidCellPhone(string celular, string message)
        {
            IsNotNullOrEmpty(celular, message);
            IsBetween(celular.Length, 1, 15, message);
        }

        public static void IsBetween(double value, double minimo, double maximo, string message)
        {
            if (value < minimo || value > maximo)
                throw new DomainException(message);
        }

        public static void IsBetween(float value, float minimo, float maximo, string message)
        {
            if (value < minimo || value > maximo)
                throw new DomainException(message);
        }

        public static void IsBetween(int value, int minimo, int maximo, string message)
        {
            if (value < minimo || value > maximo)
                throw new DomainException(message);
        }

        public static void IsBetween(long value, long minimo, long maximo, string message)
        {
            if (value < minimo || value > maximo)
                throw new DomainException(message);
        }

        public static void IsBetween(decimal value, decimal minimo, decimal maximo, string message)
        {
            if (value < minimo || value > maximo)
                throw new DomainException(message);
        }

        public static void IsValidDate(string value, string message)
        {
            DateTime temp;

            if (!DateTime.TryParse(value, out temp) || value.Length < 10)
                throw new DomainException(message);
        }

        public static void IsValidDate(DateTime value, string message)
        {
            if(DateTime.MinValue == value)
                throw new DomainException(message);
        }

    }
}