namespace PessoasAptas.Application.ViewModels
{
    public class CriterioViewModel
    {
        public CriterioViewModel(int id,
                                 string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public int Id { get; private set; }
        public string Descricao { get; private set; }
    }
}
