using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn.Models
{
    [Table("Plyty")]
    public class Plyty : DomainObject
    {
        public Plyty()
        {
            RozmiaryPlyt = new HashSet<RozmiaryPlyt>();
        }
        [Required]
        public string Firma { get; set; }
        [Required]
        public string Kolor { get; set; }
        [Required]
        public string Typ { get; set; }
        [Required]
        public virtual ICollection<RozmiaryPlyt> RozmiaryPlyt { get; set; }
    }
}
