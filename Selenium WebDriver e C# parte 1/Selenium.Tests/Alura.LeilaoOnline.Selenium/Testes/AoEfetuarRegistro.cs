using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using OpenQA.Selenium;
using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;

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
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencherFormulario("Daniel Portugal", "daniel.portugal@caelum.com.br", "123", "123");

            //Act - efetuo registro
            registroPO.SubmeteFormulario();

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
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();


            registroPO.PreencherFormulario(nome, email, senha, confirmaSenha);

            //Act - efetuo registro
            registroPO.SubmeteFormulario();

            //Assert - devo ser direcionado para uma pagina de agradecimento
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //Arrange
            var registroPO = new RegistroPO(driver);

            registroPO.Visitar();

            //Act
            registroPO.SubmeteFormulario();

            //Assert
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));
            Assert.Equal("The Nome field is required.", elemento.Text);
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //Arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencherFormulario(
                nome: "",
                email: "daniel",
                senha: "",
                confirmSenha: ""
                );
            
            //Act
            registroPO.SubmeteFormulario();

            //Assert
            Assert.Equal("Please enter a valid email address.", registroPO.EmailMensagemErro);
        }
    }
}
