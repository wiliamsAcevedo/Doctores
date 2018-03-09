using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOCTORESPAGINA.Models
{
    public class Especialidad
    {
        public int EspecialidadID { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Nombre de la Especialidad")]
        public string NombreEsp { get; set; }

        [Required]
        [Display(Name = "Fecha de la creacion de la Especialidad")]
        public DateTime FechaCreacionEsp { get; set; }

        [Required]
        [Display(Name = "Estado activo o inactivo")]
        public int EstadoEsp { get; set; }

        public virtual ICollection<Doctores> Doctores { get; set; }

        public Especialidad()
        {
            FechaCreacionEsp = DateTime.Now;
        }
    }
}