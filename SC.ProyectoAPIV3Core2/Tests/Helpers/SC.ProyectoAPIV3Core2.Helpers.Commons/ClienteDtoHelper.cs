using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;

namespace SC.ProyectoAPIV3Core2.Helpers.Commons
{
    public class ClienteDtoHelper
    {
        public int Id;
        public string nombre;
        public string apellido;
        public string correo;
        public string direccion;
        public string ciudad;
        public string departamento;
        //Cliente_dto cliente_dto = new Cliente_dto();

        public Cliente_dto ClienteDto()
        {
            Id = 0;
            nombre = "pepito";
            apellido = "apellido";
            correo = "jucc@gmail.com";
            direccion = "cra";
            ciudad = "Medellin";
            departamento = "Armenia";
            return new Cliente_dto(Id, nombre, apellido, correo, direccion, ciudad, departamento);


        }
    }

}
