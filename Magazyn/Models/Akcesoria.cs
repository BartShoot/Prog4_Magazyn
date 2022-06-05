using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn.Models
{
    [Table("Akcesoria")]
    public class Akcesoria : DomainObject
    {
        [Required]
        public string Firma { get; set; }
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public int Ilosc { get; set; }
    }
}
