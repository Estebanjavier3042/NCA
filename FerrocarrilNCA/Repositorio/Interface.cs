using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace FerrocarrilNCA.Repositorio
{
    public interface Repositorio<T> where T : class
    {
        Task<ActionResult> Get(int id);
        Task<ActionResult<IEnumerable>>  GetAll();
         Task<ActionResult> Post(T dto);
        Task<ActionResult> Put(T dto,int id);
        Task<ActionResult> Delete(int id);

    }
   
}
