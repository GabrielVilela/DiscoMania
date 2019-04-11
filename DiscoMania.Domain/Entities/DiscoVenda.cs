using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DiscoMania.Domain.Entities
{
    [Table("DiscoVenda")]
    public class DiscoVenda : Base<DiscoVenda>
    {
        [ForeignKey("Disco")]
        public int DiscoId { get; set; }
        [ForeignKey("DiscoId")]
        public Disco Disco { get; set; }
        [ForeignKey("Venda")]
        public int VendaId { get; set; }
        [Column("Qtde")]
        public int Qtde { get; set; }
        [Column("Valor")]
        public decimal Valor { get; set; }
        [Column("ValorCashBack")]
        public decimal ValorCashBack { get; set; }

    }
}
