﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.WebApp.Testes.PageObjects
{
    public class HomePO
    {
        private IWebDriver driver;
        private By linkHome;
        private By linkContaCorrente;
        private By linkClientes;
        private By linkAgencias;

        public HomePO(IWebDriver driver)
        {
            this.driver = driver;
            linkHome = By.Id("home");
            linkContaCorrente = By.Id("contacorrente");
            linkClientes = By.Id("clientes");
            linkAgencias = By.Id("agencias");
        }

        public void Navegar(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void LinkHomeClicl()
        {
            driver.FindElement(linkHome).Click();
        }

        public void LinkContaCorrenteClick()
        {
            driver.FindElement(linkContaCorrente).Click();
        }

        public void LinkClientesClick()
        {
            driver.FindElement(linkClientes).Click();
        }

        public void LinkAgenciasClink()
        {
            driver.FindElement(linkAgencias).Click();
        }
    }
}
