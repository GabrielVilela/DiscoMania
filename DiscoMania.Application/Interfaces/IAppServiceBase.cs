using Filters;
using Filters.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.Interfaces
{
    public interface IAppServiceBase<TEntityViewModel, TFilter> : IDisposable where TEntityViewModel : class
        where TFilter : FilterBase
    {
        TEntityViewModel Add(TEntityViewModel entityViewModel);
        void AddRange(IEnumerable<TEntityViewModel> entityViewModel);

        void Delete(int id);
        TEntityViewModel FindById(int id);
        IEnumerable<TEntityViewModel> GetAll();
        TEntityViewModel Update(TEntityViewModel entityViewModel);
        ResultFilter<TEntityViewModel> FindByFilter(TFilter filter);

    }
}
