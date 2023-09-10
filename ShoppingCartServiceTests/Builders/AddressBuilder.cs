using ShoppingCartService.Models;

namespace ShoppingCartServiceTests.Builders
{
    public class AddressBuilder
    {
        private string _country = "country 1";
        private string _city = "city 1";
        private string _street = "street 1";

        public AddressBuilder WithCountry(string country)
        {
            _country = country;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            _city = city;
            return this;
        }

        public AddressBuilder WithStreet(string street)
        {
            _street = street;
            return this;
        }

        public Address Build()
        {
            return new Address
            {
                Country = _country,
                City = _city,
                Street = _street
            };
        }

        public static Address CreateAddress(
            string country = "country 1",
            string city = "city 1",
            string street = "street 1"
        )
        {
            return new Address
            {
                Country = country,
                City = city,
                Street = street
            };
        }
    }

}