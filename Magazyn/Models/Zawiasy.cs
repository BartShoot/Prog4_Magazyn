using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn.Models
{
    [Table("Zawiasy")]
    public class Zawiasy : DomainObject
    {
        [MinLength(2)]
        [Required]
        public string Firma { get; set; }
        [MinLength(2)]
        [Required]
        public string Model { get; set; }
        [Range(0,int.MaxValue)]
        [Required]
        public decimal Cena { get; set; }
        [Range(0, int.MaxValue)]
        [Required]
        public int Ilosc { get; set; }
        [Range(0, int.MaxValue)]
        [Required]
        public int KatOtwarcia { get; set; }
        [Required]
        public bool Hamulec { get; set; }
        [Required]
        public bool Sprezyna { get; set; }
    }
}
