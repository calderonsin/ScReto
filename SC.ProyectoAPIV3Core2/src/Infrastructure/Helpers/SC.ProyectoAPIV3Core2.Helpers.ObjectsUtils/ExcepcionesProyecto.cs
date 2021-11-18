using System;
using System.Collections.Generic;
using System.Text;

namespace SC.ProyectoAPIV3Core2.Helpers.ObjectsUtils
{
    public class ExcepcionesProyecto:SystemException
    {
        public ExcepcionesProyecto(string message) : base(message)
        { 

        }
    }


    public class ExcepcionProyectoNoEncontrado : ExcepcionesProyecto 
    {
        public ExcepcionProyectoNoEncontrado(string message):base(message)
        {

        }
    }

}
