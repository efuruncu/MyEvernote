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
            MyEverNote.DataAccessLayer.DatabaseContext db = new MyEverNote.DataAccessLayer.DatabaseContext();
            db.EvernoteUsers.ToList();
        }
    }
}
