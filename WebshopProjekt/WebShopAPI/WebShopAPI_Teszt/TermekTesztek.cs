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

       

        // GET: api/Termek, Darabsz�m ellen�rz�se
        [TestMethod]
        public async Task GetTermek_DarabszamMegfelel()
        {
            // Http Response �zenet
            var response = await controller.Gettermek();
            // IEnumerable a v�lasz
            var result = response.Value;
            // List�v� alak�tjuk
            var result2 = response.Value as List<termek>;

            Assert.IsNotNull(result);
            int szamlalo = 78; 
            Assert.AreEqual(result.Count(), szamlalo);
            Assert.AreEqual(result2.Count, szamlalo);
        }

        // GET: api/Termek/88326 Term�kn�v ellen�rz�se
        [TestMethod]
        public async Task GetTermek_ValaszUgyanazonNevvel()
        {
            //�sszeshasonl�t�si alap
            var termek = GetPeldaTermek();
            var response = await controller.Gettermek(88326);
            var result = response.Value;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Cikknev, termek.Cikknev);
        }

        // POST: api/Termek, Konfliktus ellen�rz�se
        [TestMethod]
        public async Task PostTermek_KonfliktusValasszal()
        {
            var termek = GetPeldaTermek();
            var response = await controller.Posttermek(termek);
            // konfliktus v�lasz t�puss� �talak�t�s
            var result = response.Result as ConflictObjectResult;

            Assert.IsNotNull(result);
            // T�pus ellen�rz�se a p�ld�nynak
            Assert.IsInstanceOfType(result, typeof(ConflictObjectResult));
            // 409-es, Conflit st�tuszk�d �sszehasonl�t�s
            Assert.AreEqual(result.StatusCode, 409);
        }

        // PUT: api/Termek/111111, Hiba elt�r� cikksz�m eset�n
        [TestMethod]
        public async Task PutTermek_HibaElteroIDnal()
        {
            // a 111111-es cikksz�mra k�ld�m a 88326-os cikksz�m� term�ket
            var response = await controller.Puttermek(111111, GetPeldaTermek());
            Assert.IsInstanceOfType(response, typeof(BadRequestResult));

            // Itt konvert�l�s is t�rt�nik
            var result = response as BadRequestResult;
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            //Assert.IsInstanceOfType( V�rt t�pus, aktu�lis objektum );
        }

   
    }
}
