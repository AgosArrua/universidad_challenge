using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace universidad_challenge.Models
{
    public class TeachersCE
    {
        [Required]
        [Display(Name = "DNI del profesor")]
        public int teacher_dni { get; set; }
        [Required]
        [Display(Name = "Ingrese nombres")]
        public string teacher_name { get; set; }
        [Required]
        [Display(Name = "Ingrese apellidos")]
        public string teacher_last_name { get; set; }
        [Required]
        [Display(Name = "Profesor activo")]
        public bool active { get; set; }
    }

    [MetadataType(typeof(TeachersCE))]

    public partial class teachers
    {
        public string NombreCompleto { get { return teacher_name + " " + teacher_last_name; } }
    }
}