using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoMania.Application.Mapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddProfile(new DomainToViewModelMappingProfile());
                ps.AddProfile(new ViewModelToDomainMappingProfile());
                ps.AddProfile(new ViewModelToViewModelMappingProfile());
            });
        }
    }
}
