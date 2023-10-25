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
    [Route("api/BaseOperativa")]
    public class BaseOperativaController : ControllerBase, Repositorio<BaseOperativaDTO>
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public BaseOperativaController(ApplicationDbContext Context,IMapper mapper)
        {
            context = Context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(BaseOperativaDTO dto)
        {
            var baseOperativa=mapper.Map<BaseOperativa>(dto);
            context.Add(baseOperativa);
            await context.SaveChangesAsync();
            return Ok();

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            if (id==0)
            {
                BadRequest();
            }
            var baseop = await context.BaseOperativas.FirstOrDefaultAsync(b=>b.Id==id);
            if (baseop==null)
            {
                NotFound();
            }
            return Ok(baseop);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAll()
        {
            var bases = await context.BaseOperativas.ToListAsync();
            return Ok(bases);
        }
        [HttpPut]
        public async Task<ActionResult> Put(BaseOperativaDTO dto, int id)
        {
            if (id == 0)
            {
                BadRequest();
            }
            var baseop = await context.BaseOperativas.FirstOrDefaultAsync(b => b.Id == id);
            if (baseop == null)
            {
                NotFound();
            }
            var basenu = mapper.Map<BaseOperativa>(dto);
            baseop.Descripcion=basenu.Descripcion;
            baseop.Ubicacion = basenu.Ubicacion;
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                BadRequest();
            }
            var baseop = await context.BaseOperativas.Where(b => b.Id == id).ExecuteDeleteAsync();
            if (baseop == 0)
            {
                NotFound();
            }
            return NoContent();

        }
    }
}
