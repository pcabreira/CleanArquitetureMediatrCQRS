namespace PessoasAptas.Application.ViewModels
{
    public class CriterioPessoaViewModel
    {
        public CriterioPessoaViewModel(int id,
                                       int idPessoa,
                                       int idCriterio,
                                       int valor)
        {
            Id = id;
            IdPessoa = idPessoa;
            IdCriterio = idCriterio;
            Valor = valor;
        }

        public int Id { get; private set; }
        public int IdPessoa { get; private set; }
        public int IdCriterio { get; private set; }
        public int Valor { get; private set; }
    }
}
