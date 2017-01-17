using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DomainModel
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
        [StringLength(30)]
        public string Email { get; set; }
        [StringLength(1000)]
        public string Text { get; set; }
    }
}
