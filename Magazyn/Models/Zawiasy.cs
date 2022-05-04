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
    public class Zawiasy
    {
        [Key]
        public int ZawiasID { get; set; }
        [Required]
        public string Firma { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public decimal Cena { get; set; }
        [Required]
        public int Ilosc { get; set; }
        [Required]
        public int Kat_Otwarcia { get; set; }
        [Required]
        public bool Hamulec { get; set; }
        [Required]
        public bool Sprezyna { get; set; }
    }
}
