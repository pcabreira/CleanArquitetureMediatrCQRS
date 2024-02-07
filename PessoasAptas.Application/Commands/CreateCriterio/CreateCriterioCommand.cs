using MediatR;

namespace PessoasAptas.Application.Commands.CreateCriterio
{
    public class CreateCriterioCommand : IRequest<int>
    { 
        public string Descricao { get; set; }
    }
}
