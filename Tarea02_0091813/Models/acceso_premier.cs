//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tarea02_0091813.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class acceso_premier
    {
        public int idapremier { get; set; }
        public string nombre_pelicula { get; set; }
        public int idpersona { get; set; }
    
        public virtual persona persona { get; set; }
        public virtual pelicula pelicula { get; set; }
    }
}