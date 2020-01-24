using MyEverNote.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyeverNote.BusinessLayer
{
    public class RepositoryBase
    {
        //Tek bir databasecontext oluşturulması için singleton pattern yapısı kullanıldı.
        protected static DatabaseContext context;
        private static object _lockSync = new object();
        protected RepositoryBase()
        {
            CreateContext();
        }
        private static void CreateContext()
        {
            if (context == null)
            {
                lock (_lockSync)
                {
                    if (context == null)
                    {
                        context = new DatabaseContext();
                    }
                }
            }

        }
    }
}
