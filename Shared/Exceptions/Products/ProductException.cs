
namespace Shared.Exceptions.Products
{
    public class ProductException : BaseException
    {

        public ProductException(int code, string message) : base(code, message)
        {
            
        }

        public static ProductException ProductNotFound()
        {
            return new ProductException(2001, "Product was not found.");
        }

        public static ProductException ProductAlreadyExists()
        {
            return new ProductException(2002, "Product already exists.");
        }



    }
}
