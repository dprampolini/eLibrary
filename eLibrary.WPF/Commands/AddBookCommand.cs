using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eLibrary.WPF.Models;
using eLibrary.WPF.Stores;
using eLibrary.WPF.ViewModels;

namespace eLibrary.WPF.Commands
{
    public class AddBookCommand : AsyncCommandBase
    {
        private readonly AddBookViewModel _addBookViewModel;
        private readonly BooksStore _booksStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        

        public AddBookCommand(AddBookViewModel addBookViewModel ,BooksStore booksStore, ModalNavigationStore modalNavigationStore)
        {
            _addBookViewModel = addBookViewModel;
            _booksStore = booksStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            BookDetailsFormViewModel formViewModel = _addBookViewModel.BookDetailsFormViewModel;

            Book book = new Book(
                Guid.NewGuid(),
                formViewModel.Title, 
                formViewModel.Author, 
                formViewModel.PublicationDate, 
                formViewModel.OriginalLanguage);

            try
            {
                await _booksStore.Add(book);
                _modalNavigationStore.Close();
            }
            catch (Exception) { }

        }
    }
}
