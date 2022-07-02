using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eLibrary.WPF.Stores;
using eLibrary.WPF.Models;

namespace eLibrary.WPF.ViewModels
{
    public class BookDetailsViewModel : ViewModelBase
    {
        private readonly SelectedBookStore _selectedBookStore;
        private Book SelectedBook => _selectedBookStore.SelectedBook;
        public bool HasSelectedBook => SelectedBook != null;

        public string Title => SelectedBook?.Title ?? "Sconosciuto";
        public string Author => SelectedBook?.Author ?? "Sconosciuto";
        public string PublicationDate => SelectedBook?.PublicationDate ?? "Sconosciuto";
        public string OriginalLanguage => SelectedBook?.OriginalLanguage ?? "Sconosciuto";

        public BookDetailsViewModel(SelectedBookStore selectedBookStore)
        {
            _selectedBookStore = selectedBookStore;

            _selectedBookStore.SelectedBookChanged += SelectedBookStore_SelectedBookChanged;
        }

        protected override void Dispose()
        {
            _selectedBookStore.SelectedBookChanged -= SelectedBookStore_SelectedBookChanged;

            base.Dispose();
        }

        private void SelectedBookStore_SelectedBookChanged()
        {
            OnPropertyChanged(nameof(HasSelectedBook));
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Author));
            OnPropertyChanged(nameof(PublicationDate));
            OnPropertyChanged(nameof(OriginalLanguage));
        }
    }
}
