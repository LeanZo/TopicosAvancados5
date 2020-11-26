using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopicosAvancados5.Models
{
    public class Carrinho
    {
        private List<ListaProduto> ListaProdutos { get; set; } = new List<ListaProduto>();

        private double ValorTotal { get; set; } = 0.0;

        public List<ListaProduto> ConsultarListaDeProdutos()
        {
            return ListaProdutos;
        }

        public void AdicionarProduto(Produto produto, int quantidade)
        {
            if(VerificarQuantidadeDeProduto(produto) > 0)
            {
                ListaProdutos.Where(prod => prod.Produto.Nome == produto.Nome).First().Quantidade += quantidade;
            }
            else
            {
                ListaProdutos.Add(new ListaProduto() { Produto = produto, Quantidade = quantidade });
            }

            SomarValor(produto.Valor, quantidade);
        }

        public void RemoverProduto(Produto produto, int quantidade)
        {
            var quantidadeNoCarrinho = VerificarQuantidadeDeProduto(produto);

            if (quantidadeNoCarrinho > 0)
            {
                if (quantidadeNoCarrinho > quantidade)
                {
                    ListaProdutos.Where(prod => prod.Produto.Nome == produto.Nome).First().Quantidade -= quantidade;
                }
                else
                {
                    ListaProdutos.Remove(ListaProdutos.Where(prod => prod.Produto.Nome == produto.Nome).First());
                }
            
                SubtrairValor(produto.Valor, quantidade);
            }
        }
        public double ConsultarQuantidadeTotalDeProdutos()
        {
            return ListaProdutos.Select(lp => lp.Quantidade).Sum();
        }

        public double VerificarQuantidadeDeProduto(Produto produto)
        {
            return (ListaProdutos.Where(prod => prod.Produto.Nome == produto.Nome).Count() != 0) ? ListaProdutos.Where(prod => prod.Produto.Nome == produto.Nome).First().Quantidade : 0.0;
        }

        public double ConsultarValor()
        {
            return ValorTotal;
        }

        private void SomarValor(double valor, int quantidade)
        {
            ValorTotal += (valor * quantidade);
        }

        private void SubtrairValor(double valor, int quantidade)
        {
            ValorTotal -= (valor * quantidade);
        }


    }
}