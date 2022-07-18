using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebShopAPI.Models
{
    public partial class termek
    {
        public termek()
        {
            rendelesi_tetelek = new HashSet<rendelesi_tetelek>();
        }

        [Key]
        [Column(TypeName = "int(10)")]
        public int Cikkszam { get; set; }
        [StringLength(50)]
        public string Cikknev { get; set; }
        [StringLength(50)]
        public string Gyarto { get; set; }
        [Column(TypeName = "int(11)")]
        public int? KeszletDB { get; set; }
        [Column(TypeName = "int(11)")]
        public int? Beszerzesi_ar { get; set; }
        [Column(TypeName = "int(11)")]
        public int? Eladasi_ar { get; set; }
        [StringLength(15)]
        public string Kiszereles { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Beszerzes_datuma { get; set; }
        [StringLength(255)]
        public string Foto { get; set; }
        public bool? Akcios_e { get; set; }

        [InverseProperty("Termek")]
        [JsonIgnore]
        public virtual ICollection<rendelesi_tetelek> rendelesi_tetelek { get; set; }
    }
}
