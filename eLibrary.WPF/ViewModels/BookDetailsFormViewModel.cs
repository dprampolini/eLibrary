using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eLibrary.WPF.ViewModels
{
    public class BookDetailsFormViewModel : ViewModelBase
    {
        private string _title;

        public string Title
        {
            get { 
                return _title; 
            }
            set {
                _title = value; 
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private string _author;

        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private string _originalLanguage;

        public string OriginalLanguage
        {
            get
            {
                return _originalLanguage;
            }
            set
            {
                _originalLanguage = value;
                OnPropertyChanged(nameof(OriginalLanguage));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private string _publicationDate;

        public string PublicationDate
        {
            get
            {
                return _publicationDate;
            }
            set
            {
                _publicationDate = value;
                OnPropertyChanged(nameof(PublicationDate));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public bool CanSubmit => 
            !string.IsNullOrEmpty(Title) && 
            !string.IsNullOrEmpty(Author) && 
            !string.IsNullOrEmpty(OriginalLanguage) &&
            !string.IsNullOrEmpty(PublicationDate);

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public BookDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }
    }
}
