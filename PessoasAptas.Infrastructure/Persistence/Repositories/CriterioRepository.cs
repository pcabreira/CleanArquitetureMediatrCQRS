using Microsoft.EntityFrameworkCore;
using PessoasAptas.Core.Entities;
using PessoasAptas.Core.Repositories;
using PessoasAptas.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CriteriosAptas.Infrastructure.Persistence.Repositories
{
    public class CriterioRepository : ICriterioRepository
    {
        private readonly BeneficioGovernoDbContext _dbContext;

        public CriterioRepository(BeneficioGovernoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Criterio>> GetAllAsync()
        {
            return await _dbContext.Criterios.ToListAsync();
        }

        public async Task AddAsync(Criterio pessoa)
        {
            await _dbContext.Criterios.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();
        }
    }
}
