using DiscoMania.Domain.Entities;
using DiscoMania.Domain.Interfaces;
using DiscoMania.Repository.Contexts;
using DiscoMania.Repository.Interfaces;
using Filters.DomainFilters;
using Filters.Extensions;
using Filters.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscoMania.Repository.Repositories
{
    public class DiscoVendaRepository : RepositoryBase<DiscoVenda, DiscoVendaFilter>, IDiscoVendaRepository
    {
        public DiscoVendaRepository(IDBContext dbContext) : base(dbContext)
        {
        }
        public override PagedList<DiscoVenda> FindByFilter(DiscoVendaFilter filter)
        {
            var query = _dbSet.AsNoTracking();

            query = query.Where(x => x.VendaId == filter.VendaId);

            return query.ToPagedList(filter.Page, filter.PageSize);
        }
    }
}
