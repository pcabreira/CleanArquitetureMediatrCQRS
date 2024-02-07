using PessoasAptas.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PessoasAptas.Core.Repositories
{
    public interface ICriterioRepository
    {
        Task AddAsync(Criterio criterio);
        Task<List<Criterio>> GetAllAsync();
    }
}
