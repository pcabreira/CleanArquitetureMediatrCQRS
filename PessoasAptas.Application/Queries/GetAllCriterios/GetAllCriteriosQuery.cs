using MediatR;
using PessoasAptas.Application.ViewModels;
using System.Collections.Generic;

namespace PessoasAptas.Application.Queries.GetAllCriterios
{
    public class GetAllCriteriosQuery : IRequest<List<CriterioViewModel>>
    {

    }
}
