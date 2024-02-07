using MediatR;

namespace PessoasAptas.Application.Commands.CreatePessoaCriterio
{
    public class CreatePessoaCriterioCommand : IRequest<int>
    {
        public int IdPessoa { get; set; }
        public int IdCriterio { get; set; }
        public int Valor { get; set; }
    }
}
