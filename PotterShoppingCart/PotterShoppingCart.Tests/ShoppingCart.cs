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
            var checkoutBooks = new List<Book>();

            while (this._books.Count > 0)
            {
                var groupBooks = this._books.GroupBy(p => p.Name).Select(p => p.First());

                var discountRatio = GetDiscountRatio(groupBooks.Count());
                this.TotalAmount += groupBooks.Sum(p => p.Price) * discountRatio;

                foreach (var book in groupBooks)
                {
                    checkoutBooks.Add(book);
                    this._books.Remove(book);
                }
            }
        }

        private double GetDiscountRatio(int booksCount)
        {
            switch (booksCount)
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
