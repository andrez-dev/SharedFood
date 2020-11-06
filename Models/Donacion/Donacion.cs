using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedFood.Models
{
    public class Donacion
    {
        public int IdDonacion { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public HttpPostedFileBase postedFile { get; set; }
        public byte[] Image { get; set; }
        public string nombreAlimento { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public string Descripcion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public decimal? Radio { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaRecoleccion { get; set; }
        public int Cantidad { get; set; }
        public string Ubicacion { get; set; }

        public int IdEstado { get; set; }
        public string _Donante { get; set; }
        public string _NombreEstado { get; set; }

        public decimal _Distancia { get; set; }

    }
}