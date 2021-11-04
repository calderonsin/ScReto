using Microsoft.EntityFrameworkCore;
using Moq;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using SC.ProyectoAPIV3Core2.DrivenAdapters.Sql;
using SC.ProyectoAPIV3Core2.DrivenAdapters.Sql.Entities;
using SC.ProyectoAPIV3Core2.Helpers.Commons;
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
        private readonly DbContextHelper dbcontexthelper;

        public GestionarClienteCasosUsosTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ScDbContexto>().UseInMemoryDatabase("ScReto")
                .Options;
            scdbcontext = new ScDbContexto(optionBuilder);
            clienteadapter = new ClienteAdaptador(scdbcontext);
            mockClienteRepository = new Mock<IClienteRepositorio<Cliente>>();
            dbcontexthelper = new DbContextHelper();
        }

        [Fact]
        public async Task ShouldAñadirOk()
        {
            //Arrange
            ClienteDtoHelper clientedtohelper = new ClienteDtoHelper();
            Cliente cliente = new Cliente(clientedtohelper.ClienteDto());
            mockClienteRepository.Setup(i => i.Añadir(It.IsAny<Cliente>())).ReturnsAsync(cliente);
            //Act
            Cliente resp = await clienteadapter.Añadir(cliente);
            //Assert
            Assert.NotNull(resp);
            Assert.Equal(cliente, resp);

        }
        [Fact]
        public async Task ShouldAñadirReturnNull() 
        {
            //Arrange
            Cliente cliente = new Cliente();
            mockClienteRepository.Setup(i => i.Añadir(It.IsAny<Cliente>())).ReturnsAsync(cliente);
            //Act
            Cliente resp = await clienteadapter.Añadir(cliente);
            //Assert
            //Assert.Null(resp);
            Assert.Equal(cliente, resp);

        }
        [Fact]
        public async Task ShouldEncontrarTodoOk() 
        {
            //Arrange
            ClienteDtoHelper clientedtohelper = new ClienteDtoHelper();
            List<Cliente> listaclientes = await scdbcontext.Clientes.ToListAsync();

            mockClienteRepository.Setup(i => i.MostrarTodo()).ReturnsAsync(listaclientes);
            //Act
            List<Cliente> resp = await clienteadapter.MostrarTodo();
            //Assert
            Assert.NotNull(resp);
            Assert.Equal(listaclientes, resp);
        }

    }



}

