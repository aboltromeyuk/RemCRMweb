using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMviewModel.Devices
{
    public class DeviceViewModel
    {
        public int Id { get; set; }
        [DisplayName("Тип")]
        public int Type { get; set; }
        [DisplayName("Серийный номер")]
        public string SerialNumber { get; set; }
        [DisplayName("Производитель")]
        public string Brand { get; set; }
        [DisplayName("Модель")]
        public string Model { get; set; }
        [DisplayName("Неисправность")]
        public string Defect { get; set; }
        [DisplayName("Внешний вид")]
        public string Appearance { get; set; }
        [DisplayName("Комплектация")]
        public string Equipment { get; set; }
    }
}
