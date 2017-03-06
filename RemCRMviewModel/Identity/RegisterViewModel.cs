using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMviewModel.Identity
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [DisplayName("Подтверждение пароля")]
        public string ConfirmPassword { get; set; }
        [Required]
        [DisplayName("Фамилия")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Имя")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Отчество")]
        public string Midlename { get; set; }
        [DisplayName("Телефонный номер")]
        public string PhoneNumber { get; set; }
        [DisplayName("Роль")]
        public string Role { get; set; }
        public List<string> RoleList { get; set; } 

        public RegisterViewModel()
        {
            RoleList = new List<string>();
        }
    }
}
