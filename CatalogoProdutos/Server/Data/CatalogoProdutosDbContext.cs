using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogoProdutos.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProdutos.Server.Data
{
    public class CatalogoProdutosDbContext : DbContext
    {
        public CatalogoProdutosDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
