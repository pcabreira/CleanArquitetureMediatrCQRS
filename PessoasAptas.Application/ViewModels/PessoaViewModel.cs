namespace PessoasAptas.Application.ViewModels
{
    public class PessoaViewModel
    {
        public PessoaViewModel(int id,
                               string nome,
                               int pontos)
        {
            Id = id;
            Nome = nome;
            Pontos = pontos;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int Pontos { get; private set; }
    }
}
