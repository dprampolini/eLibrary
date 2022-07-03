using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eLibrary.WPF.Stores;
using eLibrary.WPF.ViewModels;
using eLibrary.WPF.Models;

namespace eLibrary.WPF.Commands
{
    public class OpenEditBookCommand : CommandBase
    {
        private readonly ListingItemViewModel _listingItemViewModel;
        private readonly BooksStore _booksStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenEditBookCommand(ListingItemViewModel listingItemViewModel, BooksStore booksStore, ModalNavigationStore modalNavigationStore)
        {
            _listingItemViewModel = listingItemViewModel;
            _booksStore = booksStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            Book book = _listingItemViewModel.Book;
            EditBookViewModel editBookViewModel = new EditBookViewModel(book, _booksStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editBookViewModel;
        }
    }
}
