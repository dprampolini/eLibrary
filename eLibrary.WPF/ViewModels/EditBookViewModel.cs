using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using eLibrary.WPF.Commands;
using eLibrary.WPF.Stores;
using eLibrary.WPF.Models;  

namespace eLibrary.WPF.ViewModels
{

    public class EditBookViewModel : ViewModelBase
    {
        public BookDetailsFormViewModel BookDetailsFormViewModel { get; }

        public EditBookViewModel(Book book, ModalNavigationStore modalNavigationStore)
        {
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            BookDetailsFormViewModel = new BookDetailsFormViewModel(null, cancelCommand)
            {
                Title = book.Title,
                Author = book.Author,
                PublicationDate = book.PublicationDate,
                OriginalLanguage = book.OriginalLanguage,
            };
        }
    }
}
