using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.Models
{
    public class Contact : BaseEntity
    {
        [StringLength(255), Required]
        public string FullName { get; set; }
        [StringLength(255)]
        public string Phone { get; set; }
        [StringLength(255), Required]
        public string Email { get; set; }
        [StringLength(255), Required]
        public string Message { get; set; }
    }
}
