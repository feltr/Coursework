using Coursework.Core.Abstractions;
using Coursework.Core.Models;
using Coursework.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.DataAccess.Repositories
{
    public class PechRepository : IPechRepository
    {
        private readonly PechDbContext _context;
        public PechRepository(PechDbContext context)
        {
            _context = context;
        }
        public async Task<List<Pech>> Get()
        {
            var pechEntities = await _context.Pech
                .AsNoTracking()
                .ToListAsync();

            var pech = pechEntities
                .Select(p => Pech.Create(p.Id, p.tPech, p.diametr, p.tNach, p.kTeplo, p.kTeplo, p.p, p.tPov, p.kPer).pech)
                .ToList();

            return pech;
        }
        public async Task<Guid> Create(Pech pech)
        {
            var pechEntity = new PechEntity
            {
                Id = pech.Id,
                tPech = pech.tPech,
                diametr = pech.diametr,
                tNach = pech.tNach,
                kTeplo = pech.kTeplo,
                p = pech.p,
                tPov = pech.tPov,
                kPer = pech.kPer
            };
            await _context.Pech.AddAsync(pechEntity);
            await _context.SaveChangesAsync();

            return pechEntity.Id;
        }

        public async Task<Guid> Update(Guid id, float tPech, float diametr, float tNach, float kTeplo, float p, float tPov, float kPer)
        {
            await _context.Pech
                .Where(p => p.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.tPech, p => tPech)
                .SetProperty(p => p.diametr, p => diametr)
                .SetProperty(p => p.tNach, p => tNach)
                .SetProperty(p => p.kTeplo, p => kTeplo)
                .SetProperty(_p => _p.p, _p => p)
                .SetProperty(p => p.tPov, p => tPov)
                .SetProperty(p => p.kPer, p => kPer)
                );
            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Pech
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
