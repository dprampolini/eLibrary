using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eLibrary.WPF.Models;

namespace eLibrary.WPF.Stores
{
    public class SelectedBookStore
    {
        private BooksStore _booksStore;
        private Book _selectedBook;

        public Book SelectedBook
        {
            get 
            { 
                return _selectedBook; 
            }
            set 
            {
                _selectedBook = value;
                SelectedBookChanged?.Invoke();
            }

        }

        public event Action SelectedBookChanged;

        public SelectedBookStore(BooksStore booksStore)
        {
            _booksStore = booksStore;

            // Register to BooksStore BookUpdated event in order to automatically update the details of the book on the GUI when the book is updated
            _booksStore.BookUpdated += BooksStore_BookUpdated;
        }

        private void BooksStore_BookUpdated(Book book)
        {
            if (book.Id == SelectedBook?.Id)
            {
                SelectedBook = book;
            }
        }
    }
}
