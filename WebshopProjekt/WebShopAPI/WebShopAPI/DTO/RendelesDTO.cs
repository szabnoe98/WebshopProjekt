using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopAPI.Models;

namespace WebShopAPI.DTO
{
    public class RendelesDTO
    {
        public int Rendeles_id { get; set; }
        public string Vezeteknev { get; set; }
        public string Keresztnev { get; set; }
        public string Lakcim { get; set; }
        public DateTime? Rendeles_datuma { get; set; }





        public List<RendelesiTetelDTO> RendelesiTetelek { get; set; }

        public static RendelesDTO ConvertToDTO(rendeles rendeles)
        {
            if (rendeles == null)
            {
                return null;
            }

            var rendelesDTO = new RendelesDTO()
            {
                Rendeles_id = rendeles.Rendeles_id,
                Vezeteknev = rendeles.Vasarlo.Vezeteknev,
                Keresztnev = rendeles.Vasarlo.Keresztnev,
                Lakcim = $"{rendeles.Vasarlo.Varos}, {rendeles.Vasarlo.Cim}",
                Rendeles_datuma = rendeles.Rendeles_datuma,

                RendelesiTetelek = new List<RendelesiTetelDTO>()


            };
            foreach (var tetel in rendeles.rendelesi_tetelek)
            {
                rendelesDTO.RendelesiTetelek.Add(RendelesiTetelDTO.ConvertToDTO(tetel));
            }
            return rendelesDTO;
        }
    }
}
