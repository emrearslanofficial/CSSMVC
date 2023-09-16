using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        Repository<Category> repocategory = new Repository<Category>();

        public List<Category> GetAll()
        {
            return repocategory.List();
        }

        public int CategoryAddBL(Category p)
        {
            if (p.CategoryName == "" || p.CategoryDescription == "")
            {
                return -1;
            }
            return repocategory.Insert(p);
        }

        public Category FindCategory(int id)
        {
            return repocategory.Find(x => x.CategoryId == id);
        }

        public int EditCategory(Category p)
        {
            Category category = repocategory.Find(x => x.CategoryId == p.CategoryId);
            category.CategoryName = p.CategoryName;
            category.CategoryDescription = p.CategoryDescription;
            return repocategory.Update(category);
        }

    }
}
