using MediatR;
using PessoasAptas.Application.ViewModels;
using PessoasAptas.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PessoasAptas.Application.Queries.GetAllPessoas
{
    public class GetAllPessoasQueryHandler : IRequestHandler<GetAllPessoasQuery, List<PessoaViewModel>>
    {
        private readonly IPessoaRepository _pessoaRepository;
        public GetAllPessoasQueryHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<List<PessoaViewModel>> Handle(GetAllPessoasQuery request, CancellationToken cancellationToken)
        {
            var pessoas = await _pessoaRepository.GetAllAsync();

            var pessoasViewModel = pessoas
                .Select(p => new PessoaViewModel(p.Id, p.Nome, p.Pontos))
                .ToList();

            return pessoasViewModel;
        }
    }
}
