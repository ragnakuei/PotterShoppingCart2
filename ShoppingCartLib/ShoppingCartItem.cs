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

            decimal discount = 0;
            if (shoudPaymentItems.Count() == 2)
            { discount = 0.05m; }

            return 100 * shoppingCartItems.Select(item => item.Amount).Sum() * (1 - discount);
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