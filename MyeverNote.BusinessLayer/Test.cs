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
            db.Database.CreateIfNotExists();
        }
    }
}
