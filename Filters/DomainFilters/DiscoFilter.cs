using System;
using System.Collections.Generic;
using System.Text;

namespace Filters.DomainFilters
{
    public class DiscoFilter : FilterBase
    {
        public string TituloAlbum { get; set; }
        public string NomeArtista { get; set; }
        public int? Genero { get; set; }
    }
}
