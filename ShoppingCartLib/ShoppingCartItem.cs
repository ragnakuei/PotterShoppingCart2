using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartLib
{
    public class ShoppingCart
    {
        //  結帳
        public decimal CheckOut(IEnumerable<ShoppingCartItem> shoppingCartItems)
        {
            decimal payment = 0;
            while (GetCountForAmountGreaterEqual1(shoppingCartItems) >= 1)
            {
                payment += CalcSingleDiscountPayment(shoppingCartItems);
                ItemsAmountMinus1(ref shoppingCartItems);
            }
            return payment;
        }

        // 計算單次折扣金額
        private decimal CalcSingleDiscountPayment(IEnumerable<ShoppingCartItem> shoppingCartItems)
        {
            decimal discount = CalcDiscount(shoppingCartItems);
            return 100 * GetCountForAmountGreaterEqual1(shoppingCartItems) * (1 - discount);
        }

        // 計算 折扣
        private decimal CalcDiscount(IEnumerable<ShoppingCartItem> shoudPaymentItems)
        {
            decimal discount = 0;
            switch (GetCountForAmountGreaterEqual1(shoudPaymentItems))
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

        // 計算 數量大於等於 1 的品項數
        private int GetCountForAmountGreaterEqual1(IEnumerable<ShoppingCartItem> shouldPaymentItems)
        {
            return shouldPaymentItems.Where(item => item.Amount >= 1).Count();
        }

        // 對數量大於等於 1 的品項數量減1
        private void ItemsAmountMinus1(ref IEnumerable<ShoppingCartItem> shouldPaymentItems)
        {
            foreach (var shoppingCartItem in shouldPaymentItems.Where(item => item.Amount >= 1).Select(i => i))
            { shoppingCartItem.AmountMinus1(); }
        }
    }

    public class ShoppingCartItem
    {
        private int _productId;
        private string _productName;
        private int _amount;

        internal int Amount { get { return _amount; } }

        public ShoppingCartItem(int productId, string productName, int amount)
        {
            this._productId = productId;
            this._productName = productName;
            this._amount = amount;
        }

        internal void AmountMinus1() { this._amount--; }
    }
}