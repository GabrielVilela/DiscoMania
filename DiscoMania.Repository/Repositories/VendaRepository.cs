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
    public class VendaRepository : RepositoryBase<Venda, VendaFilter>, IVendaRepository
    {
        private readonly DiscoManiaContext _context;
        public VendaRepository(IDBContext dbContext, DiscoManiaContext context) : base(dbContext)
        {
            _context = context;
        }
        public override PagedList<Venda> FindByFilter(VendaFilter filter)
        {
            var query = _dbSet.AsNoTracking();

            if (filter.DataVendaInicio != null && filter.DataVendaFim != null)
                query = query.Where(x => x.DataVenda <= filter.DataVendaFim && x.DataVenda >= filter.DataVendaInicio);
            else if (filter.DataVendaInicio == null && filter.DataVendaFim != null)
                query = query.Where(x => x.DataVenda <= filter.DataVendaFim);
            else if (filter.DataVendaInicio != null && filter.DataVendaFim == null)
                query = query.Where(x => x.DataVenda >= filter.DataVendaInicio);

            return query.ToPagedList(filter.Page, filter.PageSize);
        }
        public Venda FindByIdCompleta(int id)
        {
            var ven = from v in _context.Vendas
                        where v.Id == id
                         select v;
            var venda = ven.FirstOrDefault();
            var discosDaVenda = from dv in _context.DiscoVendas
                                .Include(d => d.Disco)
                                where dv.VendaId == id
                                select dv;

            venda.DiscosDaVenda = discosDaVenda.ToList();

            return venda;
        }
    }
}
