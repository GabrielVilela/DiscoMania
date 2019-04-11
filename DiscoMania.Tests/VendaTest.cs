using AutoMapper;
using DiscoMania.Application.Interfaces;
using DiscoMania.Application.Mapper;
using DiscoMania.Application.Services;
using DiscoMania.Application.ViewModel;
using DiscoMania.Domain.Entities;
using DiscoMania.Domain.Interfaces;
using DiscoMania.Helper.Enums;
using DiscoMania.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DiscoMania.Tests
{
    [TestClass]
    public class VendaTest
    {
        [TestMethod]
        public void FindVendaCompletaTest()
        {
            var vendaIService = new Mock<IVendaService>();
            var discoVendaIService = new Mock<IDiscoVendaAppService>();
            var cashBackIService = new Mock<ICashBackAppService>();
            var discoIService = new Mock<IDiscoAppService>();
            var uow = new Mock<IUnitOfWork>();
            var mapper = new Mock<IMapper>();
            var discoVenda = new List<DiscoVenda>();
            discoVenda.Add(new DiscoVenda()
            {
                DiscoId = 2,
                Disco = new Disco()
                {
                    Genero = EnumGenero.Rock,
                    Id = 2,
                    NomeArtista = "Linkin Park",
                    TituloAlbum = "Meteora",
                    Valor = (decimal)10.50
                },
                VendaId = 22,
                Id = 2,
                Qtde = 2,
                Valor = (decimal)21.00,
                ValorCashBack = (decimal)2.10
            });
            var venda = new Venda()
            { Id = 33,
              DiscosDaVenda = discoVenda,
              DataVenda = new DateTime(2019,04,08),
              ValorTotalVenda = (decimal) 21,
              ValorTotalCashBack = (decimal)2.1
            };

            var discoVendaViewModel = new List<DiscoVendaViewModel>();
            discoVendaViewModel.Add(new DiscoVendaViewModel()
            {
                DiscoId = 2,
                Disco = new DiscoViewModel()
                {
                    Genero = EnumGenero.Rock,
                    Id = 2,
                    NomeArtista = "Linkin Park",
                    TituloAlbum = "Meteora",
                    Valor = (decimal)10.50
                },
                VendaId = 22,
                Qtde = 2,
                Valor = (decimal)21.00,
                ValorCashBack = (decimal)2.10
            });
            var vendaViewModel = new VendaViewModel()
            {
                Id = 33,
                DiscosDaVenda = discoVendaViewModel,
                DataVenda = new DateTime(2019, 04, 08),
                ValorTotalVenda = (decimal)21,
                ValorTotalCashBack = (decimal)2.1
            };
            mapper.Setup(x => x.Map<VendaViewModel>(venda)).Returns(vendaViewModel);

            vendaIService.Setup(x => x.FindByIdCompleta(33)).Returns(venda);

            var service = new VendaAppService(uow.Object, vendaIService.Object, discoVendaIService.Object,discoIService.Object, cashBackIService.Object, mapper.Object);

            var retorno = service.FindByIdCompleta(33);

            
            Assert.AreEqual(retorno, vendaViewModel);
        }
    }
}
