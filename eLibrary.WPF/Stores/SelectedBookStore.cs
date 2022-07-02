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
    }
}
