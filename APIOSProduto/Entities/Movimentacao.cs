namespace APIOSProduto.Entities
{
    public class Movimentacao
    {
        public  int Id  { get; set; }
        public  int  ProdutoId { get; set; }
        public  string Tipo  { get; set; }
        public  int  Quantidade { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
