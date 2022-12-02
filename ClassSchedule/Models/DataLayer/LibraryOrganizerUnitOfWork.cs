using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrganizer.Models
{
    public class LibraryOrganizerUnitOfWork<T> : ILibraryOrganizerUnitOfWork<T> where T : class
    {
        private LibraryContext context { get; set; }
        public LibraryOrganizerUnitOfWork(LibraryContext ctx) => context = ctx;

        private Repository<Title> bookData;
        public Repository<Title> Titles
        {
            get {
                if (bookData == null)
                    bookData = new Repository<Title>(context);
                return bookData;
            }
        }

        private Repository<Author> authorData;
        public Repository<Author> Authors
        {
            get
            {
                if (authorData == null)
                    authorData = new Repository<Author>(context);
                return authorData;
            }
        }

        //private Repository<Day> dayData;
        //public Repository<Day> Days
        //{
        //    get
        //    {
        //        if (dayData == null)
        //            dayData = new Repository<Day>(context);
        //        return dayData;
        //    }
        //}

        public virtual void Save() => context.SaveChanges();
    }
}
