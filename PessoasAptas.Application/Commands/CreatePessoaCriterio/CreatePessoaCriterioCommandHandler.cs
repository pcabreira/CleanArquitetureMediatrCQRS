using DevFreela.Core.Enums;
using MediatR;
using PessoasAptas.Core.Entities;
using PessoasAptas.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PessoasAptas.Application.Commands.CreatePessoaCriterio
{
    public class CreatePessoaCriterioCommandHandler : IRequestHandler<CreatePessoaCriterioCommand, int>
    {
        private readonly IPessoaCriterioRepository _pessoaCriterioRepository;
        private readonly IPessoaRepository _pessoaRepository;

        public CreatePessoaCriterioCommandHandler(IPessoaCriterioRepository pessoaCriterioRepository,
                                                  IPessoaRepository pessoaRepository)
        {
            _pessoaCriterioRepository = pessoaCriterioRepository;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<int> Handle(CreatePessoaCriterioCommand request, CancellationToken cancellationToken)
        {
            var pessoaCriterioExistente = await _pessoaRepository.GetPessoaCriteriosByIdAsync(request.IdPessoa, request.IdCriterio);
            var pessoaCriterio = new PessoaCriterio(request.IdPessoa, request.IdCriterio, request.Valor);

            if (pessoaCriterioExistente == null)
            {
                await _pessoaCriterioRepository.AddAsync(pessoaCriterio);

                int pontos = request.IdCriterio switch
                {
                    (int)CriteriosEnum.Renda => request.Valor <= 900 ? 5 : request.Valor >= 901 && request.Valor <= 1500 ? 3 : 0,
                    (int)CriteriosEnum.Dependentes => request.Valor >= 3 ? 3 : request.Valor == 1 || request.Valor == 2 ? 2 : 0,
                    _ => 0
                };

                var pessoa = await _pessoaRepository.GetByIdAsync(request.IdPessoa);
                int novaPontuacao = pessoa.Pontos + pontos;

                pessoa.Update(novaPontuacao);

                await _pessoaRepository.SaveChangesAsync();
            }

            return pessoaCriterio.Id;
        }
    }
}
