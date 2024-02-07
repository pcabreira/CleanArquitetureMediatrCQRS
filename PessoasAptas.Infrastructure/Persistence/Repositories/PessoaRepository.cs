using Microsoft.EntityFrameworkCore;
using PessoasAptas.Core.Entities;
using PessoasAptas.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasAptas.Infrastructure.Persistence.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly BeneficioGovernoDbContext _dbContext;

        public PessoaRepository(BeneficioGovernoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Pessoa>> GetAllAsync()
        {
            return await _dbContext.Pessoas
                                   .OrderByDescending(x=>x.Pontos)
                                   .ToListAsync();
        }

        public async Task AddAsync(Pessoa pessoa)
        {
            await _dbContext.Pessoas.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PessoaCriterio> GetPessoaCriteriosByIdAsync(int idPEssoa, int IdCriterio)
        {
            return await _dbContext.PessoaCriterios.SingleOrDefaultAsync(p => p.IdPessoa == idPEssoa && p.IdCriterio == IdCriterio);
        }

        public async Task<Pessoa> GetByIdAsync(int id)
        {
            return await _dbContext.Pessoas.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
