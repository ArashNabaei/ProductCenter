
using Domain.Entities;

namespace Test.Mocks
{
    public static class ProductMocks
    {

        public static Product ValidProduct()
        {
            return new Product
            {
                Id = 1,
                Name = "ValidProductName",
            };
        }

        public static Product InvalidProduct()
        {
            return new Product
            {
                Id = 1,
                Name = "InvalidProductName",
            };
        }

        public static Product ExistingProduct()
        {
            return new Product
            {
                Id = 1,
                Name = "ExistingProductName",
            };
        }

    }
}
