namespace PruebaTekusAPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaisServicio")]
    public partial class PaisServicio
    {
        public int Id { get; set; }

        public int IdPais { get; set; }

        public int IdServicio { get; set; }


    }
}