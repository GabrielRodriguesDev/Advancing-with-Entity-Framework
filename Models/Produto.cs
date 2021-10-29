namespace Advancing_with_Entity_Framework.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }// Nesse momento o EF vai entender que essa propriedade remete a um relacionamento, onde um produto possui uma categoria

        public override string ToString() {
            return "Id: " + this.Id + " Nome: " + this.Nome + " Categoria [" + this.Categoria.ToString() + "] ";
        }
    }
}