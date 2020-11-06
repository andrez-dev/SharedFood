using SharedFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedFood
{
    public static class MyBusiness
    {
        public static DonacionRepository Donacion { get; private set; }
        static MyBusiness()
        {
            Donacion = new DonacionRepository();

        }
    }
}