namespace EShop.Domain.Exceptions
{
    public class CustomerAddressAlreadyDefinedException : Exception
    {
        public CustomerAddressAlreadyDefinedException(string addressTitle)
            : base($"{addressTitle} address title is already defined")
        {

        }
    }
}

