using AutoMapper;
using FerrocarrilNCA.DTOs;
using FerrocarrilNCA.Entidades;
using FerrocarrilNCA.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace FerrocarrilNCA.Controllers
{
    [ApiController]
    [Route("api/Empleado")]

    public class EmpleadoController : ControllerBase, Repositorio<EmpleadoDTO>
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public EmpleadoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Post(EmpleadoDTO dto)
        {
           var empleado=mapper.Map<Empleado>(dto);
            context.Add(empleado);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{legajo:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id==0)
            {
                BadRequest();
            }
            var empleado = await context.Empleados.Where(e => e.Legajo == id).ExecuteDeleteAsync();
            if (empleado==0)
            {
                NotFound();
            }
            return NoContent();
        }
        [HttpGet("{Legajo:int}")]
        public async Task<ActionResult> Get(int Legajo)
        {
            var empleado = await context.Empleados.Select(e => new
            {
                Legajo=e.Legajo,
                Nombre=e.Nombre,
                Apellido=e.Apellido,
                Base=e.BaseOperativaNavegation.Descripcion,
                Categoria=e.CategoriaNavegation.Descripcion,
                SueldoBasico=e.CategoriaNavegation.SueldoBasico,
                Art2000=e.CategoriaNavegation.Art2000,
                Servicio=e.ServicioNavegation.Descripcion,
                Item=e.ServicioNavegation.Item,
                FechaDeIngreso=e.FechaIngreso.ToString("dd/MM/yyyy"),
            }).FirstOrDefaultAsync(e=>e.Legajo==Legajo);
            return Ok(empleado);

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAll()
        {
            var empleados= await context.Empleados.Select(e => new
            {
                Legajo = e.Legajo,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Base = e.BaseOperativaNavegation.Descripcion,
                Categoria = e.CategoriaNavegation.Descripcion,
                SueldoBasico = e.CategoriaNavegation.SueldoBasico,
                Art2000 = e.CategoriaNavegation.Art2000,
                Servicio = e.ServicioNavegation.Descripcion,
                Item = e.ServicioNavegation.Item,
                FechaDeIngreso = e.FechaIngreso.ToString("dd/MM/yyyy"),
            }).ToListAsync();
            return Ok(empleados);
        }


        [HttpPut("{Legajo:int}")]
        public async Task<ActionResult> Put(EmpleadoDTO dto, int Legajo)
        {
            if (Legajo==0)
            {
                BadRequest();
            }
            var empleado = await context.Empleados.FirstOrDefaultAsync(e=>e.Legajo==Legajo);
            if (empleado==null)
            {
                NotFound();
            }
            var nuevoempleado=mapper.Map<Empleado>(dto);
            empleado.Nombre = nuevoempleado.Nombre;
            empleado.Apellido = nuevoempleado.Apellido;
            empleado.FechaIngreso = nuevoempleado.FechaIngreso;
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
