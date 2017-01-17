using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WebShop.Models
{
    public class MessageViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле \"Имя\" должно быть заполнено", ErrorMessageResourceName = "", ErrorMessageResourceType = null)]
        [StringLength(100, MinimumLength = 6)]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле \"Email\" должно быть заполнено", ErrorMessageResourceName = "", ErrorMessageResourceType = null)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле \"Cообщение\" должно быть заполнено", ErrorMessageResourceName = "", ErrorMessageResourceType = null)]        
        public string Text { get; set; }
    }
}
