using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eLibrary.WPF.Stores;

namespace eLibrary.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public bool IsModalOpen => _modalNavigationStore.IsOpen;

        public eLibraryViewModel ELibraryViewModel { get; }

        public MainViewModel(ModalNavigationStore modalNavigationStore, eLibraryViewModel eLibraryViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            ELibraryViewModel = eLibraryViewModel;

            _modalNavigationStore.CurrentViewModelChanged += ModalNavigationStore_CurrentViewModelChanged;

        }

        protected override void Dispose()
        {
            _modalNavigationStore.CurrentViewModelChanged -= ModalNavigationStore_CurrentViewModelChanged;
            base.Dispose();
        }

        private void ModalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
