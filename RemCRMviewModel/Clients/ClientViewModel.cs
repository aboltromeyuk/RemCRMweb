using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMviewModel.Clients
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [DisplayName("Тип")]
        public int Type { get; set; }
        [Required]
        [DisplayName("Фамилия")]
        public string Surname { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Отчество")]
        public string Middlename { get; set; }
        [DisplayName("Телефонный номер")]
        public string TelNumber { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [DisplayName("Адрес")]
        public string Address { get; set; }
        [DisplayName("Коментарий")]
        public string Comment { get; set; }
    }
}
