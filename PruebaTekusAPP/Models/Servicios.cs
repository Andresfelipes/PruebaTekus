namespace PruebaTekusAPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Servicios")]
    public partial class Servicios
    {
       

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

  
        public string ValorHora { get; set; }

      
    }
}
