
using ShoppingCartService.Controllers.Models;

namespace ShoppingCartServiceTests.Builders
{
    public class CheckoutDtoBuilder
    {
        private ShoppingCartDto _shoppingCart = new ShoppingCartDtoBuilder().Build();
        private double _shippingCost = 1.0;
        private double _customerDiscount = 0.0;
        private double _total = 2.0;

        public CheckoutDtoBuilder WithShoppingCart(ShoppingCartDto shoppingCart)
        {
            _shoppingCart = shoppingCart;
            return this;
        }

        public CheckoutDtoBuilder WithShippingCost(double shippingCost)
        {
            _shippingCost = shippingCost;
            return this;
        }

        public CheckoutDtoBuilder WithCustomerDiscount(double customerDiscount)
        {
            _customerDiscount = customerDiscount;
            return this;
        }

        public CheckoutDtoBuilder WithTotal(double total)
        {
            _total = total;
            return this;
        }

        public CheckoutDto Build()
        {
            return new CheckoutDto(_shoppingCart, _shippingCost, _customerDiscount, _total);
        }
    }

}
