using Microsoft.EntityFrameworkCore;
using Moq;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using SC.ProyectoAPIV3Core2.DrivenAdapters.Sql.Entities;
using SC.ProyectoAPIV3Core2.Helpers.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SC.ProyectoAPIV3Core2.DrivenAdapters.Sql.Tests
{

    public class ClienteAdaptorTest
    {
        private readonly ScDbContexto scdbcontext;
        private readonly ClienteAdaptador clienteadapter;
        private readonly Mock<IClienteRepositorio<Cliente>> mockClienteRepository;
        private readonly DbContextHelper dbcontexthelper;

        public  ClienteAdaptorTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ScDbContexto>().UseInMemoryDatabase("ScReto")
                .Options;
            scdbcontext = new ScDbContexto(optionBuilder);
            clienteadapter = new ClienteAdaptador(scdbcontext);
            mockClienteRepository = new Mock<IClienteRepositorio<Cliente>>();
            dbcontexthelper = new DbContextHelper();
        }


        // 
        [Fact]
        public async Task ShouldAddClienteAdapterOk()
        {
            
            //arrange
            ClienteDtoHelper clientedtohelper = new ClienteDtoHelper();
            Cliente cliente = new Cliente(clientedtohelper.ClienteDto());
            //mockClienteRepository.Setup(c => c.Añadir(cliente)).ReturnsAsync(cliente);
            scdbcontext.Add(cliente);

            //act
            Cliente resp = await clienteadapter.Añadir(cliente);

            //Assert
            Assert.NotNull(resp);
            Assert.Equal(cliente, resp);
        }


        [Fact]
        public async Task ShouldFindAllOk()
        {
            //arrange
            List<Cliente> list_cliente = await scdbcontext.Clientes.Include(s => s.Creditos).ToListAsync();

            //act
            List<Cliente> resp = await (clienteadapter.MostrarTodo());

            //asert
            Assert.NotNull(resp);
            Assert.Equal(list_cliente, resp);
        }

        [Theory]
        [InlineData(1)]
        public async Task ShouldFindbyID(int clienteId)
        {
            //arrange
            Cliente cliente_encontrado = await scdbcontext.Clientes.Include(s => s.Creditos).FirstOrDefaultAsync(i => i.Id == clienteId);

            //act
            Cliente resp = await (clienteadapter.EncontrarPorId(clienteId));

            //asert
            Assert.IsType<Cliente>(resp);
            Assert.NotNull(resp);
            Assert.Equal(cliente_encontrado, resp);
        }

        [Theory]
        [InlineData(2)]
        public async Task ShouldFindbyIDGetNull(int clienteId)
        {
            //arrange           
            Cliente cliente_encontrado = await scdbcontext.Clientes.Include(s => s.Creditos).FirstOrDefaultAsync(i => i.Id == clienteId);

            //act
            Cliente resp = await (clienteadapter.EncontrarPorId(clienteId));

            //asert
            Assert.Null(resp);
            Assert.Equal(cliente_encontrado, resp);
        }

        [Theory]
        [InlineData(1)]
        public async Task ShouldUpdateClientOk(int clienteid)
        {
            //arrange
            Cliente cliente =await scdbcontext.Clientes.FindAsync(clienteid);
            cliente.Apellido = "APellidoModificado";
            scdbcontext.Entry(cliente).State = EntityState.Modified;
            int CantModiContexto = await scdbcontext.SaveChangesAsync();

            //act
            int resp = await clienteadapter.Actualizar(cliente);

            //assert
            Assert.Equal(resp, CantModiContexto);

        }

        [Theory]
        [InlineData(1)]
        public async Task ShouldDeleteClientOk(int clienteId)
        {
            //arrange
            var cliente = await scdbcontext.Clientes.FindAsync(clienteId);

            //act
            await (clienteadapter.Borrar(clienteId));

            //asert

            /*Assert.IsType<Cliente>(resp);
            Assert.NotNull(resp);
            Assert.Equal(cliente_encontrado, resp);*/

        }
    }
}
