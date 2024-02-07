using MediatR;
using PessoasAptas.Application.ViewModels;
using PessoasAptas.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PessoasAptas.Application.Queries.GetAllCriterios
{
    public class GetAllCriteriosQueryHandler : IRequestHandler<GetAllCriteriosQuery, List<CriterioViewModel>>
    {
        private readonly ICriterioRepository _criterioRepository;
        public GetAllCriteriosQueryHandler(ICriterioRepository criterioRepository)
        {
            _criterioRepository = criterioRepository;
        }

        public async Task<List<CriterioViewModel>> Handle(GetAllCriteriosQuery request, CancellationToken cancellationToken)
        {
            var criterios = await _criterioRepository.GetAllAsync();

            var criterioViewModel = criterios
                .Select(p => new CriterioViewModel(p.Id, p.Descricao))
                .ToList();

            return criterioViewModel;
        }
    }
}
