using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.ViewModel
{
    public class VendaCompletaMinViewModel
    {
        public DateTime DataVenda { get; set; }
        public List<DiscoVendaCompletaMinViewModel> DiscosDaVenda { get; set; }

    }
}
