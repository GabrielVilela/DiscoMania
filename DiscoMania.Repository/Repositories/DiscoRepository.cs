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
    public class DiscoRepository : RepositoryBase<Disco, DiscoFilter>, IDiscoRepository
    {
        public DiscoRepository(IDBContext dbContext) : base(dbContext)
        {
        }
        public override PagedList<Disco> FindByFilter(DiscoFilter filter)
        {
            var query = _dbSet.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(filter.NomeArtista))
                query = query.Where(x => x.NomeArtista.ToLower().Contains(filter.NomeArtista.ToLower()));
            if (!string.IsNullOrWhiteSpace(filter.TituloAlbum))
                query = query.Where(x => x.TituloAlbum.ToLower().Contains(filter.TituloAlbum.ToLower()));
            if (filter.Genero.HasValue)
                query = query.Where(x => (int)x.Genero == filter.Genero.Value);

            return query.ToPagedList(filter.Page, filter.PageSize);
        }
    }
}
