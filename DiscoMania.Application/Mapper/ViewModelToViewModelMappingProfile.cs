using AutoMapper;
using DiscoMania.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.Mapper
{
    public class ViewModelToViewModelMappingProfile : Profile
    {
        public ViewModelToViewModelMappingProfile()
        {
            CreateMap<VendaViewModel, VendaMinViewModel>();
            CreateMap<VendaMinViewModel,VendaViewModel>();

            CreateMap<VendaViewModel, VendaCompletaMinViewModel>();
            CreateMap<VendaCompletaMinViewModel, VendaViewModel>();

            CreateMap<DiscoVendaViewModel, DiscoVendaMinViewModel>();
            CreateMap<DiscoVendaMinViewModel, DiscoVendaViewModel>();

            CreateMap<DiscoVendaViewModel, DiscoVendaCompletaMinViewModel>();
            CreateMap<DiscoVendaCompletaMinViewModel, DiscoVendaViewModel>();
        }
    }
}
