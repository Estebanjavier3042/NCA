namespace FerrocarrilNCA.Entidades
{
    public class BaseOperativa
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }

        //foranea Empleado
        
        public List<Empleado> EmpleadoNavegation { get; set; }    
    }
}
