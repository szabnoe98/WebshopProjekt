using System;
using System.Collections.Generic;
using System.Text;

namespace Webshop_WPF.Stores
{
    public class RunEnviroment
    {
        static bool TestEnviroment = false;

        static public void ChangeToTestEnviroment()
        {
            TestEnviroment = true;
        }

        public static bool IsTestEnviroment
        {
            get
            {
                return TestEnviroment;
            }
        }
    }
}
