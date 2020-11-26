using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopicosAvancados5.Models;

namespace TopicosAvancados5Tests
{
    [TestClass]
    public class CarrinhoTest
    {
        [TestMethod]
        public void AdicionarProduto_VerificaValor()
        {
            // Arrange
            RepositorioProduto.CarregarRepositorio();
            Carrinho carrinho = new Carrinho();
            double valorEsperado = 11.66;

            // Act
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Camisa", true), 1);
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Bermuda", true), 2);

            // Assert
            double valorAtual = carrinho.ConsultarValor();
            Assert.AreEqual(valorEsperado, valorAtual, 0.001, "Valor Atual do Carrinho diferente do esperado");
        }

        [TestMethod]
        public void AdicionarProduto_VerificaProdutosAdicionados()
        {
            // Arrange
            RepositorioProduto.CarregarRepositorio();
            Carrinho carrinho = new Carrinho();
            var listaProdutosEsperado = new List<ListaProduto>();
            listaProdutosEsperado.Add(new ListaProduto() { Produto = RepositorioProduto.BuscarProduto("Camisa", true), Quantidade = 1 });
            listaProdutosEsperado.Add(new ListaProduto() { Produto = RepositorioProduto.BuscarProduto("Bermuda", true), Quantidade = 2 });

            // Act
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Camisa", true), 1);
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Bermuda", true), 2);


            // Assert
            List<ListaProduto> listaProdutosAtual = carrinho.ConsultarListaDeProdutos();
            CollectionAssert.AreEqual(listaProdutosEsperado.Select(lp => lp.Produto).ToList(), listaProdutosAtual.Select(lp => lp.Produto).ToList());
            CollectionAssert.AreEqual(listaProdutosEsperado.Select(lp => lp.Quantidade).ToList(), listaProdutosAtual.Select(lp => lp.Quantidade).ToList());
        }

        [TestMethod]
        public void AdicionarProduto_VerificaQuantidadeDeProdutosAdicionados()
        {
            // Arrange
            RepositorioProduto.CarregarRepositorio();
            Carrinho carrinho = new Carrinho();
            double quantidadeDeProdutosEsperada = 2;

            // Act
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Camisa", true), 1);
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Casaco", true), 3);
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Calça", true), 2);


            // Assert
            double quantidadeDeProdutosAtual = carrinho.VerificarQuantidadeDeProduto(RepositorioProduto.BuscarProduto("Calça", true));
            Assert.AreEqual(quantidadeDeProdutosEsperada, quantidadeDeProdutosAtual, 0.001, "Quantidade Atual diferente do esperado");
        }

        [TestMethod]
        public void AdicionarProduto_ConsultarQuantidadeTotalDeProduto()
        {
            // Arrange
            RepositorioProduto.CarregarRepositorio();
            Carrinho carrinho = new Carrinho();
            double quantidadeDeProdutosEsperada = 6;

            // Act
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Camisa", true), 1);
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Casaco", true), 3);
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Calça", true), 2);


            // Assert
            double quantidadeDeProdutosAtual = carrinho.ConsultarQuantidadeTotalDeProdutos();
            Assert.AreEqual(quantidadeDeProdutosEsperada, quantidadeDeProdutosAtual, 0.001, "Quantidade Atual diferente do esperado");
        }

        [TestMethod]
        public void RemoverProduto_VerificaValor()
        {
            // Arrange
            RepositorioProduto.CarregarRepositorio();
            Carrinho carrinho = new Carrinho();
            double valorEsperado = 112.44;

            // Act
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Camisa", true), 1);
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Bermuda", true), 2);
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Casaco", true), 1);
            carrinho.RemoverProduto(RepositorioProduto.BuscarProduto("Bermuda", true), 1);

            // Assert
            double valorAtual = carrinho.ConsultarValor();
            Assert.AreEqual(valorEsperado, valorAtual, 0.001, "Valor Atual do Carrinho diferente do esperado");
        }

        [TestMethod]
        public void RemoverProduto_VerificaProdutosAdicionados()
        {
            // Arrange
            RepositorioProduto.CarregarRepositorio();
            Carrinho carrinho = new Carrinho();
            var listaProdutosEsperado = new List<ListaProduto>();
            listaProdutosEsperado.Add(new ListaProduto() { Produto = RepositorioProduto.BuscarProduto("Chinelo", true), Quantidade = 2 });
            listaProdutosEsperado.Add(new ListaProduto() { Produto = RepositorioProduto.BuscarProduto("Calça", true), Quantidade = 3 });

            // Act
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Chinelo", true), 3);
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Camisa", true), 1);
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Calça", true), 3);
            carrinho.RemoverProduto(RepositorioProduto.BuscarProduto("Camisa", true), 1);
            carrinho.RemoverProduto(RepositorioProduto.BuscarProduto("Chinelo", true), 1);

            // Assert
            List<ListaProduto> listaProdutosAtual = carrinho.ConsultarListaDeProdutos();
            CollectionAssert.AreEqual(listaProdutosEsperado.Select(lp => lp.Produto).ToList(), listaProdutosAtual.Select(lp => lp.Produto).ToList());
            CollectionAssert.AreEqual(listaProdutosEsperado.Select(lp => lp.Quantidade).ToList(), listaProdutosAtual.Select(lp => lp.Quantidade).ToList());
        }

        [TestMethod]
        public void RemoverProduto_VerificaQuantidadeDeProdutosAdicionados()
        {
            // Arrange
            RepositorioProduto.CarregarRepositorio();
            Carrinho carrinho = new Carrinho();
            double quantidadeDeProdutosEsperada = 1;

            // Act
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Camisa", true), 1);
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Casaco", true), 3);
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Calça", true), 2);
            carrinho.RemoverProduto(RepositorioProduto.BuscarProduto("Calça", true), 1);

            // Assert
            double quantidadeDeProdutosAtual = carrinho.VerificarQuantidadeDeProduto(RepositorioProduto.BuscarProduto("Calça", true));
            Assert.AreEqual(quantidadeDeProdutosEsperada, quantidadeDeProdutosAtual, 0.001, "Quantidade Atual diferente do esperado");
        }

        [TestMethod]
        public void RemoverProduto_ConsultarQuantidadeTotalDeProduto()
        {
            // Arrange
            RepositorioProduto.CarregarRepositorio();
            Carrinho carrinho = new Carrinho();
            double quantidadeDeProdutosEsperada = 4;

            // Act
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Camisa", true), 1);
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Casaco", true), 3);
            carrinho.AdicionarProduto(RepositorioProduto.BuscarProduto("Calça", true), 2);
            carrinho.RemoverProduto(RepositorioProduto.BuscarProduto("Calça", true), 2);

            // Assert
            double quantidadeDeProdutosAtual = carrinho.ConsultarQuantidadeTotalDeProdutos();
            Assert.AreEqual(quantidadeDeProdutosEsperada, quantidadeDeProdutosAtual, 0.001, "Quantidade Atual diferente do esperado");
        }
    }
}
