using System.ComponentModel.DataAnnotations.Schema;

namespace FerrocarrilNCA.Entidades
{
    public class Sueldo
    {
        public int id { get; set; }
        public int CantServicios { get; set; } = 24;
        public decimal Total { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaDeLiquidacion { get; set; }

        //foranea empleado
        public int EmpleadoId{ get; set; }
        public Empleado EmpleadoNavegation { get; set; }    
    }
}
