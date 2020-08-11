namespace LootInjection.Business.Models
{
    public class Categoria : Entity
    {
        public string Descricao { get; private set; }

        public Categoria(string descricao)
        {
            Descricao = descricao;
        }
    }
}