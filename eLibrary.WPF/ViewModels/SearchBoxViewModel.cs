using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eLibrary.WPF.Stores;

namespace eLibrary.WPF.ViewModels
{
    public  class SearchBoxViewModel : ViewModelBase
    {
        private readonly ResearchStore _researchStore;

        private string _searchText;

        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));

                _researchStore.Research = _searchText;
            }
        }

        public SearchBoxViewModel(ResearchStore researchStore)
        {
            _researchStore = researchStore;
        }   
    }
}
