using System;
using System.Collections.Generic;
using System.Text;

namespace Filters.Result
{
    public class ResultFilter<T>
    {
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<T> Result { get; set; }
    }
}
