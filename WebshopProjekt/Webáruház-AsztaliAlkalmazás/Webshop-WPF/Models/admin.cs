using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Webshop_WPF.Models
{
    public partial class admin
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string Felhasznalonev { get; set; }
        [Required]
        [StringLength(255)]
        public string Jelszo { get; set; }
    }
}
