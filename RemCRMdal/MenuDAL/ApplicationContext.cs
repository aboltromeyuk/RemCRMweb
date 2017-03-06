using RemCRMdal.MenuDAL;
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
        internal bool CheckNameOfMenu(ApplicationContext db, string nameMenu)     //check name of menu for original
        {
            return (db.Menus.Where(m => m.Name == nameMenu).FirstOrDefault() == null) ? true : false;
        }

        public void AddMenu(string nameMenu)        //add menu by name
        {
            using (var db = new ApplicationContext())
            {
                db.Menus.Add(new Menu
                {
                    Name = nameMenu
                });
                
                if (this.CheckNameOfMenu(db, nameMenu)) db.SaveChanges();
            }
        }

        public Menu GetMenu(int idMenu)     //get menu by id
        {
            var menuGetting = new Menu();

            using (var db = new ApplicationContext())
            {
                try
                {
                    menuGetting = db.Menus.Where(menu => menu.Id == idMenu).Include(x => x.Items).Single();
                }
                catch (InvalidOperationException)
                {
                    menuGetting = null;
                }
            }

            return menuGetting;
        }

        public Menu GetMenu(string nameMenu)        //get menu by name
        {
            var menuGetting = new Menu();

            using (var db = new ApplicationContext())
            {
                try
                {
                    menuGetting = db.Menus.Where(menu => menu.Name == nameMenu).Include(x => x.Items).Single();
                }
                catch (InvalidOperationException)
                {
                    menuGetting = null;
                }
            }

            return menuGetting;
        }

        public void AddItemToMenu(int idMenu, Item item)      //add item to menu by id
        {
            using (var db = new ApplicationContext())
            {
                var menuUpdating = db.Menus.Where(menu => menu.Id == idMenu).Single();
                menuUpdating.Items.Add(item);
                db.SaveChanges();
            }
        }

    }
}
