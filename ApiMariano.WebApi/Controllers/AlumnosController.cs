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
    public class AlumnosController : ControllerBase
    {
        private readonly ApiContext context;

        public AlumnosController(ApiContext context)
        {
            this.context = context;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Alumno>> Get()
        {

            return context.Alumnos.ToList();

        }

        [HttpGet("{id}", Name = "ObtenerAlumnoPorId")]
        public ActionResult<Alumno> Get(int id)
        {
            var alumno = context.Alumnos.FirstOrDefault(p => p.Id == id);
            if (alumno == null)
            {
                return NotFound();
            }
            return alumno;

        }


        [HttpPost]
        //public ActionResult<Alumno> Post([FromBody] Alumno alumno)
        public async Task<ActionResult<Alumno>> Post([FromBody] Alumno alumno)
        {
            //context.Alumnos.Add(alumno);
            //context.SaveChanges();


            await context.Alumnos.AddAsync(alumno);
            await context.SaveChangesAsync();

            //return alumno;
            return new CreatedAtRouteResult("ObtenerAlumnoPorId", new { id = alumno.Id }, alumno);

        }

        [HttpPut("{id}")]
        public ActionResult<Alumno> Put(int id, [FromBody] Alumno alumno)
        {
            if (id != alumno.Id)
	        {
                return BadRequest();

            }

            context.Entry(alumno).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Alumno> Delete(int id)
        {
            var alumno = context.Alumnos.FirstOrDefault(p => p.Id == id);
            if (alumno == null)
            {
                return NotFound();
            }

            context.Alumnos.Remove(alumno);
            context.SaveChanges();
            return Ok();
        
        }


    }
}
