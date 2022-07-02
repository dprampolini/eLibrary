﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eLibrary.WPF.Stores;
using eLibrary.WPF.ViewModels;

namespace eLibrary.WPF.Commands
{
    public class OpenAddBookCommand : CommandBase
    {
        private readonly BooksStore _booksStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddBookCommand(BooksStore booksStore, ModalNavigationStore modalNavigationStore)
        {
            _booksStore = booksStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            AddBookViewModel addBookViewModel = new AddBookViewModel(_booksStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = addBookViewModel;
        }
    }
}
