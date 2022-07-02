using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using eLibrary.WPF.Stores;
using eLibrary.WPF.Models;
using eLibrary.WPF.Commands;

namespace eLibrary.WPF.ViewModels
{
    public class BooksListViewModel : ViewModelBase
    {
        private readonly SelectedBookStore _selectedBookStore;

        private readonly ObservableCollection<ListingItemViewModel> _listingItemViewModel;
        private readonly BooksStore _booksStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        //Using an ObservableCollection the UI can immediately update when an item is add or removed

        public IEnumerable<ListingItemViewModel> ListingItemViewModel => _listingItemViewModel;

        private ListingItemViewModel _selectedBooksListItemViewModel;
        public ListingItemViewModel SelectedBooksListItemViewModel
        {
            get {
                return _selectedBooksListItemViewModel;
            }
            set
            {
                _selectedBooksListItemViewModel = value;
                OnPropertyChanged(nameof(SelectedBooksListItemViewModel));

                _selectedBookStore.SelectedBook = _selectedBooksListItemViewModel?.Book;
            }
        }

        public BooksListViewModel(BooksStore booksStore, SelectedBookStore selectedBookStore, ModalNavigationStore modalNavigationStore)
        {
            _selectedBookStore = selectedBookStore;
            _listingItemViewModel = new ObservableCollection<ListingItemViewModel>();
            _booksStore = booksStore;
            _modalNavigationStore = modalNavigationStore;
            _booksStore.BookAdded += BooksStore_BookAdded;

            AddBook(new Book("Madame Bovary", "Gustave Flaubert", "1856", "Francese"));
            AddBook(new Book("Dracula", "Bram Stoker", "1897", "Inglese"));
            AddBook(new Book("L'isola del Tesoro", "Robert Louis Stevenson", "1883", "Inglese"));

        }

        protected override void Dispose()
        {
            _booksStore.BookAdded -= BooksStore_BookAdded;
            base.Dispose();
        }

        private void BooksStore_BookAdded(Book book)
        {
            AddBook(book);
        }

        private void AddBook(Book book)
        {
            ICommand editCommand = new OpenEditBookCommand(book, _modalNavigationStore);
            _listingItemViewModel.Add(new ListingItemViewModel(book, editCommand));
        }
    }
}
