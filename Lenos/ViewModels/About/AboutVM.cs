using Lenos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.ViewModels.About
{
    public class AboutVM
    {
        public IEnumerable<ProductPromo> ProductPromos { get; set; }
        public IEnumerable<OurTeam> OurTeams { get; set; }
    }
}
