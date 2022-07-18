using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebShopAPI.Models
{
    [Index(nameof(Vasarlo_id), Name = "Vasarlo_id")]
    public partial class rendeles
    {
        public rendeles()
        {
            rendelesi_tetelek = new List<rendelesi_tetelek>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        
        public int Rendeles_id { get; set; }
        [Column(TypeName = "int(11)")]
        public int? Vasarlo_id { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Rendeles_datuma { get; set; }

        [ForeignKey(nameof(Vasarlo_id))]
        [InverseProperty(nameof(vasarlo.rendeles))]
        [JsonIgnore]
        public virtual vasarlo Vasarlo { get; set; }
        [InverseProperty("Rendeles")]

        //[JsonIgnore]
        public virtual List<rendelesi_tetelek> rendelesi_tetelek { get; set; }
    }
}
