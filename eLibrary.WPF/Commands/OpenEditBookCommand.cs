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
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly Book _book;

        public OpenEditBookCommand(
            Book book,
            ModalNavigationStore modalNavigationStore)
        {
            _book = book;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            EditBookViewModel editBookViewModel = new EditBookViewModel(_book, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editBookViewModel;
        }
    }
}
