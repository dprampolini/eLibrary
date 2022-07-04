using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using eLibrary.WPF.Stores;
using eLibrary.WPF.Commands;

namespace eLibrary.WPF.ViewModels
{
    public class eLibraryViewModel : ViewModelBase
    {
        public SearchBoxViewModel SearchBoxViewModel { get; }
        public BookDetailsViewModel BookDetailsViewModel { get; }
        public BooksListViewModel BooksListViewModel { get; }
        public ICommand AddBookCommand { get; }

        public eLibraryViewModel(BooksStore _booksStore, SelectedBookStore _selectedBookStore, ModalNavigationStore modalNavigationStore, ResearchStore researchStore)
        {
            SearchBoxViewModel = new SearchBoxViewModel(researchStore);
            BookDetailsViewModel = new BookDetailsViewModel(_selectedBookStore);
            BooksListViewModel = new BooksListViewModel(_booksStore, _selectedBookStore, modalNavigationStore, researchStore);

            AddBookCommand = new OpenAddBookCommand(_booksStore,modalNavigationStore);
        }
    }
}
