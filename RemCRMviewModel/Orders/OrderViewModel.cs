using RemCRMviewModel.Clients;
using RemCRMviewModel.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMviewModel.Orders
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [DisplayName("Номер")]
        public string Number { get; set; }
        [DisplayName("Статус")]
        public string Status { get; set; }
        [DisplayName("Тип")]
        public int Type { get; set; }
        [DisplayName("Крайний срок")]
        public string Deadline { get; set; }
        [DisplayName("Ориентировачная цена")]
        public string PriceWill { get; set; }
        [DisplayName("Аванс")]
        public string Prepayment { get; set; }
        [DisplayName("Срочно")]
        public bool Quickly { get; set; }
        public ClientViewModel Client { get; set; }
        public DeviceViewModel Device { get; set; }

        public OrderViewModel()
        {
            Client = new ClientViewModel();
            Device = new DeviceViewModel();
        }
    }
}
