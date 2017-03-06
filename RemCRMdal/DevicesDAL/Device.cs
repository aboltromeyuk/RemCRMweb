using RemCRMdal.OrdersDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMdal.DevicesDAL
{
    public class Device
    {
        [Key]
        [ForeignKey("Order")]
        public int Id { get; set; }
        public int Type { get; set; }
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Defect { get; set; }
        public string Appearance { get; set; }
        public string Equipment { get; set; }
        public Order Order { get; set; }
    }
}
