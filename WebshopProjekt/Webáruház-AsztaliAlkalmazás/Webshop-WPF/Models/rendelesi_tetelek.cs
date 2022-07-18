using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Webshop_WPF.Models
{
    [Index(nameof(Cikkszam), Name = "Cikkszam")]
    [Index(nameof(Rendeles_id), Name = "Rendeles_id")]
    public partial class rendelesi_tetelek
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int Rendelesi_tetelek_id { get; set; }
        [Column(TypeName = "int(11)")]
        public int? Rendeles_id { get; set; }
        [Column(TypeName = "int(10)")]
        public int Cikkszam { get; set; }
        [Column(TypeName = "int(11)")]
        public int Mennyiseg { get; set; }

        [ForeignKey(nameof(Cikkszam))]
        [InverseProperty(nameof(termek.rendelesi_tetelek))]
        public virtual termek CikkszamNavigation { get; set; }
        [ForeignKey(nameof(Rendeles_id))]
        [InverseProperty(nameof(rendeles.rendelesi_tetelek))]
        public virtual rendeles Rendeles { get; set; }
    }
}
