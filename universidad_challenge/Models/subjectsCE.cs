using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace universidad_challenge.Models
{
    public class SubjectsCE
    {
        [Required]
        [Display(Name = "Ingrese nueva materia")]
        public string subject_name { get; set; }
        [Required]
        [Display(Name = "Profesor")]
        public int id_teacher { get; set; }
        [Required]
        [Display(Name = "Hora de inicio")]
        public System.TimeSpan start_time { get; set; }
        [Required]
        [Display(Name = "Hora de finalización")]
        public System.TimeSpan end_time { get; set; }
        [Required]
        [Display(Name = "Cupo máximo de alumnos")]
        public int students_max { get; set; }
        [Required]
        [Display(Name = "Alumnos inscriptos")]
        public int students { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        public string description { get; set; }
    }

    [MetadataType(typeof(SubjectsCE))]

    public partial class subjects
    {
        public int CuposDisponibles { get { return students_max - students; } }
    }
}