using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.ViewModel
{
    public class DiscoVendaViewModel
    {
        public int DiscoId { get; set; }
        public DiscoViewModel Disco { get; set; }
        public int VendaId { get; set; }
        public int Qtde { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorCashBack { get; set; }

    }
}
