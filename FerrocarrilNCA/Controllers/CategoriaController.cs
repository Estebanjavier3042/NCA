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
    [Route("api/Categoria")]
    public class CategoriaController : ControllerBase, Repositorio<CategoriaDTO>
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CategoriaController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CategoriaDTO dto)
        {
            var categoria = mapper.Map<Categoria>(dto);
            context.Add(categoria);
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
            var categoria = await context.Categorias.Where(c => c.Id == id).ExecuteDeleteAsync();
            if (categoria==0)
            {
                NotFound();
            }
            return NoContent();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            if (id==0)
            {
                BadRequest();
            }
            var categoria = await context.Categorias.FirstOrDefaultAsync(c=>c.Id==id);
            if (categoria==null)
            {
                NotFound();
            }
            return Ok(categoria);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAll()
        {
            var categorias = await context.Categorias.ToListAsync();
            return Ok(categorias);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(CategoriaDTO dto, int id)
        {
            if (id == 0)
            {
                BadRequest();
            }
            var categoria = await context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
            if (categoria == null)
            {
                NotFound();
            }
            var NuevaCat = mapper.Map<Categoria>(dto);
            categoria.SueldoBasico = NuevaCat.SueldoBasico;
            categoria.Art2000 = NuevaCat.Art2000;
            categoria.Descripcion = NuevaCat.Descripcion;
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
