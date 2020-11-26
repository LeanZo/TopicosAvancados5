using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopicosAvancados5.Models;

namespace TopicosAvancados5Tests
{
    [TestClass]
    public class RepositorioProdutoTest
    {
        [TestMethod]
        public void BuscarProduto_Identico()
        {
            // Arrange
            RepositorioProduto.CarregarRepositorio();
            string nomeEsperado = "Casaco";
            double valorEsperado = 105.00;

            // Act
            string nomeAtual = RepositorioProduto.BuscarProduto("Casaco", true).Nome;
            double valorAtual = RepositorioProduto.BuscarProduto("Casaco", true).Valor;
            

            // Assert
            Assert.AreEqual(nomeEsperado, nomeAtual, "Nome Atual diferente do esperado");
            Assert.AreEqual(valorEsperado, valorAtual, 0.001, "Valor Atual diferente do esperado");
        }

        [TestMethod]
        public void BuscarProduto_NaoIdentico()
        {
            // Arrange
            RepositorioProduto.CarregarRepositorio();
            string nomeEsperado = "Camisa";
            double valorEsperado = 3.22;

            // Act
            string nomeAtual = RepositorioProduto.BuscarProduto("Cam", false).Nome;
            double valorAtual = RepositorioProduto.BuscarProduto("isa", false).Valor;


            // Assert
            Assert.AreEqual(nomeEsperado, nomeAtual, "Nome Atual diferente do esperado");
            Assert.AreEqual(valorEsperado, valorAtual, 0.001, "Valor Atual diferente do esperado");
        }

        [TestMethod]
        public void TodosProdutos()
        {
            // Arrange
            RepositorioProduto.CarregarRepositorio();
            List<Produto> produtosEsperados = new List<Produto>();
            produtosEsperados.Add(new Produto { Nome = "Camisa", Valor = 3.22 });
            produtosEsperados.Add(new Produto { Nome = "Bermuda", Valor = 4.22 });
            produtosEsperados.Add(new Produto { Nome = "Chinelo", Valor = 12.50 });
            produtosEsperados.Add(new Produto { Nome = "Casaco", Valor = 105.00 });
            produtosEsperados.Add(new Produto { Nome = "Calça", Valor = 30.99 });

            // Act
            List<Produto> produtosAtuais = RepositorioProduto.TodosProdutos();

            // Assert
            CollectionAssert.AreEqual(produtosEsperados.Select(p => p.Nome).ToList(), produtosAtuais.Select(p => p.Nome).ToList());
            CollectionAssert.AreEqual(produtosEsperados.Select(p => p.Valor).ToList(), produtosAtuais.Select(p => p.Valor).ToList());
        }
    }
}
