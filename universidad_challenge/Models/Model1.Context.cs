﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class universityEntities : DbContext
    {
        public universityEntities()
            : base("name=universityEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<subjects> subjects { get; set; }
        public virtual DbSet<teachers> teachers { get; set; }
    }
}
