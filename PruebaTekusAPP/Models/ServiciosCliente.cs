namespace PruebaTekusAPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiciosCliente")]
    public partial class ServiciosCliente
    {
        public int Id { get; set; }

        public int IdCliente { get; set; }

        public int IdServicio { get; set; }

      
    }
}
