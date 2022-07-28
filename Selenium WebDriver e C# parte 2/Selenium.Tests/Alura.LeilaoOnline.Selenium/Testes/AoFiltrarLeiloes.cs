using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoFiltrarLeiloes
    {
        private IWebDriver driver;
        public AoFiltrarLeiloes(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaAoFiltrarLeiloesDeveMostrarPainelResultado()
        {
            //Arrange
            var loginPo = new LoginPO(driver);
            loginPo.Visitar();
            loginPo.PreencheFormulario("fulano@example.org", "123");
            loginPo.SubmeteFormulario();

            var dashboardInteressadaPO = new DashboardInteressadaPO(driver);

            //Act
            dashboardInteressadaPO.PesquisarLeiloes(new List<string> { "Arte", "Coleções" });

            //Assert

        }
    }
}
