using PessoasAptas.Core.Entities;
using PessoasAptas.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PessoasAptas.Application.Commands.CreateCriterio
{
    public class CreateCriterioCommandHandler : IRequestHandler<CreateCriterioCommand, int>
    {
        private readonly ICriterioRepository _criterioRepository;
        public CreateCriterioCommandHandler(ICriterioRepository criterioRepository)
        {
            _criterioRepository = criterioRepository;
        }

        public async Task<int> Handle(CreateCriterioCommand request, CancellationToken cancellationToken)
        {
            var criterio = new Criterio(request.Descricao);

            await _criterioRepository.AddAsync(criterio);

            return criterio.Id;
        }
    }
}
