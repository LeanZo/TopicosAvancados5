using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopicosAvancados5.Models
{
    public static class RepositorioProduto
    {
        private static List<Produto> ProdutosRepositorio { get; set; }

        public static int CarregarRepositorio()
        {
            if(ProdutosRepositorio == null)
            {
                ProdutosRepositorio = new List<Produto>();

                ProdutosRepositorio.Add(new Produto { Nome = "Camisa", Valor = 3.22 });
                ProdutosRepositorio.Add(new Produto { Nome = "Bermuda", Valor = 4.22 });
                ProdutosRepositorio.Add(new Produto { Nome = "Chinelo", Valor = 12.50 });
                ProdutosRepositorio.Add(new Produto { Nome = "Casaco", Valor = 105.00 });
                ProdutosRepositorio.Add(new Produto { Nome = "Calça", Valor = 30.99 });
            }

            return ProdutosRepositorio.Count;
        }

        public static List<Produto> TodosProdutos()
        {
            return ProdutosRepositorio;
        }

        public static Produto BuscarProduto(string nome, bool identico)
        {
            if (identico)
            {
                return ProdutosRepositorio.Where(prod => prod.Nome.ToUpper() == nome.ToUpper()).FirstOrDefault();
            }
            else
            {
                return ProdutosRepositorio.Where(prod => prod.Nome.ToUpper().Contains(nome.ToUpper())).FirstOrDefault();
            }
        }
    }
}