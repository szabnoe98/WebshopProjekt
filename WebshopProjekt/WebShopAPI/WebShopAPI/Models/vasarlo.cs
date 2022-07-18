using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebShopAPI.Models
{
    public partial class vasarlo
    {
        public vasarlo()
        {
            rendeles = new HashSet<rendeles>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Vasarlo_id { get; set; }
        [StringLength(50)]
        public string Vezeteknev { get; set; }
        [StringLength(50)]
        public string Keresztnev { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Telefonszam { get; set; }
        [StringLength(50)]
        public string Felhasznalonev { get; set; }
        [JsonIgnore]
        [StringLength(50)]
        public string Jelszo { get; set; }
        [StringLength(50)]
        public string Varos { get; set; }
        [StringLength(50)]
        public string Cim { get; set; }
        [Column(TypeName = "int(11)")]
        public int? Iranyitoszam { get; set; }

        // Ez csak itt érvényes, máshol nem kap szerepet rz az entitás
        [NotMapped]
        public string TeljesNev { get { return $"{Vezeteknev} {Keresztnev}"; } }


        [InverseProperty("Vasarlo")]
        public virtual ICollection<rendeles> rendeles { get; set; }
    }
}
