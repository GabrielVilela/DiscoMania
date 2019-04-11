using System;
using System.Collections.Generic;
using System.Text;

namespace Filters.DomainFilters
{
    public class VendaFilter : FilterBase
    {
        public DateTime DataVendaInicio { get; set; }
        public DateTime DataVendaFim { get; set; }
        //public decimal ValorTotalVenda { get; set; }
        //public decimal ValorTotalCashBack { get; set; }
    }
}
