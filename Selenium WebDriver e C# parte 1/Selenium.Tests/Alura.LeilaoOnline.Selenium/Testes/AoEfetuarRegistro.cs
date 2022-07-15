using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using OpenQA.Selenium;
using Alura.LeilaoOnline.Selenium.Fixtures;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }
        
        [Fact]
        public void DadoInformacoesValidasDeveIrParaPaginaDEAgradecimento()
        {
            //Arrange - dado chrome aberto, pagina inicial do sist de leilões,
            //dados de registros validos informados
            driver.Navigate().GoToUrl("http://localhost:5000");

            //nome
            var inputNome = driver.FindElement(By.Id("Nome"));

            //email
            var inputEmail = driver.FindElement(By.Id("Email"));

            //password
            var inputSenha = driver.FindElement(By.Id("Password"));

            //confirmapassword
            var inputConfirmaSenha = driver.FindElement(By.Id("ConfirmPassword"));

            //botao de registro
            var bortaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys("Daniel Portugal");
            inputEmail.SendKeys("daniel.portugal@caelum.com.br");
            inputSenha.SendKeys("123");
            inputConfirmaSenha.SendKeys("123");


            //Act - efetuo registro
            bortaoRegistro.Click();

            //Assert - devo ser direcionado para uma pagina de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);
        }

        [Theory]
        [InlineData("","daniel.portugal@caelum.com.br","123","123")]
        [InlineData("Daniel Portugal","daniel","123","123")]
        [InlineData("Daniel Portugal","daniel.portugal@caelum.com.br","123","456")]
        [InlineData("Daniel Portugal", "daniel.portugal@caelum.com.br","123","")]
        public void DadoInformacoesInvalidasDeveContinuarNaHome(
            string nome,
            string email,
            string senha,
            string confirmaSenha)
        {
            //Arrange - dado chrome aberto, pagina inicial do sist de leilões,
            //dados de registros validos informados
            driver.Navigate().GoToUrl("http://localhost:5000");

            //nome
            var inputNome = driver.FindElement(By.Id("Nome"));

            //email
            var inputEmail = driver.FindElement(By.Id("Email"));

            //password
            var inputSenha = driver.FindElement(By.Id("Password"));

            //confirmapassword
            var inputConfirmaSenha = driver.FindElement(By.Id("ConfirmPassword"));

            //botao de registro
            var bortaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputSenha.SendKeys(senha);
            inputConfirmaSenha.SendKeys(confirmaSenha);

            //Act - efetuo registro
            bortaoRegistro.Click();

            //Assert - devo ser direcionado para uma pagina de agradecimento
            Assert.Contains("section-registro", driver.PageSource);
        }
    }
}
