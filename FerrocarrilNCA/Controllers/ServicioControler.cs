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
    [Route("api/Servicio")]
    public class ServicioControler : ControllerBase, Repositorio<ServicioDTO>
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ServicioControler(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Post(ServicioDTO dto)
        {
            var servicio = mapper.Map<Servicio>(dto);
            context.Add(servicio);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                BadRequest();
            }
            var servicio = await context.Servicios.Where(s => s.Id == id).ExecuteDeleteAsync();
            if (servicio==0)
            {
                NotFound();
            }
            return NoContent();
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            if (id==0)
            {
                BadRequest();
            }
            var servicio = await context.Servicios.FirstOrDefaultAsync(s=>s.Id==id);
            if (servicio==null)
            {
                NotFound();
            }
            return Ok(servicio);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAll()
        {
            var servicios = await context.Servicios.ToListAsync();
            return Ok(servicios);
        }


        [HttpPut]
        public async Task<ActionResult> Put(ServicioDTO dto, int id)
        {
            if (id == 0)
            {
                BadRequest();
            }
            var servicio = await context.Servicios.FirstOrDefaultAsync(s => s.Id == id);
            if (servicio == null)
            {
                NotFound();
            }
            var Nuevoser = mapper.Map<Servicio>(dto);
            servicio.Descripcion = Nuevoser.Descripcion;
            servicio.Item = Nuevoser.Item;
            await context.SaveChangesAsync();
            return NoContent();

        }
    }
}
