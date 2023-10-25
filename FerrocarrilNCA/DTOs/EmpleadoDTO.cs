using System.ComponentModel.DataAnnotations.Schema;

namespace FerrocarrilNCA.DTOs
{
    public class EmpleadoDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaIngreso { get; set; }
        public int BaseOperativaId { get; set; }
        public int ServicioId { get; set; }
    }
}
