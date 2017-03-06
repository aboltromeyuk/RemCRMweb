using RemCRMdal.ClientsDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMdal.AplicationDAL
{
    public partial class ApplicationContext : DbContext
    {
        public void AddClient(Client client)
        {
            using (var db = new ApplicationContext())
            {
                db.Clients.Add(client);
                db.SaveChanges();
            }
        }
    }
}
