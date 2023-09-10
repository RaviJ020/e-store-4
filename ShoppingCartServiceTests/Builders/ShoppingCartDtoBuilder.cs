using ShoppingCartService.Controllers.Models;
using ShoppingCartService.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartServiceTests.Builders
{
    public class ShoppingCartDtoBuilder
    {
        private string _id = "6d6d5a1d96a2ddb65b090fa2";
        private string _customerId = "5d460b97007f79ac2ee32743";
        private CustomerType _customerType = CustomerType.Standard;
        private ShippingMethod _shippingMethod = ShippingMethod.Standard;
        private Address _shippingAddress = new AddressBuilder().Build();
        private IEnumerable<ItemDto> _items = new List<ItemDto>();

        public ShoppingCartDtoBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public ShoppingCartDtoBuilder WithCustomerId(string customerId)
        {
            _customerId = customerId;
            return this;
        }

        public ShoppingCartDtoBuilder WithCustomerType(CustomerType customerType)
        {
            _customerType = customerType;
            return this;
        }

        public ShoppingCartDtoBuilder WithShippingMethod(ShippingMethod shippingMethod)
        {
            _shippingMethod = shippingMethod;
            return this;
        }

        public ShoppingCartDtoBuilder WithShippingAddress(Address shippingAddress)
        {
            _shippingAddress = shippingAddress;
            return this;
        }

        public ShoppingCartDtoBuilder WithItems(IEnumerable<ItemDto> items)
        {
            _items = items;
            return this;
        }

        public ShoppingCartDtoBuilder AddItem(ItemDto item)
        {
            if (_items == null)
            {
                _items = new List<ItemDto>();
            }
            _items = _items.Concat(new[] { item });
            return this;
        }

        public ShoppingCartDto Build()
        {
            return new ShoppingCartDto
            {
                Id = _id,
                CustomerId = _customerId,
                CustomerType = _customerType,
                ShippingMethod = _shippingMethod,
                ShippingAddress = _shippingAddress,
                Items = _items ?? Enumerable.Empty<ItemDto>()
            };
        }
    }
}
