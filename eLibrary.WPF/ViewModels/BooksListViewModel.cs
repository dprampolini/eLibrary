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

        public BooksListViewModel(SelectedBookStore selectedBookStore, ModalNavigationStore modalNavigationStore)
        {
            this._selectedBookStore = selectedBookStore;
            _listingItemViewModel = new ObservableCollection<ListingItemViewModel>();

            AddBook(new Book("Madame Bovary", "Gustave Flaubert", "1856", "Francese"), modalNavigationStore);
            AddBook(new Book("Dracula", "Bram Stoker", "1897", "Inglese"), modalNavigationStore);
            AddBook(new Book("L'isola del Tesoro", "Robert Louis Stevenson", "1883", "Inglese"), modalNavigationStore);

        }

        private void AddBook(Book book, ModalNavigationStore modalNavigationStore)
        {
            ICommand editCommand = new OpenEditBookCommand(book, modalNavigationStore);
            _listingItemViewModel.Add(new ListingItemViewModel(book, editCommand));
        }
    }
}
