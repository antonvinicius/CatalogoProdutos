﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Shared
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}