using CP3.Application.Dtos;
using CP3.Application.Services;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces;
using CP3.Domain.Interfaces.Dtos;
using Moq;

namespace CP3.Tests
{
    public class BarcoApplicationServiceTests
    {
        private readonly Mock<IBarcoRepository> _repositoryMock;
        private readonly BarcoApplicationService _BarcoService;

        public BarcoApplicationServiceTests()
        {
            _repositoryMock = new Mock<IBarcoRepository>();
            _BarcoService = new BarcoApplicationService(_repositoryMock.Object);
        }

        public void AdicionarBarco_DeveAdicionarBarco()
        {
            var barcoDto = new BarcoDto { Nome = "Barco 1", Modelo = "Modelo A", Ano = 2020, Tamanho = 30.5 };
            _BarcoService.AdicionarBarco(barcoDto);

            _repositoryMock.Verify(r => r.Add(It.IsAny<BarcoEntity>()), Times.Once);
        }

    }
}
