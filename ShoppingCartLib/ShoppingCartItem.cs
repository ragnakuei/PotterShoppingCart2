using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartLib
{
    public class ShoppingCart
    {
        public decimal CheckOut(List<ShoppingCartItem> shoppingCartItems)
        {
            decimal discount = CalcDiscount(shoppingCartItems);

            return 100 * shoppingCartItems.Select(item => item.Amount).Sum() * (1 - discount);
        }

        private decimal CalcDiscount(IEnumerable<ShoppingCartItem> shoudPaymentItems)
        {
            decimal discount = 0;
            int itemsCount = shoudPaymentItems.Where(item => item.Amount >= 1).Count();
            switch (itemsCount)
            {
                case 2:
                    discount = 0.05m;
                    break;
                case 3:
                    discount = 0.1m;
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