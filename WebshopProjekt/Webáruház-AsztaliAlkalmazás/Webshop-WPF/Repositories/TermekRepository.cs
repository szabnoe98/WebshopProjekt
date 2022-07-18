using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webshop_WPF.Models;

namespace Webshop_WPF.Repositories
{
    public class TermekRepository : GenericRepository<termek, webaruhazContext>
    {
        
        public TermekRepository(webaruhazContext context) : base(context)
        {

        }

        private int _totalItems;
        

        public List<termek> GetAll(
            int page = 1,
            int itemsPerOldal = 20,
            string search = null,
            string sortBy = null,
            bool ascending = true)
        {
            
            var query = _context.Set<termek>().AsQueryable();
            // Keresés
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                // Számra keresés
                int.TryParse(search, out int KeszletDB);
               
                // Dátumra keresés
                DateTime.TryParse(search, out DateTime datum);

                query = query.Where(x =>
                   
                    x.Cikknev.ToLower().Contains(search) ||
                    x.KeszletDB.Equals(KeszletDB) ||
                   
                    x.Beszerzes_datuma.Equals(datum));
            }

            // Sorbarendezés
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy)
                {
                    case "Cikknev":
                        query = ascending ? query.OrderBy(x => x.Cikknev) : query.OrderByDescending(x => x.Cikknev);
                        break;
                    case "KeszletDB":
                        query = ascending ? query.OrderBy(x => x.KeszletDB) : query.OrderByDescending(x => x.KeszletDB);
                        break;
                    case "Akcios_e":
                        query = ascending ? query.OrderBy(x => x.Akcios_e) : query.OrderByDescending(x => x.Akcios_e);
                        break;
                    case "Beszerzes_datuma":
                        query = ascending ? query.OrderBy(x => x.Beszerzes_datuma) : query.OrderByDescending(x => x.Beszerzes_datuma);
                        break;
                   
                    default:
                        query = ascending ? query.OrderBy(x => x.Cikkszam) : query.OrderByDescending(x => x.Cikkszam);
                        break;
                }
            }

            // Összes találat
            _totalItems = query.Count();

            // Oldaltördelés, mínusz oldalak elkerülése
            if (page + itemsPerOldal > 0)
            {
                query = query.Skip((page - 1) * itemsPerOldal).Take(itemsPerOldal);
            }
            return query.ToList();
        }

        public int TotalItems
        {
            get { return _totalItems; }
        }

        public bool Exist(int id)
        {
            return _context.termek.Any(x => x.Cikkszam == id);
        }

    }
}
