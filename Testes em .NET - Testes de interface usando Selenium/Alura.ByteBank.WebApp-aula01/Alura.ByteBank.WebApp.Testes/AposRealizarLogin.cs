using Alura.ByteBank.WebApp.Testes.PageObjects;
using Alura.ByteBank.WebApp.Testes.Utilitarios;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.WebApp.Testes
{
    public class AposRealizarLogin: IClassFixture<Gerenciador>
    {
        private IWebDriver driver;
        public ITestOutputHelper saidaConsoleTeste;
        public AposRealizarLogin(Gerenciador gerenciador, ITestOutputHelper _saidaConsoleTeste)
        {
            driver = gerenciador.Driver;
        }
        [Fact]
        public void AposRealizarLoginVerificaSeExisteOpcaoAgenciaMenu()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.btnClick();

            //Assert
            Assert.Contains("Agência", driver.PageSource);
        }

        [Fact]
        public void TestaRealizarLoginSemPreencherCampos()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("", "");
            loginPO.btnClick();

            //Assert
            Assert.Contains("The Email field is required.", driver.PageSource);
            Assert.Contains("The Senha field is required.", driver.PageSource);

        } 

        [Fact]
        public void TentaRealizarLoginComSenhaInvalida()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("andre@email.com", "senha10");
            loginPO.btnClick();

            //Assert
            Assert.Contains("Login", driver.PageSource);
        }

        [Fact]
        public void RealizarLoginAcessaMenuECadastraCliente()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.btnClick();

            driver.FindElement(By.LinkText("Cliente")).Click();

            driver.FindElement(By.LinkText("Adicionar Cliente")).Click();

            driver.FindElement(By.Name("Identificador")).Click();
            driver.FindElement(By.Name("Identificador"))
                .SendKeys("2df71922-ca7d-4d43-b142-0767b32f822a");
            driver.FindElement(By.Name("CPF")).Click();
            driver.FindElement(By.Name("CPF")).SendKeys("69981034096"); 
            driver.FindElement(By.Name("Nome")).Click();
            driver.FindElement(By.Name("Nome")).SendKeys("Tobey Garfield");
            driver.FindElement(By.Name("Profissao")).Click();
            driver.FindElement(By.Name("Profissao")).SendKeys("Cientista");

            //Act
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.FindElement(By.LinkText("Home")).Click();

            //Assert
            Assert.Contains("Logout", driver.PageSource);

        }

        [Fact]
        public void RealizaLoginAcessaListagemDeContas()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.btnClick();

            driver.FindElement(By.Id("contacorrente")).Click();

            IReadOnlyCollection<IWebElement> elements =
                driver.FindElements(By.TagName("a"));

            var elemento = (from WebElemento in elements
                            where WebElemento.Text.Contains("Detalhes")
                            select WebElemento).First();

            //Act
            elemento.Click();

            //Assert
            Assert.Contains("Voltar", driver.PageSource);
        }

        [Fact]
        public void RealizaLoginAcessaListagemDeContasUsandoHomePO()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.btnClick();

            var homePO = new HomePO(driver);
            homePO.LinkContaCorrenteClick();

            //Assert
            Assert.Contains("Adicionar Conta-Corrente", driver.PageSource);
        }

        
    }
}
