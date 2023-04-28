using System.Collections.Generic;
using Models;
using MyProject.Data;

namespace Controllers
{
    public class ProdutoController
    {
        public void CriarProduto(Models.Produto produto)
        {
            using (var context = new Context())
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
        }

        public void AtualizarProduto(Models.Produto produto)
        {
            using (var context = new Context())
            {
                context.Produtos.Update(produto);
                context.SaveChanges();
            }
        }

        public void DeletarProduto(Models.Produto produto)
        {
            using (var context = new Context())
            {
                context.Produtos.Remove(produto);
                context.SaveChanges();
            }
        }

        public List<Models.Produto> ListarProdutos()
        {
            using (var context = new Context())
            {
                return context.Produtos.ToList();
            }
        }

        public Models.Produto BuscarProduto(int id)
        {
            using (var context = new Context())
            {
                return context.Produtos.Find(id);
            }
        }
    }
}
