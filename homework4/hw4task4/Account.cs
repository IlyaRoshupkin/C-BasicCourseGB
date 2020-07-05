using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hw4task4
{
    struct Account
    {
        public string Login;
        public string Password;
        StreamReader streamReader;

        public Account(string textName)
        {
            streamReader = new StreamReader(textName);
            Login = streamReader.ReadLine();
            Password = streamReader.ReadLine();
        }
    }
}
