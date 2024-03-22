using Modelo;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class CD_Proveedor
    {
        public static CD_Proveedor _instancia = null;
        private CD_Proveedor()
        {

        }
        public static CD_Proveedor Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Proveedor();
                }
                return _instancia;
            }
        }
        public List<Proveedor> ObtenerProveedor()
        {
            var rptListaProveedor = new List<Proveedor>();
            using (SqlConnection oConexion = new(Conexion.Con()))
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_MostrarProveedores", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaProveedor.Add(new Proveedor()
                        {
                            //  Id = row.Field<Guid>("IdUsuario"),
                            Id = Convert.ToInt32(dr["IdProveedor"].ToString()),
                            NombreCompañia = dr["NombreCompañia"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                           Estado = Convert.ToBoolean(dr["Estado"].ToString()),
                            //FechaCreacion= dr["FechaCreacion"].ToString()
                        });
                    }
                    dr.Close();

                    return rptListaProveedor;
                }
                catch
                {
                    rptListaProveedor = null;
                    return rptListaProveedor;
                }
            }
        }
        public bool RegistrarProveedor(Proveedor oProveedor)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.Con()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.sp_AgregarProveedores", oConexion);
                    // cmd.Parameters.AddWithValue("Descripcion", oCategoria.)
                    cmd.Parameters.AddWithValue("NombreCompañia", oProveedor.NombreCompañia = (oProveedor.NombreCompañia != null ? oProveedor.NombreCompañia : ""));
                    cmd.Parameters.AddWithValue("Correo", oProveedor.Correo = (oProveedor.Correo != null ? oProveedor.Correo : ""));
                    cmd.Parameters.AddWithValue("Telefono", oProveedor.Telefono = (oProveedor.Telefono != null ? oProveedor.Telefono : ""));
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
        public bool ModificarProveedor(Proveedor oProveedor)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.Con()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.sp_EditarProveedores", oConexion);
                    cmd.Parameters.AddWithValue("IdCategoria", oProveedor.Id);
                    cmd.Parameters.AddWithValue("NombreCompañia", oProveedor.NombreCompañia = (oProveedor.NombreCompañia != null ? oProveedor.NombreCompañia : ""));
                    cmd.Parameters.AddWithValue("Correo", oProveedor.Correo = (oProveedor.Correo != null ? oProveedor.Correo : ""));
                    cmd.Parameters.AddWithValue("Telefono", oProveedor.Telefono = (oProveedor.Telefono != null ? oProveedor.Telefono : ""));
                    cmd.Parameters.AddWithValue("Activo", oProveedor.Estado);
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
        public bool EliminarProveedor(int IdProveedor)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.Con()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.sp_EliminarProveedores", oConexion);
                    cmd.Parameters.AddWithValue("cod", IdProveedor);
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
    }
}