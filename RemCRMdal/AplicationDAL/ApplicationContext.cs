using RemCRMdal.ClientsDAL;
using RemCRMdal.DevicesDAL;
using RemCRMdal.MenuDAL;
using RemCRMdal.OrdersDAL;
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
        public ApplicationContext() : base("DefaultConnection") { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}
