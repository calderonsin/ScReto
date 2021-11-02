using Microsoft.EntityFrameworkCore;
using Moq;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using SC.ProyectoAPIV3Core2.DrivenAdapters.Sql;
using SC.ProyectoAPIV3Core2.DrivenAdapters.Sql.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
namespace SC.ProyectoAPIV3Core2.Domain.UseCase.Tests
{

    public class GestionarClienteCasosUsosTest
    {

        private readonly ScDbContexto scdbcontext;
        private readonly ClienteAdaptador clienteadapter;
        private readonly Mock<IClienteRepositorio<Cliente>> mockClienteRepository;

        public GestionarClienteCasosUsosTest()
        {
            clienteadapter = new ClienteAdaptador(scdbcontext);
            mockClienteRepository = new Mock<IClienteRepositorio<Cliente>>();
        }

        [Fact]
        public async Task ShouldAñadirOk()
        {
            //Arrange
            //se le debe asginar un cliente preestablecido, usar un helper
            Cliente cliente = new Cliente();
            mockClienteRepository.Setup(i => i.Añadir(It.IsAny<Cliente>())).ReturnsAsync(cliente);
            //Act
            Cliente resp = await clienteadapter.Añadir(new Cliente());
            //Assert
            Assert.NotNull(resp);
            Assert.Equal(cliente, resp);

        }
    }



}

