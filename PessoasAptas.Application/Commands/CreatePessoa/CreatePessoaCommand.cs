using MediatR;

namespace PessoasAptas.Application.Commands.CreatePessoa
{
    public class CreatePessoaCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public int Pontos { get; set; }
    }
}
