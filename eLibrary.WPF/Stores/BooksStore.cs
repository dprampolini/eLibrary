using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eLibrary.WPF.Models;

namespace eLibrary.WPF.Stores
{
    public  class BooksStore
    {
        public event Action<Book> BookAdded;
        public event Action<Book> BookUpdated;

        public async Task Add(Book book)
        {
            BookAdded?.Invoke(book); 
        }

        public async Task Update(Book book)
        {
            BookUpdated?.Invoke(book);
        }
    }
}
