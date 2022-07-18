using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Webshop_WPF.Models
{
    public partial class termek
    {
        public termek()
        {
            rendelesi_tetelek = new HashSet<rendelesi_tetelek>();//Hashset = Nincs ismétlődő elem a listában
        }

        public void Copy(ref termek toCopy)
        {
            toCopy.Cikknev = Cikknev;
            toCopy.KeszletDB = KeszletDB;
            toCopy.Beszerzes_datuma = Beszerzes_datuma;
            toCopy.Akcios_e = Akcios_e;
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

        [InverseProperty("CikkszamNavigation")]
        public virtual ICollection<rendelesi_tetelek> rendelesi_tetelek { get; set; }
    }
}
