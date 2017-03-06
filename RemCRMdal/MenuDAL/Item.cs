using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMdal.MenuDAL
{
    public class Item
    {
        [Key]
        //[ForeignKey("Menu")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Menu Menu { get; set; }

    }
}
