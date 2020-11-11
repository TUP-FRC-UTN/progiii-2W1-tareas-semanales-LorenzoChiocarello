using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class Examenes
    {
        public int idExamen { get; set; }
        public int idMateria { get; set; }
        public string fecha { get; set; }
        public int nota { get; set; }
    }
}