using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SharedFood.Models
{
    public class DonacionFactory
    {
        public static Donacion Build(SqlDataReader sqlDataReader)
        {
            Donacion donacion = new Donacion();

            int ixIdDonacion = sqlDataReader.GetOrdinal("IdDonacion");
            int ixIdUsuarioCreacion = sqlDataReader.GetOrdinal("IdUsuarioCreacion");
            int ixImage = sqlDataReader.GetOrdinal("Image");
            int ixnombreAlimento = sqlDataReader.GetOrdinal("nombreAlimento");
            int ixfechaVencimiento = sqlDataReader.GetOrdinal("fechaVencimiento");
            int ixDescripcion = sqlDataReader.GetOrdinal("Descripcion");
            int ixLatitud = sqlDataReader.GetOrdinal("Latitud");
            int ixLongitud = sqlDataReader.GetOrdinal("Longitud");
            int ixRadio = sqlDataReader.GetOrdinal("Radio");
            int ixfechaCreacion = sqlDataReader.GetOrdinal("fechaCreacion");
            int ixfechaRecoleccion = sqlDataReader.GetOrdinal("fechaRecoleccion");
            int ixCantidad = sqlDataReader.GetOrdinal("Cantidad");
            int ixUbicacion = sqlDataReader.GetOrdinal("Ubicacion");

            int ixIdEstado = sqlDataReader.GetOrdinal("IdEstado");
            int _ixDonante = sqlDataReader.GetOrdinal("Donante");
            int _ixNombreEstado = sqlDataReader.GetOrdinal("NombreEstado");

            int _ixDistancia = sqlDataReader.GetOrdinal("Distancia");
           

            object[] values = new object[sqlDataReader.FieldCount];
            sqlDataReader.GetValues(values);

            donacion.IdDonacion = (int)values[ixIdDonacion];
            donacion.IdUsuarioCreacion = values[ixIdUsuarioCreacion].ToString();
            donacion.Image = (byte[])values[ixImage];
            donacion.nombreAlimento = (string)values[ixnombreAlimento];
            donacion.fechaVencimiento = (DateTime)values[ixfechaVencimiento];
            donacion.Descripcion = values[ixDescripcion].ToString();
            donacion.Latitud = (string)values[ixLatitud];
            donacion.Longitud = (string)values[ixLongitud];
            donacion.Radio = (decimal)values[ixRadio];
            donacion.fechaCreacion = (DateTime)values[ixfechaCreacion];
            donacion.fechaRecoleccion = (DateTime)values[ixfechaRecoleccion];
            donacion.Cantidad = (int)values[ixCantidad];
            donacion.Ubicacion = (string)values[ixUbicacion];

            donacion.IdEstado = (int)values[ixIdEstado];
            if (values[_ixDonante] != DBNull.Value)
                donacion._Donante = (string)values[_ixDonante];
            donacion._NombreEstado = (string)values[_ixNombreEstado];

            if (values[_ixDistancia] != DBNull.Value)
                donacion._Distancia = (decimal)values[_ixDistancia];
            return donacion;
        }
    }
}