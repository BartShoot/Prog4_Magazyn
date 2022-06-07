using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn.Models
{
    [Table("RozmiaryPlyt")]
    public class RozmiaryPlyt : DomainObject
    {
        [Required]
        public int Dlugosc { get; set; }
        [Required]
        public int Szerokosc { get; set; }
        [Required]
        public int Grubosc { get; set; }
        [Required]
        public int Ilosc { get; set; }
        [Required]
        public int PlytaID { get; set; }
        [Required]
        [ForeignKey("PlytaID")]
        public Plyty Plyta { get; set; }
    }
}
