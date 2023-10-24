using System.ComponentModel.DataAnnotations;

namespace FerrocarrilNCA.Entidades
{
    public class Empleado
    {
        [Key]
        public int Legajo { get; set; }
        public int Nombre { get; set; }
        public int Apellido { get; set; }
        public DateTime FechaIngreso { get; set; }

        //foraneas
        public Servicio ServicioNavegation { get; set; }
        public BaseOperativa BaseOperativaNavegation { get; set; }  
        public Sueldo SueldoNavegation { get; set; }
    
    }
}
