namespace FerrocarrilNCA.Entidades
{
    public class Sueldo
    {
        public int id { get; set; }
        public int CantServicios { get; set;}
        public int Total { get; set; }

        //foranea empleado
        public int EmpleadoId{ get; set; }
        public Empleado EmpleadoNavegation { get; set; }    
    }
}
