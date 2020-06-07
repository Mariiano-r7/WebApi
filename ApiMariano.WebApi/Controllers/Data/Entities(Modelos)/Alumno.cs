using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMariano.WebApi.Controllers.Data.Entities_Modelos_
{
    public class Alumno
    {
        

        public int Id { get; set; }
        [Required]
        public string CodAlumno { get; set; }
        [Required]
        public string NomAlumno { get; set; }

        public List<Docente> Docentes { get; set; }
    }
}
