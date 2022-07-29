using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;


        public DashboardInteressadaPO(IWebDriver  driver)
        {
            this.driver = driver;
            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");
            byBotaoPesquisar = By.CssSelector("form>button.btn");
        }

        public void PesquisarLeiloes(
            List<string> categorias,
            string termo,
            bool emAndamento)

        {
            var select = new SelectMaterialize(driver, bySelectCategorias);

            select.DeselectAll();
                      
            select.SelectByText(categorias);

            driver.FindElement(byInputTermo).SendKeys(termo);
            if (emAndamento)
            {
                driver.FindElement(byInputAndamento).Click();
            }

            driver.FindElement(byBotaoPesquisar).Click();

        }

        public void EfetuarLogout()
        {
            var linkMeuPerfil = driver.FindElement(byMeuPerfilLink);
            var linkLogout = driver.FindElement(byLogoutLink);

            IAction acaoLogout = new Actions(driver)
                //mover para o elemento meu perfil
                .MoveToElement(linkMeuPerfil)

                //mover para o link logout
                .MoveToElement(linkLogout)

                //clicar no link de logout
                .Click()
                .Build();
            acaoLogout.Perform();

        }
    }
}
