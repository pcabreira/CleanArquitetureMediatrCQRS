using MediatR;
using PessoasAptas.Application.ViewModels;
using System.Collections.Generic;

namespace PessoasAptas.Application.Queries.GetAllPessoas
{
    public class GetAllPessoasQuery : IRequest<List<PessoaViewModel>>
    {

    }
}
