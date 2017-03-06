using RemCRMdal.OrdersDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMdal.ClientsDAL
{
    public class Client
    {
        [Key]
        [ForeignKey("Order")]
        public int Id { get; set; }
        public int Type { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string TelNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
        public Order Order { get; set; }
    }
}
