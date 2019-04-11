using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DiscoMania.Domain.Entities
{
    [Table("Venda")]
    public class Venda : Base<Venda>
    {
        [Column("DataVenda")]
        public DateTime DataVenda { get; set; }
        [Column("ValorTotalVenda")]
        public decimal ValorTotalVenda { get; set; }
        [Column("ValorTotalCashBack")]
        public decimal ValorTotalCashBack { get; set; }
        [NotMapped]
        public List<DiscoVenda> DiscosDaVenda { get; set; }

    }
}
