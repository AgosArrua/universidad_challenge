//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace universidad_challenge.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class teachers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public teachers()
        {
            this.subjects = new HashSet<subjects>();
        }
    
        public int id_teacher { get; set; }
        public int teacher_dni { get; set; }
        public string teacher_name { get; set; }
        public string teacher_last_name { get; set; }
        public bool active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<subjects> subjects { get; set; }
    }
}
