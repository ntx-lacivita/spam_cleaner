using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SpamDivider
{
    class Program
    {
        static void Main(string[] args)
        {
            Metodos metodos = new Metodos();
            string login = ConfigurationManager.AppSettings["Login"];
            string senha = ConfigurationManager.AppSettings["Senha"];

            metodos.SpamRegister(login,senha);
        }
    }
}
