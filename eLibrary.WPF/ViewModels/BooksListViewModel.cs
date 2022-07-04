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
        private readonly BooksStore _booksStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly ResearchStore _researchStore;

        private readonly ObservableCollection<ListingItemViewModel> _listingItemViewModel;
        public IEnumerable<ListingItemViewModel> ListingItemViewModel => _listingItemViewModel;
        private ObservableCollection<ListingItemViewModel> _listingItemViewModelFiltered;
        public IEnumerable<ListingItemViewModel> ListingItemViewModelFiltered => _listingItemViewModelFiltered;

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

        public BooksListViewModel(BooksStore booksStore, SelectedBookStore selectedBookStore, ModalNavigationStore modalNavigationStore, ResearchStore researchStore)
        {
            _selectedBookStore = selectedBookStore;
            _listingItemViewModel = new ObservableCollection<ListingItemViewModel>();
            _listingItemViewModelFiltered = new ObservableCollection<ListingItemViewModel>();
            _booksStore = booksStore;
            _modalNavigationStore = modalNavigationStore;
            _researchStore = researchStore;

            //Events subscription
            _booksStore.BookAdded += BooksStore_BookAdded; 
            _booksStore.BookUpdated += BooksStore_BookUpdated;
            _booksStore.BookDeleted += BooksStore_BookDeleted;
            _researchStore.ResearchChanged += ResearchStore_ResearchChanged;

            AddBook(new Book(Guid.NewGuid(), "Madame Bovary", "Gustave Flaubert", "1856", "Francese"));
            AddBook(new Book(Guid.NewGuid(), "Dracula", "Bram Stoker", "1897", "Inglese"));
            AddBook(new Book(Guid.NewGuid(), "L'isola del Tesoro", "Robert Louis Stevenson", "1883", "Inglese"));

            ResetFilter();

        }

        protected override void Dispose()
        {
            //Unsubscribption to events
            _booksStore.BookAdded -= BooksStore_BookAdded;
            _booksStore.BookUpdated -= BooksStore_BookUpdated;
            _booksStore.BookDeleted -= BooksStore_BookDeleted;
            _researchStore.ResearchChanged -= ResearchStore_ResearchChanged;
            base.Dispose();
        }

        private void BooksStore_BookAdded(Book book)
        {
            AddBook(book);
            ApplyFilter();
        }

        private void BooksStore_BookUpdated(Book book)
        {
            //Assign to this local variable the first Book with the id of the input id
            ListingItemViewModel listingItemViewModel =
                _listingItemViewModel.FirstOrDefault(y => y.Book.Id == book.Id);

            if (listingItemViewModel != null)
            {
                listingItemViewModel.Update(book);
                ApplyFilter();
            }
            
        }

        private void BooksStore_BookDeleted(Book book)
        {
            ListingItemViewModel listingItemViewModel =
                _listingItemViewModel.FirstOrDefault(y => y.Book.Id == book.Id);

            if (listingItemViewModel != null)
            {
                DeleteBook(book);
                ApplyFilter();
            }
        }

        private void ResearchStore_ResearchChanged()
        {
            ApplyFilter();
        }

        private void AddBook(Book book)
        {
            ListingItemViewModel itemViewModel = new ListingItemViewModel(book, _booksStore, _modalNavigationStore);
            _listingItemViewModel.Add(itemViewModel);
        }

        private void DeleteBook(Book book)
        {
            _listingItemViewModel.Remove(_listingItemViewModel.FirstOrDefault(y => y.Book.Id == book.Id));
        }

        private void ResetFilter()
        {
            _listingItemViewModelFiltered.Clear();
            foreach (ListingItemViewModel item in _listingItemViewModel)
            {
                _listingItemViewModelFiltered.Add(item);
            }
        }

        private void ApplyFilter()
        {
            if (String.IsNullOrEmpty(_researchStore.Research.ToString()))
            {
                ResetFilter();
            }
            else
            {
                var temp = _listingItemViewModel.Where(elem => elem.Title.Contains(_researchStore.Research, StringComparison.InvariantCultureIgnoreCase)).ToList();
                _listingItemViewModelFiltered.Clear();
                foreach (var item in temp)
                {
                    _listingItemViewModelFiltered.Add(item);
                }
            }
        }

    }
}
