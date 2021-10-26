using System.ComponentModel.DataAnnotations;

namespace SC.ProyectoAPIV3Core2.Domain.Entities.Entities
{
    public class Cliente_dto
    {
        public Cliente_dto(int Id, string nombre, string apellido, string correo, string direccion, string municipio, string departamento)
        {
            this.Id = Id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Correo = correo;
            this.Direccion = direccion;
            this.Municipio = municipio;
            this.Departamento = departamento;
        }
        public Cliente_dto() { }
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requirido")]
        [StringLength(250, ErrorMessage = "Muchos caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo requirido")]
        [StringLength(250, ErrorMessage = "Muchos caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo requirido")]
        [StringLength(250, ErrorMessage = "Muchos caracteres")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Campo requirido")]
        [StringLength(250, ErrorMessage = "Muchos caracteres")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Campo requirido")]
        [StringLength(250, ErrorMessage = "Muchos caracteres")]
        public string Municipio { get; set; }
        [Required(ErrorMessage = "Campo requirido")]
        [StringLength(250, ErrorMessage = "Muchos caracteres")]
        public string Departamento { get; set; }
    }

}
