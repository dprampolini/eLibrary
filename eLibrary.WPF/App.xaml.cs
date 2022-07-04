using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using eLibrary.WPF.Stores;
using eLibrary.WPF.ViewModels;

namespace eLibrary.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly BooksStore _booksStore;
        private readonly SelectedBookStore _selectedBookStore;
        private readonly ResearchStore _researchStore;

        public App()
        {
            _modalNavigationStore = new ModalNavigationStore();
            _booksStore = new BooksStore();
            _selectedBookStore = new SelectedBookStore(_booksStore);
            _researchStore = new ResearchStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            eLibraryViewModel eLibraryViewModel = new eLibraryViewModel(
                _booksStore,
                _selectedBookStore,
                _modalNavigationStore,
                _researchStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, eLibraryViewModel)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
