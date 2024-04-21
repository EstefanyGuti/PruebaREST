using System.Data;
using Microsoft.Data.SqlClient;
using Models.ACME;

namespace DataAccess.ACME
{
    public class EmpresaDA
    {
        private Conexion _conexion = new Conexion();

        public void Insertar (EmpresaEntiedad empresaEntiedad)
        {
            SqlConnection sqlConn = _conexion.Conectar();
            SqlCommand sqlComm = new SqlCommand();

            try 
            {
                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "InsertarEmpresa";
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", SqlDbType.Int)).Direction = ParameterDirection.Output;
                sqlComm.Parameters.Add(new SqlParameter("@IDTipoEmpresa", empresaEntiedad.IDTipoEmpresa));
                sqlComm.Parameters.Add(new SqlParameter("@Empresa", empresaEntiedad.Empresa));
                sqlComm.Parameters.Add(new SqlParameter("@Direccion", empresaEntiedad.Direccion));
                sqlComm.Parameters.Add(new SqlParameter("@RUC", empresaEntiedad.RUC));
                sqlComm.Parameters.Add(new SqlParameter("@FechaCreacion", empresaEntiedad.FechaCreacion));
                sqlComm.Parameters.Add(new SqlParameter("@Presupuesto", empresaEntiedad.Presupuesto));
                sqlComm.Parameters.Add(new SqlParameter("@Activo", empresaEntiedad.Activo));

                sqlComm.ExecuteNonQuery();
                empresaEntiedad.IDEmpresa =(int)sqlComm.Parameters[sqlComm.Parameters.IndexOf("@IDEmpresa")].Value;

                sqlConn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("EmpresaDA.Insertar: " + ex.Message);
            }
            finally
            {
                sqlConn.Dispose();
            }
        }
        public void Modificar (EmpresaEntiedad empresaEntiedad)
        {
            SqlConnection sqlConn = _conexion.Conectar();
            SqlCommand sqlComm = new SqlCommand();

            try
            {
                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ModificarEmpresa";
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntiedad.IDEmpresa));
                sqlComm.Parameters.Add(new SqlParameter("@IDTipoEmpresa", empresaEntiedad.IDTipoEmpresa));
                sqlComm.Parameters.Add(new SqlParameter("@Empresa", empresaEntiedad.Empresa));
                sqlComm.Parameters.Add(new SqlParameter("@Direccion", empresaEntiedad.Direccion));
                sqlComm.Parameters.Add(new SqlParameter("@RUC", empresaEntiedad.RUC));
                sqlComm.Parameters.Add(new SqlParameter("@FechaCreacion", empresaEntiedad.FechaCreacion));
                sqlComm.Parameters.Add(new SqlParameter("@Presupuesto", empresaEntiedad.Presupuesto));
                sqlComm.Parameters.Add(new SqlParameter("@Activo", empresaEntiedad.Activo));

                if (sqlComm.ExecuteNonQuery()!=1)
                {
                    throw new Exception("EmpresaDA.Modificar: Problema al actualizar");
                }

                sqlConn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("EmpresaDA.Modificar: " + ex.Message);
            }
            finally
            {
                sqlConn.Dispose();
            }
        }
        public void Anular(EmpresaEntiedad empresaEntiedad)
        {
            SqlConnection sqlConn = _conexion.Conectar();
            SqlCommand sqlComm = new SqlCommand();

            try
            {
                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "AnularEmpresa";
                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa", empresaEntiedad.IDEmpresa));


               sqlComm.ExecuteNonQuery() ;
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("EmpresaDA.Anular: " + ex.Message);
            }
            finally
            {
                sqlConn.Dispose();
            }
        }
        public List<EmpresaEntiedad>Listar()
        {
            SqlConnection sqlConn = _conexion.Conectar();
            SqlDataReader sqlDataRead;
            SqlCommand sqlCommand = new SqlCommand();

            List<EmpresaEntiedad>? listaEmpresa = new List<EmpresaEntiedad>();
            EmpresaEntiedad? empresaEntiedad;

            try
            {
                sqlConn.Open();
                sqlCommand.Connection = sqlConn;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "ListarEmpresa";

                sqlDataRead = sqlCommand.ExecuteReader();
                while (sqlDataRead.Read())
                {
                    empresaEntiedad = new();
                    empresaEntiedad.IDEmpresa = (int)sqlDataRead["IDEmpresa"];
                    empresaEntiedad.IDTipoEmpresa = (int)sqlDataRead["IDTipoEmpresa"];
                    empresaEntiedad.Empresa = sqlDataRead["Empresa"].ToString() ?? string.Empty;
                    empresaEntiedad.Direccion = sqlDataRead["Direccion"].ToString() ?? string.Empty;
                    empresaEntiedad.RUC= sqlDataRead["RUC"].ToString() ?? string.Empty;
                    if (sqlDataRead["FechaCreacion"]!=DBNull.Value)
                    {
                        empresaEntiedad.FechaCreacion = (DateTime)sqlDataRead["FechaCreacion"];
                    }
                    if (sqlDataRead["Presupuesto"] != DBNull.Value)
                    {
                        empresaEntiedad.Presupuesto = (decimal)sqlDataRead["Presupuesto"];
                    }
                    empresaEntiedad.Activo = (bool)sqlDataRead["Activo"];

                    listaEmpresa.Add(empresaEntiedad);

                }
                sqlConn.Close();
                return listaEmpresa;
            }
            catch (Exception ex)
            {
                throw new Exception("EmpresaDA.Listar;" + ex.Message);
            }
            finally
            {
                sqlConn.Dispose();
            }
        }
        public EmpresaEntiedad BuscarID(int IDEmpresa)
        {
            SqlConnection sqlConn = _conexion.Conectar();
            SqlDataReader sqlDataRead;
            SqlCommand sqlCommand = new SqlCommand();
            EmpresaEntiedad? empresaEntiedad=null;

            try
            {
                sqlConn.Open();
                sqlCommand.Connection = sqlConn;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "BuscarEmpresa";

                sqlComm.Parameters.Add(new SqlParameter("@IDEmpresa",IDEmpresa));
                sqlDataRead = sqlCommand.ExecuteReader();
                while (sqlDataRead.Read())
                {
                    empresaEntiedad = new();
                    empresaEntiedad.IDEmpresa = (int)sqlDataRead["IDEmpresa"];
                    empresaEntiedad.IDTipoEmpresa = (int)sqlDataRead["IDTipoEmpresa"];
                    empresaEntiedad.Empresa = sqlDataRead["Empresa"].ToString() ?? string.Empty;
                    empresaEntiedad.Direccion = sqlDataRead["Direccion"].ToString() ?? string.Empty;
                    empresaEntiedad.RUC = sqlDataRead["RUC"].ToString() ?? string.Empty;
                    if (sqlDataRead["FechaCreacion"] != DBNull.Value)
                    {
                        empresaEntiedad.FechaCreacion = (DateTime)sqlDataRead["FechaCreacion"];
                    }
                    if (sqlDataRead["Presupuesto"] != DBNull.Value)
                    {
                        empresaEntiedad.Presupuesto = (decimal)sqlDataRead["Presupuesto"];
                    }
                    empresaEntiedad.Activo = (bool)sqlDataRead["Activo"];

                }
                sqlConn.Close();
                if (empresaEntiedad==null)
                {
                    throw new Exception("EmpresaDA.BuscarID; EL ID de empresa no existe");
                }
                return empresaEntiedad;
            }

            catch (Exception ex)
            {
                throw new Exception("EmpresaDA.BuscarID;" + ex.Message);
            }
            finally
            {
                sqlConn.Dispose();
            }
        }
    }
    
}
 