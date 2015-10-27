using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoppingCart.Tests
{
    class ShoppingCart
    {
        private List<Book> _books = new List<Book>();

        internal void AddBooks(Book book)
        {
            this._books.Add(book);
        }

        internal void Checkout()
        {
            foreach (var book in this._books)
            {
                this.TotalAmount += book.Price;
            }

            if (this._books.Count == 2)
            {
                this.TotalAmount *= 0.95;
            }
        }

        public double TotalAmount { get; set; }
    }
}
