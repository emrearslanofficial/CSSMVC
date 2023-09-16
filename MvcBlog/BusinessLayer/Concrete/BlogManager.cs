using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager
    {
        Repository<Blog> repoblog = new Repository<Blog>();

        public object Request { get; private set; }

        public List<Blog> GetAll()
        {
            return repoblog.List();
        }

        public List<Blog> GetBlogByID(int id)
        {
            return repoblog.List(x => x.BlogId == id);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoblog.List(x=>x.AuthorId==id);
        }

        public List<Blog> GetBlogByCategory(int id)
        {
            return repoblog.List(x=>x.CategoryId==id);
        }
        public int BlogAddBL(Blog p)
        {
            Blog b = new Blog();
            if (p.BlogTitle=="" || p.BlogImage=="" || p.BlogTitle.Length<=5 || p.BlogContent.Length<=200)
            {
                return -1;
            }
            
           return repoblog.Insert(p);
        }

        public int DeleteBlogBL(int p)
        {
            Blog blog = repoblog.Find(x => x.BlogId == p);
            return repoblog.Delete(blog);
        }

        public Blog FindBlog(int id)
        {
            return repoblog.Find(x=>x.BlogId==id);
        }
    
        public int UpdateBlog(Blog p)
        {
            Blog blog = repoblog.Find(x => x.BlogId == p.BlogId);
            blog.BlogTitle = p.BlogTitle;
            blog.BlogContent = p.BlogContent;
            blog.BlogDate = p.BlogDate;
            blog.BlogImage = p.BlogImage;
            blog.CategoryId = p.CategoryId;
            blog.AuthorId = p.AuthorId;
            return repoblog.Update(blog);
        }
    
    }
}
