using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoProdutos.Shared
{
    public class Produto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preço é obrigatório")]
        public double Preco { get; set; }
        [Required(ErrorMessage = "Categoria é obrigatório")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
