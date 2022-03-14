using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRODUTOSTORE.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public bool Perecivel { get; set; }
        public CategoriaProduto Categoria { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        public int CategoriaID { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<CategoriaProduto> Categorias { get; set; }

    }
}
