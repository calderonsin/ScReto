using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SC.ProyectoAPIV3Core2.Domain.Entities.Entities
{
    public class Cliente
    {


        public Cliente(Cliente_dto cliente)
        {
            this.Id = Id;
            this.Nombre = cliente.Nombre;
            this.Apellido = cliente.Apellido;
            this.Correo = cliente.Correo;
            this.Direccion = cliente.Direccion;
            this.Municipio = cliente.Municipio;
            this.Departamento = cliente.Departamento;
            this.Cupo = 2000000;
            //this.Creditos = cliente.Creditos;

        }

        public Cliente()
        {
            this.Cupo = 2000000;
        }

        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        [Required(ErrorMessage = "Campo requirido")]
        [StringLength(250, ErrorMessage = "Muchos caracteres")]
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido
        /// </summary>

        [Required(ErrorMessage = "Campo requirido")]
        [StringLength(250, ErrorMessage = "Muchos caracteres")]
        public string Apellido { get; set; }

        /// <summary>
        /// Correo
        /// </summary>
        [Required(ErrorMessage = "Campo requirido")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electronico valido")]
        public string Correo { get; set; }

        /// <summary>
        /// Direccion
        /// </summary>
        [Required(ErrorMessage = "Campo requirido")]
        public string Direccion { get; set; }

        /// <summary>
        /// Municipio
        /// </summary>
        [Required(ErrorMessage = "Campo requirido")]
        [StringLength(250, ErrorMessage = "Muchos caracteres")]
        public string Municipio { get; set; }

        /// <summary>
        /// Departamento
        /// </summary>
        [Required(ErrorMessage = "Campo requirido")]
        [StringLength(250, ErrorMessage = "Muchos caracteres")]
        public string Departamento { get; set; }

        /// <summary>
        /// Cupo
        /// </summary>
        public int Cupo { get; set; }
        public List<Credito> Creditos { get; set; }







    }
}
