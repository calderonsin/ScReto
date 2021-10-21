using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.DrivenAdapters.Sql.Entities;
using SC.ProyectoAPIV3Core2.Helpers.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SC.ProyectoAPIV3Core2.DrivenAdapters.Sql.Tests
{

    public class ClienteAdapterTest
    {
        private  readonly ScDbContext scdbcontext;
        private readonly ClienteAdapter clienteadapter;

        public ClienteAdapterTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<ScDbContext>().UseInMemoryDatabase("ScReto")
                .Options;
            scdbcontext = new ScDbContext(optionBuilder);
            clienteadapter  = new ClienteAdapter(scdbcontext);
            
        }


        // 
        [Fact]
        public async Task ShouldAddClienteAdapterOk()
        {
            //arrange
            ClienteDtoHelper clientedtohelper = new ClienteDtoHelper();
            Cliente cliente = new Cliente(clientedtohelper.ClienteDto());
            Cliente cliente_creado =  scdbcontext.Add(cliente).Entity;
            //await scdbcontext.SaveChangesAsync();

            //act
            Cliente resp = await clienteadapter.Add(cliente);

            //assert
            Assert.NotNull(resp);
            Assert.Equal(cliente_creado, resp);
        }


        [Fact]
        public async Task ShouldFindAllOk()
        {
            //arrange
            List<Cliente> list_cliente =  await scdbcontext.Clientes.Include(s => s.Creditos).ToListAsync();

            //act
            List<Cliente> resp = await (clienteadapter.FindAll());

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
            Cliente resp = await (clienteadapter.FindById(clienteId));

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
            Cliente resp = await (clienteadapter.FindById(clienteId));

            //asert
            Assert.Null(resp);
            Assert.Equal(cliente_encontrado, resp);
        }

        [Fact]        
        public async Task ShouldUpdateClientOk()
        {
            //arrange
            ClienteDtoHelper clientedtohelper = new ClienteDtoHelper();
            Cliente cliente = new Cliente(clientedtohelper.ClienteDto());
            Cliente cliente_creado = scdbcontext.Add(cliente).Entity;
            await scdbcontext.SaveChangesAsync();
            cliente_creado.Apellido = "APellidoModificado";
            scdbcontext.Entry(cliente_creado).State = EntityState.Modified;
            int CantModiContexto= await scdbcontext.SaveChangesAsync();

            //act
            int resp = await clienteadapter.Update(cliente);

            //assert
            Assert.Equal<int>(resp ,CantModiContexto );

        }
    }
}
