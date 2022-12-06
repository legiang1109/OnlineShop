using Models.EF;
using System.Collections.Generic;
using System.Linq;

namespace Models.Dao
{
    public class CategoryDao
    {
        OnlineShopDbcontext db = null;
        public CategoryDao()
        {
            db = new OnlineShopDbcontext();
        }
        public long Insert(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return category.ID;
        }
        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }
    }
}
