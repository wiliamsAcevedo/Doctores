using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOCTORESPAGINA.Models
{
    public class Doctores
    {
        public int DoctoresID { get; set; }

        [Required]
        public int EspecialidadID { get; set; }

        [Required]
        [Display(Name = "Hospital")]
        public int HospitalID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre del Doctor")]
        public string NombreDoc { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripcion del doctor")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Estado activo o inactivo")]
        public int EstadoDoc { get; set; }
        [Display(Name = "Fecha de la creacion del doctor")]
        public DateTime FechaCreacionDoc { get; set; }

        public virtual Especialidad Especialidades { get; set; }
        public virtual Hospital Hospitales { get; set; }

        public Doctores()
        {
            FechaCreacionDoc = DateTime.Now;
        }

    }
}