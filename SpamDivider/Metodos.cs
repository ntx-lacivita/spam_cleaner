using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamDivider
{
    class Metodos
    {
        public void SpamRegister(string login, string senha)
        {
            var result = Cleaner();
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            IWebDriver driver = new ChromeDriver("C:\\", options);
            driver.Url = "https://webmail-seguro.com.br/ntx.com.br/";
            driver.FindElement(By.Id("rcmloginuser")).SendKeys(login);
            driver.FindElement(By.Id("rcmloginpwd")).SendKeys(senha);
            driver.FindElement(By.Id("submitloginform")).Click();
            try
            {
                driver.FindElement(By.Id("close-popover")).Click();
            }
            catch { }
            driver.FindElement(By.Id("lm-user-dropdown-options")).Click();
            driver.FindElement(By.XPath("//span[contains(text(),'Configurações')]")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Filtros e Regras')]")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Emails Bloqueados')]")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Filtros e Regras')]")).Click();
            for (int i = 0; i < result.Count; i++)
            {
                driver.FindElement(By.Id("lm-add-address")).SendKeys(result[i]);
                driver.FindElement(By.Id("lm-add-button")).Click();
                if (i % 9 == 0 && i != 0)
                {
                    driver.FindElement(By.Id("save-button")).Click();
                }
                if (i == result.Count - 1)
                {
                    driver.FindElement(By.Id("save-button")).Click();
                }
            }
            driver.Close();
        }

        public List<string> Cleaner()
        {
            List<string> lista = new List<string>();

            lista = LeitorCSV(lista);

            var resultado = lista.Distinct().ToList();

            for (int z = 0; z < resultado.Count; z++)
            {
                string reposicao = resultado[z];
                string[] split = reposicao.Split('@');
                resultado[z] = split[1];
            }

            var provedores = resultado.Distinct().ToList();
            return provedores;
        }

        public List<string> LeitorCSV(List<string> lista)
        {

            string[] vetor = File.ReadAllLines(ConfigurationManager.AppSettings["Arquivo"]);

            for (int i = 0; i < vetor.Length; i++)
            {
                lista.Add(vetor[i]);
            }
            return lista;
        }
    }
}
