using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopAPI.Controllers;
using WebShopAPI.Models;

namespace WebShopAPI_Teszt
{
    [TestClass]
    public class TermekTesztek
    {

        private termekController controller = new termekController(new webaruhazContext());

        private termek GetPeldaTermek()
        {
            return new termek()
            {
                Cikkszam = 88326,
                Cikknev = "Ammerland trappista 500g",
                Gyarto = "Ammerland"
            };
        }

       

        // GET: api/Termek, Darabszám ellenõrzése
        [TestMethod]
        public async Task GetTermek_DarabszamMegfelel()
        {
            // Http Response üzenet
            var response = await controller.Gettermek();
            // IEnumerable a válasz
            var result = response.Value;
            // Listává alakítjuk
            var result2 = response.Value as List<termek>;

            Assert.IsNotNull(result);
            int szamlalo = 78; 
            Assert.AreEqual(result.Count(), szamlalo);
            Assert.AreEqual(result2.Count, szamlalo);
        }

        // GET: api/Termek/88326 Terméknév ellenõrzése
        [TestMethod]
        public async Task GetTermek_ValaszUgyanazonNevvel()
        {
            //összeshasonlítási alap
            var termek = GetPeldaTermek();
            var response = await controller.Gettermek(88326);
            var result = response.Value;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Cikknev, termek.Cikknev);
        }

        // POST: api/Termek, Konfliktus ellenõrzése
        [TestMethod]
        public async Task PostTermek_KonfliktusValasszal()
        {
            var termek = GetPeldaTermek();
            var response = await controller.Posttermek(termek);
            // konfliktus válasz típussá átalakítás
            var result = response.Result as ConflictObjectResult;

            Assert.IsNotNull(result);
            // Típus ellenõrzése a példánynak
            Assert.IsInstanceOfType(result, typeof(ConflictObjectResult));
            // 409-es, Conflit státuszkód összehasonlítás
            Assert.AreEqual(result.StatusCode, 409);
        }

        // PUT: api/Termek/111111, Hiba eltérõ cikkszám esetén
        [TestMethod]
        public async Task PutTermek_HibaElteroIDnal()
        {
            // a 111111-es cikkszámra küldöm a 88326-os cikkszámú terméket
            var response = await controller.Puttermek(111111, GetPeldaTermek());
            Assert.IsInstanceOfType(response, typeof(BadRequestResult));

            // Itt konvertálás is történik
            var result = response as BadRequestResult;
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            //Assert.IsInstanceOfType( Várt típus, aktuális objektum );
        }

   
    }
}
