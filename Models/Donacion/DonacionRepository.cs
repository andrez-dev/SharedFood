using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SharedFood.Models
{
    public class DonacionRepository:Repository
    {
        public void Insertar(Donacion donacion)
        {
            SqlCommand cmd = new SqlCommand("Crear_Donacion");
         
            cmd.Parameters.AddWithValue("@IdUsuarioCreacion", donacion.IdUsuarioCreacion);
            cmd.Parameters.AddWithValue("@Image", donacion.Image);
            cmd.Parameters.AddWithValue("@nombreAlimento", donacion.nombreAlimento);
            cmd.Parameters.AddWithValue("@fechaVencimiento", DateTime.Now);
            cmd.Parameters.AddWithValue("@Descripcion", donacion.Descripcion);
            cmd.Parameters.AddWithValue("@Latitud", donacion.Latitud);
            cmd.Parameters.AddWithValue("@Longitud", donacion.Longitud);
            cmd.Parameters.AddWithValue("@Radio", donacion.Radio);
            cmd.Parameters.AddWithValue("@fechaRecoleccion", DateTime.Now);
            cmd.Parameters.AddWithValue("@Vigencia", donacion.Cantidad);
            cmd.Parameters.AddWithValue("@Ubicacion", donacion.Ubicacion);
            cmd.Parameters.AddWithValue("@IdEstado", donacion.IdEstado);
            ExecuteNonQuery(cmd);

        }

        public List<Donacion> GetList(string IdUsuarioCreacion)
        {
            SqlCommand cmd = new SqlCommand("Usp_MiLista");
            cmd.Parameters.AddWithValue("@IdUsuarioCreacion", IdUsuarioCreacion);


            List<Donacion> list = new List<Donacion>();
            using (SqlDataReader sdr = ExecuteReader(cmd))
            {
                while (sdr.Read())
                {
                    list.Add(DonacionFactory.Build(sdr));
                }
            }
            return list;
        }


        public List<Donacion> GetListAplicarProducts(string IdUsuarioCreacion)
        {
            SqlCommand cmd = new SqlCommand("Calcular_Distancia");
            cmd.Parameters.AddWithValue("@UserId", IdUsuarioCreacion);


            List<Donacion> list = new List<Donacion>();
            using (SqlDataReader sdr = ExecuteReader(cmd))
            {
                while (sdr.Read())
                {
                    list.Add(DonacionFactory.Build(sdr));
                }
            }
            return list;
        }

    }
}