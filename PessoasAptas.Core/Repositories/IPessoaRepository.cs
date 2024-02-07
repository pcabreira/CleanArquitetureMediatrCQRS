using PessoasAptas.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PessoasAptas.Core.Repositories
{
    public interface IPessoaRepository
    {
        Task AddAsync(Pessoa pessoa);
        Task<List<Pessoa>> GetAllAsync();
        Task<PessoaCriterio> GetPessoaCriteriosByIdAsync(int idPEssoa, int IdCriterio);
        Task<Pessoa> GetByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
