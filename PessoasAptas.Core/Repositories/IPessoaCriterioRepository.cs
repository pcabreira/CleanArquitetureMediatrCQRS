using PessoasAptas.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PessoasAptas.Core.Repositories
{
    public interface IPessoaCriterioRepository
    {
        Task AddAsync(PessoaCriterio pessoaCriterio);
        Task<List<PessoaCriterio>> GetAllAsync();
    }
}
