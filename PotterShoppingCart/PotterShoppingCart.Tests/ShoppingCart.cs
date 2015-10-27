using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoppingCart.Tests
{
    class ShoppingCart
    {
        private List<Book> _books = new List<Book>();

        internal void AddBooks(Book book, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                this._books.Add(book);
            }
        }

        internal void Checkout()
        {
            foreach (var book in this._books)
            {
                this.TotalAmount += book.Price;
            }

            var discountRatio = GetDiscountRatio();
            this.TotalAmount *= discountRatio;
        }

        private double GetDiscountRatio()
        {
            switch (this._books.Count)
            {
                case 2:
                    return 0.95;
                case 3:
                    return 0.9;
                case 4:
                    return 0.8;
                case 5:
                    return 0.75;
                default:
                    return 1;
            }
        }

        public double TotalAmount { get; set; }
    }
}
