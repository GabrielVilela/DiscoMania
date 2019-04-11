using AutoMapper;
using DiscoMania.Application.Interfaces;
using DiscoMania.Application.Mapper;
using DiscoMania.Application.Services;
using DiscoMania.Application.ViewModel;
using DiscoMania.Domain.Interfaces;
using DiscoMania.Helper.Enums;
using DiscoMania.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace DiscoMania.Tests
{
    [TestClass]
    public class CashBackTest
    {
        [TestMethod]
        public void CashBackRetornaPorGenero()
        {
            var cashBackIService = new Mock<ICashBackService>();
            var uow = new Mock<IUnitOfWork>();
            var mapper = new Mock<IMapper>();
            var cashBack = new Domain.Entities.CashBack() { Id = 3, Genero = EnumGenero.Rock, Domingo = 40, Segunda = 10, Terca = 15, Quarta = 15, Quinta = 15, Sexta = 20, Sabado = 40 };
            var cashBackViewModel = new CashBackViewModel() { Id = 3, Genero = EnumGenero.Rock, Domingo = 40, Segunda = 10, Terca = 15, Quarta = 15, Quinta = 15, Sexta = 20, Sabado = 40 };
            cashBackIService.Setup(x => x.RetornaPorGenero(EnumGenero.Rock)).Returns(cashBack);
            mapper.Setup(x => x.Map<CashBackViewModel>(cashBack)).Returns(cashBackViewModel);

            ICashBackAppService service = new CashBackAppService(uow.Object, cashBackIService.Object, mapper.Object);
            var retorno = service.RetornaPorGenero(EnumGenero.Rock);
            Assert.AreEqual(retorno, cashBackViewModel);
        }
        [TestMethod]
        public void CashBackCalcula()
        {

            var cashBackIService = new Mock<ICashBackService>();
            var uow = new Mock<IUnitOfWork>();
            var mapper = new Mock<IMapper>();
            var cashBack = new Domain.Entities.CashBack() { Id = 3, Genero = EnumGenero.Rock, Domingo = 40, Segunda = 10, Terca = 15, Quarta = 15, Quinta = 15, Sexta = 20, Sabado = 40 };
            var cashBackViewModel = new CashBackViewModel() { Id = 3, Genero = EnumGenero.Rock, Domingo = 40, Segunda = 10, Terca = 15, Quarta = 15, Quinta = 15, Sexta = 20, Sabado = 40 };
            cashBackIService.Setup(x => x.RetornaPorGenero(EnumGenero.Rock)).Returns(cashBack);
            mapper.Setup(x => x.Map<CashBackViewModel>(cashBack)).Returns(cashBackViewModel);
            
            ICashBackAppService service = new CashBackAppService(uow.Object, cashBackIService.Object, mapper.Object);
            
            var percent = service.CalculaPercentCashBack(new DateTime(2019, 04, 11), EnumGenero.Rock);
            Assert.AreEqual(percent, (decimal)0.15);

        }
    }
}
