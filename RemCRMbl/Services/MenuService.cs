using RemCRMdal.AplicationDAL;
using RemCRMdal.MenuDAL;
using RemCRMviewModel.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMbl.Services
{
    public class MenuService
    {
        public ApplicationContext Context { get; set; }

        public void AddMenu(string nameMenu)        //add menu by name
        {
            Context.AddMenu(nameMenu);
        }

        public MenuViewModel GetMenu(int idMenu)        //get menu by id
        {
            var menuGetting = Context.GetMenu(idMenu);
            var itemsGetting = new List<ItemViewModel>();
            var result = new MenuViewModel();

            try
            {
                foreach (var item in menuGetting.Items)
                {
                    itemsGetting.Add(new ItemViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Url = item.Url
                    });
                }

                result.Id = menuGetting.Id;
                result.Name = menuGetting.Name;
                result.Items = itemsGetting;
            }

            catch (NullReferenceException)
            {
                result = null;
            }

            return result;
        }

        public MenuViewModel GetMenu(string nameMenu)       //get menu by name
        {
            var menuGetting = Context.GetMenu(nameMenu);
            var itemsGetting = new List<ItemViewModel>();
            var result = new MenuViewModel();

            try
            {
                foreach (var item in menuGetting.Items)
                {
                    itemsGetting.Add(new ItemViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Url = item.Url
                    });
                }

                result.Id = menuGetting.Id;
                result.Name = menuGetting.Name;
                result.Items = itemsGetting;

            }

            catch (NullReferenceException)
            {
                result = null;
            }

            return result;
        }

        public void AddItemToMenu(int idMenu, ItemViewModel item)       //add item to menu by id
        {
            var itemAdding = new Item
            {
                Id = item.Id,
                Name = item.Name,
                Url = item.Url
            };

            Context.AddItemToMenu(idMenu, itemAdding);
        }

    }
}
