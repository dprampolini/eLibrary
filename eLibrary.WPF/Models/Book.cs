using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLibrary.WPF.Models
{
    public class Book
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Author { get; }
        public string PublicationDate { get; }
        public string OriginalLanguage { get; }

        public Book(Guid id, string _title, string _author, string _publicationDate, string _originalLanguage)
        {
            this.Id = id;
            this.Title = _title;
            this.Author = _author;
            this.PublicationDate = _publicationDate;
            this.OriginalLanguage = _originalLanguage;
        }
    }
}
