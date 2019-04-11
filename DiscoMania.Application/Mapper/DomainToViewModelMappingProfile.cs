using AutoMapper;
using DiscoMania.Application.ViewModel;
using DiscoMania.Domain.Entities;
using DiscoMania.Domain.Entities.SpotiFyEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.Mapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Disco, DiscoViewModel>();
            CreateMap<Venda, VendaViewModel>();
            CreateMap<DiscoVenda, DiscoVendaViewModel>();
            CreateMap<SpotifyCredentials, SpotifyCredentialsViewModel>();
            CreateMap<CashBack, CashBackViewModel>();
        }
    }
}
