using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.EF;
using System.Threading.Tasks;

namespace Model.DAO
{
   public  class SlideDAO
    {
        OnlineShopDbContext db = null;
        public SlideDAO()
        {
            db = new OnlineShopDbContext();
        }

        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        }
    }
}
