using AutoMapper;
using FerrocarrilNCA.DTOs;
using FerrocarrilNCA.Entidades;
using FerrocarrilNCA.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace FerrocarrilNCA.Controllers
{
    [ApiController]
    [Route("api/Sueldo")]
    public class SueldoController : ControllerBase, Repositorio<SueldoDTO>
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public SueldoController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Post(SueldoDTO dto)
        {
            var sueldo = mapper.Map<Sueldo>(dto);
            int legajo = sueldo.EmpleadoId;
            var servicioId = await context.Empleados.FirstOrDefaultAsync(e => e.Legajo == legajo);
            if (servicioId == null) { BadRequest(); }
            else
            {
                int serId = servicioId.ServicioId;

                var servicio = await context.Servicios.Where(s => s.Id == serId).FirstOrDefaultAsync();
                decimal item = servicio.Item;
                var basico = await context.Categorias.FirstOrDefaultAsync(c => c.EmpleadoId == legajo);
                sueldo.Total = basico.SueldoBasico + (sueldo.CantServicios * servicio.Item);

            }
           
            context.Add(sueldo);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id==0)
            {
                return BadRequest();
            }
            var sueldo= await context.Sueldos.Where(s=>s.id==id).ExecuteDeleteAsync();
            if (sueldo is 0)
            {
                return NotFound();
            }
                return NoContent();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
           
            var Nuevo = await context.Sueldos.Select(n => new
            {
                BoletaId=n.id,
                Legajo = n.EmpleadoId,
                FechaLiquidada=n.FechaDeLiquidacion.ToString("dd/MM/yyyy"),
                Empleado=n.EmpleadoNavegation.Nombre+" "+n.EmpleadoNavegation.Apellido,
                Base = n.EmpleadoNavegation.BaseOperativaNavegation.Descripcion,
                Categoria = n.EmpleadoNavegation.CategoriaNavegation.Descripcion,
                Servicio = n.EmpleadoNavegation.ServicioNavegation.Descripcion,
                Basico = n.EmpleadoNavegation.CategoriaNavegation.SueldoBasico,
                Item = n.EmpleadoNavegation.ServicioNavegation.Item,
                CantidadServicios = n.CantServicios,
                RemuneracionTotal = n.Total,
            }).FirstOrDefaultAsync(p => p.BoletaId == id);
            return Ok(Nuevo);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAll()
        {
            var Nuevo = await context.Sueldos.Select(n => new
            {
                BoletaId = n.id,
                Legajo = n.EmpleadoId,
                FechaLiquidada = n.FechaDeLiquidacion.ToString("dd/MM/yyyy"),
                Empleado = n.EmpleadoNavegation.Nombre + " " + n.EmpleadoNavegation.Apellido,
                Base = n.EmpleadoNavegation.BaseOperativaNavegation.Descripcion,
                Categoria = n.EmpleadoNavegation.CategoriaNavegation.Descripcion,
                Servicio = n.EmpleadoNavegation.ServicioNavegation.Descripcion,
                Basico = n.EmpleadoNavegation.CategoriaNavegation.SueldoBasico,
                Item = n.EmpleadoNavegation.ServicioNavegation.Item,
                CantidadServicios = n.CantServicios,
                RemuneracionTotal = n.Total,
            }).ToListAsync();
            return Ok(Nuevo);
        }


        [HttpPut]
        public async Task<ActionResult> Put(SueldoDTO dto, int id)
        {
            if (id is 0)
            {
                BadRequest();
            }
            var sueldo = await context.Sueldos.FirstOrDefaultAsync(s => s.id == id);
            if (sueldo==null)
            {
                NotFound();
            }
            var sueldoNuevo= mapper.Map<Sueldo>(dto);
            int legajo = sueldo.EmpleadoId;
            var servicioId = await context.Empleados.FirstOrDefaultAsync(e => e.Legajo == legajo);
            if (servicioId == null) { BadRequest(); }
            else
            {
                int serId = servicioId.ServicioId;

                var servicio = await context.Servicios.Where(s => s.Id == serId).FirstOrDefaultAsync();
                decimal item = servicio.Item;
                var basico = await context.Categorias.FirstOrDefaultAsync(c => c.EmpleadoId == legajo);
                sueldoNuevo.Total = basico.SueldoBasico + (sueldoNuevo.CantServicios * servicio.Item);

            }
            sueldo.CantServicios = sueldoNuevo.CantServicios;
            sueldo.Total = sueldoNuevo.Total;
            
            await context.SaveChangesAsync();
            return NoContent();



            
        }
    }
}
