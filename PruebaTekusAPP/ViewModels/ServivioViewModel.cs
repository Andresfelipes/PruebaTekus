using PruebaTekusAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTekusAPP.ViewModels
{
    public class ServivioViewModel
    {
        public Servicios Servicios { get; set; }
        public List<Pais> Paises { get; set; }
        public int IdCliente { get; set; }
    }
}