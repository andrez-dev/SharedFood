using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedFood.Common
{
    public class Enums
    {
        public  enum Estado{
            Disponible = 1,
            Adquirido = 2,
            Vencido = 3,
            Eliminado = 4
        }
    }
}