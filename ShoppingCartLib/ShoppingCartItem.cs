using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartLib
{
    public class ShoppingCart
    {
        public decimal CheckOut(List<ShoppingCartItem> shoppingCartItems)
        {
            var shoudPaymentItems = shoppingCartItems.Where(item => item.Amount >= 1);
            decimal discount = CalcDiscount(shoudPaymentItems);

            return 100 * shoppingCartItems.Select(item => item.Amount).Sum() * (1 - discount);
        }

        private decimal CalcDiscount(IEnumerable<ShoppingCartItem> shoudPaymentItems)
        {
            decimal discount = 0;
            switch (shoudPaymentItems.Count())
            {
                case 2:
                    discount = 0.05m;
                    break;
                case 3:
                    discount = 0.1m;
                    break;
                case 4:
                    discount = 0.2m;
                    break;
                case 5:
                    discount = 0.25m;
                    break;
            }

            return discount;
        }
    }

    public class ShoppingCartItem
    {
        private int _productId;
        private string _productName;
        private int _amount;

        public int Amount { get { return _amount; } }

        public ShoppingCartItem(int productId, string productName, int amount)
        {
            this._productId = productId;
            this._productName = productName;
            this._amount = amount;
        }
    }
}