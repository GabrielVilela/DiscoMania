using DiscoMania.Domain.Entities;
using DiscoMania.Domain.Interfaces;
using DiscoMania.Helper.Enums;
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
    public class CashBackRepository : RepositoryBase<CashBack, CashBackFilter>, ICashBackRepository
    {
        private readonly DiscoManiaContext _context;
        public CashBackRepository(IDBContext dbContext, DiscoManiaContext context) : base(dbContext)
        {
            _context = context;
        }
        public override PagedList<CashBack> FindByFilter(CashBackFilter filter)
        {
            var query = _dbSet.AsNoTracking();

            if (filter.Genero == null)
                query = query.Where(x => x.Genero == filter.Genero.Value);
         

            return query.ToPagedList(filter.Page, filter.PageSize);
        }

        public CashBack RetornaPorGenero(EnumGenero genero)
        {
            var query = from p in _context.CashBacks
                        where p.Genero == genero
                        select p;
            return query.Select(cashback => new CashBack()
            {
                Domingo = cashback.Domingo,
                Segunda = cashback.Segunda,
                Terca = cashback.Terca,
                Quarta = cashback.Quarta,
                Quinta = cashback.Quinta,
                Sexta = cashback.Sexta,
                Sabado = cashback.Sabado,
                Id = cashback.Id,
                Genero = cashback.Genero                
            }
            ).FirstOrDefault();
        }
    }
}
