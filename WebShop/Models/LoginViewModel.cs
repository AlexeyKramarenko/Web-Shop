using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WebShop.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле \"UserName\" должно быть установлено")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле \"Пароль\" должно быть заполнено")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
