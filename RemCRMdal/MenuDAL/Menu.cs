using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMdal.MenuDAL
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }

        public Menu()
        {
            Items = new List<Item>();
        }
    }
}
