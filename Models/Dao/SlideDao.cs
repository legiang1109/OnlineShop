using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.EF;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class SlideDao
    {
        OnlineShopDbcontext db = null;
        public SlideDao()
        {
            db = new OnlineShopDbcontext();
        }

        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        }
    }
}
