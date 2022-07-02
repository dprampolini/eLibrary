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

        public async Task Add(Book book)
        {
            BookAdded?.Invoke(book); 
        }
    }
}
