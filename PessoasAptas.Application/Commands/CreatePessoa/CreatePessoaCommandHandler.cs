using PessoasAptas.Core.Entities;
using PessoasAptas.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PessoasAptas.Application.Commands.CreatePessoa
{
    public class CreatePessoaCommandHandler : IRequestHandler<CreatePessoaCommand, int>
    {
        private readonly IPessoaRepository _pessoaRepository;
        public CreatePessoaCommandHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<int> Handle(CreatePessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoa = new Pessoa(request.Nome, request.Pontos);

            await _pessoaRepository.AddAsync(pessoa);

            return pessoa.Id;
        }
    }
}
