using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SC.ProyectoAPIV3Core2.Domain.Entities.Entities
{
    public class Credito
    {
        public int CreditoId { get; private set; }

        [Required(ErrorMessage = "Campo requirido")]
        public DateTime Fecha { get; private set; }

        [Required(ErrorMessage = "Campo requirido")]
        [StringLength(250, ErrorMessage = "Muchos caracteres")]
        public string Frecuencia { get; private set; }

        [Range(2, 12, ErrorMessage = "Valor  no valido")]
        public int Plazo { get; private set; }

        [Range(0,500000000, ErrorMessage = "Valor  no valido")]
        public int Valor_capital { get; private set; }
        //variables de navegacion
        public int ClienteId { get; private set; }
        //public Cliente Cliente { get; private set; }



        public Credito()
        {
        }
        public Credito(Credito_dto credito_dto)
        {
            this.Fecha = credito_dto.Fecha;
            this.Frecuencia = credito_dto.Frecuencia;
            this.Valor_capital = credito_dto.Valor_capital;
            //this.Cliente = credito_dto.Valor_capital;



        }
       
    }
}
