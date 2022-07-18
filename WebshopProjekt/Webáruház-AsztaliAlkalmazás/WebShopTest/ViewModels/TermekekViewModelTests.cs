using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop_WPF.Models;
using Webshop_WPF.Stores;
using Webshop_WPF.ViewModels;


namespace WebshopTests.ViewModels.Tests
{
    [TestClass()]
    public class TermekekViewModelTests
    {
        [TestMethod()]

        public void TermekekViewModelTest_GetAllDataFromTestDatabase()
        {
            RunEnviroment.ChangeToTestEnviroment();
            TermekekViewModel termekekViewModel = new TermekekViewModel();

            int elvart = 10;
            int aktualis = termekekViewModel.Termekek.Count;

            Assert.AreEqual(elvart, aktualis, "Nem lett beolvasva az összes termék");
        }


        [TestMethod()]

        public void TermekekViewModelTest_DeleteInsertTermekTestDatabase()
        {

            RunEnviroment.ChangeToTestEnviroment();
            TermekekViewModel termekekViewModel = new TermekekViewModel();

            List<termek> termekek = termekekViewModel.Termekek.ToList();

            if (termekek.Count > 0)
            {
                termek deletetermek = termekek.ElementAt(0);
                termekekViewModel.Delete(deletetermek);

                int elvart = 5;
                int aktualis = termekekViewModel.Termekek.Count;
                Assert.AreEqual(elvart, aktualis, "Törlés után nem csökkent a terméklista");
            }


        }


       [TestMethod()]
        public void CikkszamOK()
        {

            RunEnviroment.ChangeToTestEnviroment();
            TermekekViewModel termekekViewModel = new TermekekViewModel();

            List<termek> termekek = termekekViewModel.Termekek.ToList();

            //Ellenőrzi, hogy a megadott feltétel igaz-e, és kivételt dob, ha a feltétel hamis.

            Assert.AreEqual(termekek.Any(x => x.Cikkszam == 4191), true, "Nincs ilyen cikkszám");

        }

        





    }
}

