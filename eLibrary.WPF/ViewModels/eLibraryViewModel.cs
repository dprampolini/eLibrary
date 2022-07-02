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
        public BookDetailsViewModel BookDetailsViewModel { get; }
        public BooksListViewModel BooksListViewModel { get; }
        public ICommand AddBookCommand { get; }

        public eLibraryViewModel(SelectedBookStore _selectedBookStore, ModalNavigationStore modalNavigationStore)
        {
            BookDetailsViewModel = new BookDetailsViewModel(_selectedBookStore);
            BooksListViewModel = new BooksListViewModel(_selectedBookStore, modalNavigationStore);

            AddBookCommand = new OpenAddBookCommand(modalNavigationStore);
        }
    }
}
