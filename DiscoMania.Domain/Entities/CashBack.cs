using DiscoMania.Helper.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DiscoMania.Domain.Entities
{
    [Table("CashBack")]
    public class CashBack : Base<CashBack>
    {
        [Column("Genero")]
        public EnumGenero Genero { get; set; }
        [Column("Domingo")]
        public int Domingo { get; set; }
        [Column("Segunda")]
        public int Segunda { get; set; }
        [Column("Terca")]
        public int Terca { get; set; }
        [Column("Quarta")]
        public int Quarta { get; set; }
        [Column("Quinta")]
        public int Quinta { get; set; }
        [Column("Sexta")]
        public int Sexta { get; set; }
        [Column("Sabado")]
        public int Sabado { get; set; }
       
    }
}
