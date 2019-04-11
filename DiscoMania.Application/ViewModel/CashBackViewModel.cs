using DiscoMania.Helper.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.ViewModel
{
    public class CashBackViewModel 
    {
        public int Id { get; set; }
        public EnumGenero Genero { get; set; }
        public int Domingo { get; set; }
        public int Segunda { get; set; }
        public int Terca { get; set; }
        public int Quarta { get; set; }
        public int Quinta { get; set; }
        public int Sexta { get; set; }
        public int Sabado { get; set; }
       

    }
}
