﻿using Modelo;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class CD_Categoria
    {
        public static CD_Categoria _instancia = null;
        private CD_Categoria()
        {

        }
        public static CD_Categoria Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Categoria();
                }
                return _instancia;
            }
        }
        public List<Categoria> ObtenerCategoria()
        {
            var rptListaCategoria = new List<Categoria>();
            using (SqlConnection oConexion = new(Conexion.Con()))
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_MostrarCategoria", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaCategoria.Add(new Categoria()
                        {

                            Id = Convert.ToInt32(dr["IdCategoria"].ToString()), 
                            Descripcion = dr["Descripcion"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"].ToString()),
                            //FechaCreacion= dr["FechaCreacion"].ToString()
                        });
                    }
                    dr.Close();

                    return rptListaCategoria;
                }
                catch
                {
                    rptListaCategoria = null;
                    return rptListaCategoria;
                }
            }
        }
        public bool RegistrarCategoria(Categoria oCategoria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.Con()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.sp_AgregarCategoria", oConexion);
                    // cmd.Parameters.AddWithValue("Descripcion", oCategoria.)
                    cmd.Parameters.AddWithValue("Descripcion", oCategoria.Descripcion = (oCategoria.Descripcion != null ? oCategoria.Descripcion : ""));
                    cmd.Parameters.Add("Resultado",SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public bool ModificarCategoria(Categoria oCategoria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.Con()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.sp_EditarCategoria", oConexion);
                    cmd.Parameters.AddWithValue("IdCategoria", oCategoria.Id);
                    cmd.Parameters.AddWithValue("Descripcion", oCategoria.Descripcion = (oCategoria.Descripcion != null? oCategoria.Descripcion : ""));
                    cmd.Parameters.AddWithValue("Activo", oCategoria.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public bool EliminarCategoria(int IdCategoria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.Con()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.sp_EliminarCategoria", oConexion);
                    cmd.Parameters.AddWithValue("cod", IdCategoria);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch
                {
                    respuesta=false;
                }
            }
            return respuesta;
        }
    }
}

       

