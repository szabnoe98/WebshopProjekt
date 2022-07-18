using System;
using System.Collections.Generic;
using System.Text;

namespace Webshop_WPF.ViewModels
{
    //Teszthez szükséges
    public class UserViewModel
    {
        public bool Login(string user, string pwd)
        {
            string goodUser = "Erika";
            string goodPwd = "erika";

            //összehasonlítja a beírt és az eltárolt fh-t és jelszót.
            return (0 == String.Compare(user, goodUser) && 0 == String.Compare(pwd, goodPwd));
        }
    }
}
