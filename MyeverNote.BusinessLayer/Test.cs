using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyeverNote.BusinessLayer
{
   public class Test
    {
        public Test()
        {
            //Eğer database veritabanında mevcut değilse oluştur.
            MyEverNote.DataAccessLayer.DatabaseContext db = new MyEverNote.DataAccessLayer.DatabaseContext();
           //Database ile birlikte verilerinde oluşması için select sorgusununda çalışması gerekiyor.
            db.Categories.ToList();
        }
    }
}
