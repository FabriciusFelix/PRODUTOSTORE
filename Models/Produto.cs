namespace PRODUTOSTORE.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; } = true;
        public bool Perecivel { get; set; }
        public CategoriaProduto Categoria { get; set; }
        public int CategoriaID { get; set; }

    }
}
