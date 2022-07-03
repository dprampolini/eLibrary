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
    public class EditBookCommand : AsyncCommandBase
    {
        private readonly BooksStore _booksStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly EditBookViewModel _editBookViewModel;

        public EditBookCommand(EditBookViewModel editBookViewModel, BooksStore booksStore, ModalNavigationStore modalNavigationStore)
        {
            _editBookViewModel = editBookViewModel;
            _booksStore = booksStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            BookDetailsFormViewModel formViewModel = _editBookViewModel.BookDetailsFormViewModel;

            Book book = new Book(
                _editBookViewModel.BookId,
                formViewModel.Title,
                formViewModel.Author,
                formViewModel.PublicationDate,
                formViewModel.OriginalLanguage);

            try
            {
                await _booksStore.Update(book);
                _modalNavigationStore.Close();
            }
            catch (Exception) { }
        }
    }
}
