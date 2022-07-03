using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using eLibrary.WPF.Models;
using eLibrary.WPF.Stores;
using eLibrary.WPF.Commands;

namespace eLibrary.WPF.ViewModels
{
    public class ListingItemViewModel : ViewModelBase
    {
        public Book Book { get; private set; }
        public string Title => Book.Title;
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public ListingItemViewModel(Book book, BooksStore booksStore, ModalNavigationStore modalNavigationStore)
        {
            Book = book;

            EditCommand = new OpenEditBookCommand(this, booksStore, modalNavigationStore);
        }

        public void Update(Book book)
        {
            Book = book;

            OnPropertyChanged(nameof(Title));
        }
    }
}
