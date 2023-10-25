using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerrocarrilNCA.Entidades
{
    public class Empleado
    {
        [Key]
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaIngreso { get; set; }

        //foraneas
      
        public int BaseOperativaId { get; set; }
        public BaseOperativa BaseOperativaNavegation { get; set; }

        public int ServicioId { get; set; } 
        public Servicio ServicioNavegation { get; set; }
        public Sueldo SueldoNavegation { get; set; }
        public Categoria CategoriaNavegation { get; set; }  
    
    }
}
