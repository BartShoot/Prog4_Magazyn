using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn.Models
{
    [Table("Prowadnice")]
    public class Prowadnice
    {
        [Key]
        public int ProwadniceID { get; set; }
        [Required]
        public string Firma { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public decimal Cena { get; set; }
        [Required]
        public int Ilosc { get; set; }
        [Required]
        public decimal Dlugosc { get; set; }
        [Required]
        public bool Samodomyk { get; set; }
    }
}
