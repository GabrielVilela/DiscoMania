using DiscoMania.Domain.Entities;
using DiscoMania.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscoMania.Repository.Contexts
{
    public class DiscoManiaContext : DbContext, IDBContext
    {
        public DiscoManiaContext()
        {
        }
        public DiscoManiaContext(DbContextOptions<DiscoManiaContext> options)
            : base(options)
        {
        }

        public DbSet<Disco> Discos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<DiscoVenda> DiscoVendas { get; set; }
        public DbSet<CashBack> CashBacks { get; set; }


    }
}
