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
using System.Diagnostics;

namespace SpamDivider
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime inicio = DateTime.Now;
            Metodos metodos = new Metodos();
            string login = ConfigurationManager.AppSettings["Login"];
            string senha = ConfigurationManager.AppSettings["Senha"];
            metodos.SpamRegister(login,senha);
            File.WriteAllText("log-resultados.txt", "Quantidade de dominios:" + (metodos.Cleaner().Count - 1) + 
                " - Data/Hora de Início: " + inicio + " - Data/Hora de Início: " + DateTime.Now);
            Console.Read();
        }
    }
}
