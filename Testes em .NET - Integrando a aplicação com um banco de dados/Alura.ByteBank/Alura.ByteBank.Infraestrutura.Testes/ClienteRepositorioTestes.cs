using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    
    public class ClienteRepositorioTestes
    {
        private readonly IClienteRepositorio _repositorio;
        public ClienteRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IClienteRepositorio>();

        }

        [Fact]
        public void TestaObte0rTodosClientes()
        {
            //Arrange
            //var _repositorio = new ClienteRepositorio();

            //Act
            List<Cliente> lista = _repositorio.ObterTodos();

            //Assert
            Assert.NotNull(lista);
            Assert.Equal(3, lista.Count);

        }

        [Fact]
        public void TestaObterClientePorId()
        {
            //Arrange
            //Act
            var cliente = _repositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(cliente);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterClientePorVariosId(int id)
        {
            //Arrange
            //Act
            var cliente = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(cliente);
        }

        [Fact]
        public void TestaInserirUmNovoClienteNaBaseDeDados()
        {
            //Arrange
            var cliente = new Cliente()
            {
                Nome = "Misha Silva",
                CPF = "073.451.090-03",
                Identificador = Guid.NewGuid(),
                Profissao = "Bancario",
                Id = 4
            };

            //Act
            var retorno = _repositorio.Adicionar(cliente);

            //Assert
            Assert.True(retorno);
        }

        [Fact]
        public void TestaAtualizacaoInformacaoDeterminadoCliente()
        {
            //Arrange
            var nomeNovo = "Misha da Silva";
            var cliente = _repositorio.ObterPorId(4);
            cliente.Nome = nomeNovo;

            //Act
            var retorno = _repositorio.Atualizar(4, cliente);

            //Assert
            Assert.True(retorno);

        }

        [Fact]
        public void TestaRemoverInformacaoDeterminadoCliente()
        {
            //Arrange
            //Act
            var retorno = _repositorio.Excluir(4);
            //Assert
            Assert.True(retorno);
        }

    }
}
