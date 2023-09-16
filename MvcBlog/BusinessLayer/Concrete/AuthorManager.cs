using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager
    {
        Repository<Author> repoauthor = new Repository<Author>();

        public List<Author> GetAll()
        {
            return repoauthor.List();
        }
        public int AddAuthorBL(Author p)
        {
            if(p.AuthorName=="" || p.AboutShort=="" || p.Mail=="" || p.Password=="" || p.PhoneNumber=="" || p.Mail.Length <= 20)
            {
                return -1;
            }
            return repoauthor.Insert(p);
        }

        public Author FindAuthor(int id)
        {
            return repoauthor.Find(x => x.AuthorId == id);
        }

        public int EditAuthor(Author p)
        {
            Author author = repoauthor.Find(x => x.AuthorId == p.AuthorId);
            author.AboutShort = p.AboutShort;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorName = p.AuthorName;
            author.AuthorTitle = p.AuthorTitle;
            author.Mail = p.Mail;
            author.Password = p.Password;
            author.PhoneNumber = p.PhoneNumber;
            return repoauthor.Update(author);
        }

    }
}
