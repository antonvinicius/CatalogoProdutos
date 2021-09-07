using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Shared
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
