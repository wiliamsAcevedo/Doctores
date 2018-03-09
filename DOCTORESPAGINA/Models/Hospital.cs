using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOCTORESPAGINA.Models
{
    public class Hospital
    {
        public int HospitalID { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Nombre del Hospital")]
        public string NombreHosp { get; set; }

        [Required]
        public DateTime FechaCreacionHos { get; set; }

        [Required]
        [Display(Name = "Estado activo o inactivo")]
        public int EstadoHosp { get; set; }

        public virtual ICollection<Doctores> Doctor { get; set; }

        public Hospital()
        {
            FechaCreacionHos = DateTime.Now;
        }
    }
}