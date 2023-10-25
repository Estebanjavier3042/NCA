namespace FerrocarrilNCA.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Art2000 { get; set;}
        public int EmpleadoId { get; set; }
        public decimal SueldoBasico { get; set; }
        public Empleado EmpleadoNavegation { get; set; }
    }
}
