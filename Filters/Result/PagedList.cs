using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filters.Result
{
    public class PagedList<T> : List<T>
    {
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }

        public PagedList(IQueryable<T> source, int page, int pageSize)
        {
            TotalCount = source.Count();
            Page = page < 1 ? 1 : page;
            var normalizedPage = Page - 1;
            PageSize = pageSize;
            PageCount = GetPageCount(PageSize, TotalCount);
            AddRange(source.Skip(normalizedPage * PageSize).Take(PageSize).ToList());
        }

        private int GetPageCount(int pageSize, int totalCount)
        {
            if (pageSize == 0)
                return 0;

            var remainder = totalCount % pageSize;
            return (totalCount / pageSize) + (remainder == 0 ? 0 : 1);
        }
    }
}
