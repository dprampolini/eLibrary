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
    public class DeleteBookViewModel : ViewModelBase
    {
        public Guid BookId { get; }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public DeleteBookViewModel(Book book, BooksStore booksStore, ModalNavigationStore modalNavigationStore)
        {
            ConfirmCommand = new DeleteBookCommand(book, booksStore, modalNavigationStore);
            CancelCommand = new CloseModalCommand(modalNavigationStore);
        }

    }
}
