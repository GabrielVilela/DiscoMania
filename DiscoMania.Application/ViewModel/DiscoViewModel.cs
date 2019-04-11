using DiscoMania.Helper.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.ViewModel
{
    public class DiscoViewModel
    {
        public int Id { get; set; }
        public string TituloAlbum { get; set; }
        public string NomeArtista { get; set; }
        public EnumGenero Genero { get; set; }
        public decimal Valor { get; set; }
    }
}
