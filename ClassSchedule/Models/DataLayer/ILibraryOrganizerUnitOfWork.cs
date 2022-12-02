using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOrganizer.Models
{
    public interface ILibraryOrganizerUnitOfWork<T> where T : class
    {
        public Title bookTitle
        {
            get
            {
                return bookTitle;
            }
            set
            {
                bookTitle = value;
            }
        }

        public Author authorName
        {
            get
            {
                return authorName;
            }
            set
            {
                authorName = value;
            }
        }

        //public Day dayNum
        //{
        //    get
        //    {
        //        return dayNum;
        //    }
        //    set
        //    {
        //        dayNum = value;
        //    }
        //}

        void Save();
    }
}
