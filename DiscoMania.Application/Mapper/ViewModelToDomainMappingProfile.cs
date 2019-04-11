using AutoMapper;
using DiscoMania.Application.ViewModel;
using DiscoMania.Domain.Entities;
using DiscoMania.Domain.Entities.SpotiFyEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.Mapper
{
    public class ViewModelToDomainMappingProfile:Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<DiscoViewModel, Disco>();
            CreateMap<VendaViewModel, Venda>();
            CreateMap<DiscoVendaViewModel, DiscoVenda>();
            CreateMap<SpotifyCredentialsViewModel, SpotifyCredentials>();
            CreateMap<CashBackViewModel, CashBack>();
        }
    }
}
