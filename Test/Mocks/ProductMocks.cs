
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
                ManufacturePhone = "ValidManufacturePhone",
                ManufactureEmail = "ValidManufactureEmail",
                IsAvailable = true,
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
