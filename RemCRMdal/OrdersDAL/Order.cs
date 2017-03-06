using RemCRMdal.ClientsDAL;
using RemCRMdal.DevicesDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMdal.OrdersDAL
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public int Type { get; set; }
        public string Deadline { get; set; }
        public string PriceWill { get; set; }
        public string Prepayment { get; set; }
        public bool Quickly { get; set; }
        public Device Device { get; set; }
        public Client Client { get; set; }

        //public Order()
        //{
        //    Client = new Client();
        //    Device = new Device();
        //}
    }
}
