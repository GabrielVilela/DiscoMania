using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.ViewModel
{
    public class VendaMinViewModel
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotalVenda { get; set; }
        public decimal ValorTotalCashBack { get; set; }

    }
}
