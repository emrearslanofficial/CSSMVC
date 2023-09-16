using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserProfileManager
    {
        Repository<Author> repouser = new Repository<Author>();
        Repository<Blog> repouserblog = new Repository<Blog>();
        public List<Author> GetAuthorByMail(string p)
        {
            return repouser.List(x => x.Mail == p);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repouserblog.List(x => x.AuthorId == id);
        }
        public int EditAuthor(Author p)
        {
            Author author = repouser.Find(x => x.AuthorId == p.AuthorId);
            author.AboutShort = p.AboutShort;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorName = p.AuthorName;
            author.AuthorTitle = p.AuthorTitle;
            author.Mail = p.Mail;
            author.Password = p.Password;
            author.PhoneNumber = p.PhoneNumber;
            return repouser.Update(author);
        }
    }
}
