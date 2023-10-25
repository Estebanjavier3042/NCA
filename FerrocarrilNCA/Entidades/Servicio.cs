namespace FerrocarrilNCA.Entidades
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Item { get; set;}

        //foranea Empleado
        
        public List<Empleado> EmpleadoNavegation { get; set; }
        
    }
}
