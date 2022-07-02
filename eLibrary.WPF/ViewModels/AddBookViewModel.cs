using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using eLibrary.WPF.Commands;
using eLibrary.WPF.Stores;

namespace eLibrary.WPF.ViewModels
{
    public class AddBookViewModel : ViewModelBase
    {
        public BookDetailsFormViewModel BookDetailsFormViewModel { get; }

        public AddBookViewModel(BooksStore booksStore, ModalNavigationStore modalNavigationStore)
        {
            ICommand submitCommand = new AddBookCommand(this, booksStore,modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            BookDetailsFormViewModel = new BookDetailsFormViewModel(submitCommand, cancelCommand);
        }

        
    }
}
