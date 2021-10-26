using System;
using System.ComponentModel.DataAnnotations;

namespace SC.ProyectoAPIV3Core2.Domain.Entities.Entities
{
    public class Credito_dto
    {
        public int CreditoId { get; set; }

        [Required(ErrorMessage = "Campo requirido")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Campo requirido")]
        [StringLength(250, ErrorMessage = "Muchos caracteres")]
        public string Frecuencia { get; set; }

        [Range(1, 12, ErrorMessage = "Valor  no valido")]
        public int Plazo { get; set; }

        [Range(0, 500000000, ErrorMessage = "Valor  no valido")]
        public int Valor_capital { get; set; }
        public int ClienteId { get; set; }




    }
}
