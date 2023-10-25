using AutoMapper;
using FerrocarrilNCA.DTOs;
using FerrocarrilNCA.Entidades;
using System.Runtime;

namespace FerrocarrilNCA.Utilidades
{
    public class AutoMapperEntidadesDTO:Profile
    {
        public AutoMapperEntidadesDTO()
        {
            CreateMap<BaseOperativaDTO, BaseOperativa>();
            CreateMap<EmpleadoDTO, Empleado>();
            CreateMap<ServicioDTO, Servicio>();
            CreateMap<SueldoDTO, Sueldo>();
            CreateMap<CategoriaDTO, Categoria>();
        }
    }
}
