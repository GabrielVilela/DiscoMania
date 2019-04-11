using AutoMapper;
using DiscoMania.Application.Interfaces;
using DiscoMania.Domain.Entities;
using DiscoMania.Domain.Interfaces;
using Filters;
using Filters.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.Services
{
    public abstract class AppServiceBase<TEntity, TEntityViewModel, TFilter> : IAppServiceBase<TEntityViewModel, TFilter> where TEntity : Base<TEntity>
        where TEntityViewModel : class
        where TFilter : FilterBase
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IServiceBase<TEntity, TFilter> _service;
        protected readonly IMapper _mapper;/// <summary>
                                           /// ///
                                           /// </summary>
                                           /// <param name="uow"></param>
                                           /// <param name="service"></param>
                                           /// <param name="mapper"></param>

        protected AppServiceBase(IUnitOfWork uow, IServiceBase<TEntity, TFilter> service, IMapper mapper)
        {
            _uow = uow;
            _service = service;
            _mapper = mapper;
        }

        public virtual TEntityViewModel Add(TEntityViewModel entityViewModel)
        {
            var entity = _service.Add(_mapper.Map<TEntity>(entityViewModel));

            Commit();

            return _mapper.Map<TEntityViewModel>(entity);
        }

        public void AddRange(IEnumerable<TEntityViewModel> entityViewModel)
        {
            _service.AddRange(_mapper.Map<List<TEntity>>(entityViewModel));
            Commit();
        }

        public virtual TEntityViewModel FindById(int id)
        {
            return _mapper.Map<TEntityViewModel>(_service.FindById(id));
        }

        public virtual IEnumerable<TEntityViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<TEntityViewModel>>(_service.GetAll());
        }

        public virtual TEntityViewModel Update(TEntityViewModel entityViewModel)
        {
            var entity = _service.Update(_mapper.Map<TEntity>(entityViewModel));

            Commit();

            return _mapper.Map<TEntityViewModel>(entity);
        }

        public virtual void Delete(int id)
        {
            _service.Delete(id);
            Commit();
        }

        protected void Commit()
        {
            _uow.Commit();
        }

        public virtual void Dispose()
        {
            _service.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual ResultFilter<TEntityViewModel> FindByFilter(TFilter filter)
        {
            var result = _service.FindByFilter(filter);
            return new ResultFilter<TEntityViewModel>()
            {
                Page = result.Page,
                PageCount = result.PageCount,
                PageSize = result.PageSize,
                TotalCount = result.TotalCount,
                Result = _mapper.Map<List<TEntityViewModel>>(result)
            };
        }
    }
}
