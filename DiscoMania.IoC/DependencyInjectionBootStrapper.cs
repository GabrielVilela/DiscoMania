using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DiscoMania.Application.Interfaces;
using DiscoMania.Application.Services;
using DiscoMania.Domain.Interfaces;
using DiscoMania.Domain.Services;
using DiscoMania.Domain.Services.SpotifyServices;
using DiscoMania.Domain.SpotifyInterface.Interfaces;
using DiscoMania.Repository;
using DiscoMania.Repository.Contexts;
using DiscoMania.Repository.Interfaces;
using DiscoMania.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DiscoMania.IoC
{
    public class DependencyInjectionBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            // DB
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Disco
            services.AddScoped<IDiscoRepository, DiscoRepository>();
            services.AddScoped<IDiscoService, DiscoService>();
            services.AddScoped<IDiscoAppService, DiscoAppService>();

            // Venda
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IVendaAppService, VendaAppService>();

            //DiscoVenda
            services.AddScoped<IDiscoVendaRepository, DiscoVendaRepository>();
            services.AddScoped<IDiscoVendaService, DiscoVendaService>();
            services.AddScoped<IDiscoVendaAppService, DiscoVendaAppService>();

            //Spotify
            services.AddScoped<ISpotifyAppService, SpotifyAppService>();
            services.AddScoped<ISpotifyService, SpotifyService>();

            //CashBack
            services.AddScoped<ICashBackAppService, CashBackAppService>();
            services.AddScoped<ICashBackRepository, CashBackRepository>();
            services.AddScoped<ICashBackService, CashBackService>();

        }
    }
}
