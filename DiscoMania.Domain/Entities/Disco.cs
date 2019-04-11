using DiscoMania.Helper.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DiscoMania.Domain.Entities
{
    [Table("Disco")]
    public class Disco : Base<Disco>
    {
        [Column("TituloAlbum")]
        public string TituloAlbum { get; set; }
        [Column("NomeArtista")]
        public string NomeArtista { get; set; }
        [Column("Genero")]
        public EnumGenero Genero { get; set; }
        [Column("Valor")]
        public decimal Valor { get; set; }
    }
}
