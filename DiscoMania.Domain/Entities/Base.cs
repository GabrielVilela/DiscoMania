using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiscoMania.Domain.Entities
{
    public class Base<T>
    {
        [Key]
        public int Id { get; set; }
    }
}
