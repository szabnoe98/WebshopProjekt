using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopAPI.Models;

namespace WebShopAPI.DTO
{
    public class RendelesiTetelDTO
    {
        
        public string TermekNev { get; set; }
        public int Mennyiseg { get; set; }
        public string VasarloNev { get; set; }

        public int id { get; set; }
        public static RendelesiTetelDTO ConvertToDTO(rendelesi_tetelek rendelesiTetel)
        {
            if (rendelesiTetel == null)
            {
                return null;
            }

            return new RendelesiTetelDTO()
            {
                TermekNev = rendelesiTetel.Termek.Cikknev,
                Mennyiseg = rendelesiTetel.Mennyiseg,
                id = (int)rendelesiTetel.Cikkszam,
                VasarloNev = rendelesiTetel.Rendeles.Vasarlo.TeljesNev,
            };
        }
    }
}
