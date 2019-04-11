using System;
using System.Collections.Generic;
using System.Text;

namespace Filters.DomainFilters
{
    public class DiscoVendaFilter : FilterBase
    {
        public int Id { get; set; }
        public int DiscoId { get; set; }
        public int VendaId { get; set; }
        public int Qtde { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorCashBack { get; set; }
    }
}
