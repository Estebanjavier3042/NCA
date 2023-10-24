namespace FerrocarrilNCA.Entidades
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Item { get; set;}

        //foranea Empleado
        public Empleado EmpleadoNavegation { get; set; }
        public int empleadoId { get; set; }
    }
}
