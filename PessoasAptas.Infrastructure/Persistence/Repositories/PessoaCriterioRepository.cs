using Microsoft.EntityFrameworkCore;
using PessoasAptas.Core.Entities;
using PessoasAptas.Core.Repositories;
using PessoasAptas.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CriteriosAptas.Infrastructure.Persistence.Repositories
{
    public class PessoaCriterioRepository : IPessoaCriterioRepository
    {
        private readonly BeneficioGovernoDbContext _dbContext;

        public PessoaCriterioRepository(BeneficioGovernoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PessoaCriterio>> GetAllAsync()
        {
            return await _dbContext.PessoaCriterios.ToListAsync();
        }

        public async Task AddAsync(PessoaCriterio pessoaCriterio)
        {
            await _dbContext.PessoaCriterios.AddAsync(pessoaCriterio);
            await _dbContext.SaveChangesAsync();
        }
    }
}
