using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.Models
{
    public class OurTeam : BaseEntity
    {
        [StringLength(255), Required]
        public string FullName { get; set; }
        [StringLength(255), Required]
        public string Position { get; set; }
        [StringLength(255)]
        public string Image { get; set; }

        [NotMapped]
        public IFormFile OurTeamImage { get; set; }
    }
}
