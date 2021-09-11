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
        [MinLength(3, ErrorMessage = "O nome precisa ter no mínimo 3 caracteres")]
        public string Nome { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Preço não pode ser 0")]
        public double Preco { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Categoria é obrigatório")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
