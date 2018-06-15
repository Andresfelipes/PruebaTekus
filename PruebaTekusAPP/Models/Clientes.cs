namespace PruebaTekusAPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("Clientes")]
    public partial class Clientes
    {
        

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nit { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

       
    }
}
