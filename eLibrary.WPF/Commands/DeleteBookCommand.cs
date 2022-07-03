using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eLibrary.WPF.Stores;
using eLibrary.WPF.Models;


namespace eLibrary.WPF.Commands
{
    public class DeleteBookCommand : AsyncCommandBase
    {
        private readonly Book _book;
        private readonly BooksStore _booksStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public DeleteBookCommand(Book book, BooksStore booksStore, ModalNavigationStore modalNavigationStore)
        {
            _book = book;
            _booksStore = booksStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {

            try
            {
                await _booksStore.Delete(_book);
                _modalNavigationStore.Close();
            }
            catch (Exception) { }
        }
    }
}
