using ApiMariano.WebApi.Controllers.Data;
using ApiMariano.WebApi.Controllers.Data.Entities_Modelos_;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMariano.WebApi.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]

    public class DocentesController : ControllerBase 
    {
        private readonly ApiContext context;

        public DocentesController(ApiContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Docente>> Get()
        {
            return context.Docentes.Include(p => p.Alumno).ToList();
       
        }


        [HttpGet("{id}", Name = "ObtenerDocentePorId")]
        public ActionResult<Docente> Get(int id)
        {
            var docente = context.Docentes.FirstOrDefault(p => p.Id == id);
            if (docente == null)
            {
                return NotFound();
            }

            return docente;
        }

        [HttpPost]
        public ActionResult<Docente> Post([FromBody] Docente docente)
        {
            context.Docentes.Add(docente);
            context.SaveChanges();
            return new CreatedAtRouteResult("ProvById", new { id = docente.Id }, docente);
        
        }


    }
}
