using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop_WPF.Stores;
using Webshop_WPF.ViewModels;

namespace WebShopTest.ViewModels
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]

        public void TestGoodLogin()
        {
            RunEnviroment.ChangeToTestEnviroment();
            UserViewModel user = new UserViewModel();

            UserViewModel oUser = new UserViewModel();
            Assert.AreEqual(true, oUser.Login("Erika", "erika"), "Helytelen adatot adott meg");


        }


    }
}
