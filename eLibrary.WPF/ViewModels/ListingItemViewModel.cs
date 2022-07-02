using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using eLibrary.WPF.Models;

namespace eLibrary.WPF.ViewModels
{
    public class ListingItemViewModel : ViewModelBase
    {
        public Book Book { get; }
        public string Title => Book.Title;
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public ListingItemViewModel(Book book, ICommand editCommand)
        {
            this.Book = book;
            this.EditCommand = editCommand;
        }
    }
}
