using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AltaClientes.Clases;



namespace AltaClientes.AcessoDatos
{
    class AltaClientesDAL
    {
        #region Elementos

        /// <summary>
        /// Objeto de la instancia Odbc, para la conexión a SQL Server.
        /// </summary>
        private AccesoSqlServer accesoSqlServer;

        #endregion Elementos
        #region Constructor

        /// <summary>
        /// Constructor para instanciar el objeto odbc con la cadena de conexión a SQL Server. 
        /// </summary>
        public AltaClientesDAL()
        {
            accesoSqlServer = new AccesoSqlServer(Program.CadenaConexionSqlServer);
        }

        #endregion Constructor

        #region Métodos públicos

        public Boolean AltaCliente(int codigo, string nombre, string telefono, string fecha, string domicilio, int numero, int estatus)
        {
            Boolean resultado = false;
            string query = String.Empty;
            try
            {
                if (accesoSqlServer.Open())


                {
                    query = String.Format($"EXEC prueba.dbo.proc_GuardarClientes @numCliente = {codigo}, @nomCliente ='{nombre}',@telefono ='{telefono}' ," +
                        $"@fechaNac = '{fecha}', @domicilio = '{domicilio}' , @interior = {numero}, @estatus = {estatus} ");

                    //MessageBox.Show(query);
                    resultado = Convert.ToBoolean(accesoSqlServer.ExecuteQuery(query));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                /*Error.Guardar(accesoSqlServer.SqlConexion,
                              "MAPER001",
                              "AsignarUsuarioDAL",
                              "GuardarUsuario",
                              "proc_MaPer001GuardarUsuarios",
                              "0",
                              ex.Message);*/
            }
            finally
            {
                accesoSqlServer.Close();
            }

            return resultado;

        }

        //public Boolean ActualizarClientes(int codigo, string nombre, string telefono, string fecha, string domicilio, int numero)
        //{
        //    Boolean resultado = false;
        //    string query = String.Empty;
        //    try
        //    {
        //        if (accesoSqlServer.Open())


        //        {
        //            query = String.Format($"EXEC prueba.dbo.proc_GuardarClientes @codigo = {codigo}, @nombrecliente ='{nombre}',@telefono ='{telefono}' ," +
        //                $"@fechanacimiento = '{fecha}', @domicilio = '{domicilio}' , @numinterior = {numero} ");

        //            //MessageBox.Show(query);
        //            resultado = Convert.ToBoolean(accesoSqlServer.ExecuteQuery(query));
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al modificar usuario",
        //                        "Error",
        //                        MessageBoxButtons.OK,
        //                        MessageBoxIcon.Error);

        //        /*Error.Guardar(accesoSqlServer.SqlConexion,
        //                      "MAPER001",
        //                      "AsignarUsuarioDAL",
        //                      "GuardarUsuario",
        //                      "proc_MaPer001GuardarUsuarios",
        //                      "0",
        //                      ex.Message);*/
        //    }
        //    finally
        //    {
        //        accesoSqlServer.Close();
        //    }

        //    return resultado;

        //}

        public Boolean DeshabilitarClientes(int codigo)
        {
            Boolean resultado = false;
            string query = String.Empty;
            try
            {
                if (accesoSqlServer.Open())


                {
                    query = String.Format($"EXEC prueba.dbo.proc_DeshabilitarClientes @codigo = {codigo} ");

                    //MessageBox.Show(query);
                    resultado = Convert.ToBoolean(accesoSqlServer.ExecuteQuery(query));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar usuario",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                /*Error.Guardar(accesoSqlServer.SqlConexion,
                              "MAPER001",
                              "AsignarUsuarioDAL",
                              "GuardarUsuario",
                              "proc_MaPer001GuardarUsuarios",
                              "0",
                              ex.Message);*/
            }
            finally
            {
                accesoSqlServer.Close();
            }

            return resultado;

        }

        public DataTable CargarClientes()
        {
            String query = String.Empty;
            DataTable dtClientes;

            try
            {
                dtClientes = new DataTable();
                query = $"EXEC prueba.dbo.proc_cargarClientes";

                if (accesoSqlServer.Open())
                {
                    dtClientes = accesoSqlServer.ExecuteDataTable(query);
                 
                }


            }
            catch (Exception ex)
            {
                dtClientes = null;
                MessageBox.Show("Error al consultar usuarios",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                //Error.Guardar(accesoSqlServer.SqlConexion,
                //              "MAPER001",
                //              "AsignarUsuarioDAL",
                //              "ConsultarUsuarios",
                //              "proc_MaPer001CargaCatalogos",
                //              "0",
                //              ex.Message);
            }
            finally
            {
                accesoSqlServer.Close();
            }

            return dtClientes;
        }

        public DataTable llenarCliente(int codigo)
        {
            String query = String.Empty;
            DataTable dtClientes;

            try
            {
                dtClientes = new DataTable();
                query = $"EXEC prueba.dbo.proc_BuscarDatosCliente  @codigo = {codigo}";

                if (accesoSqlServer.Open())
                {
                    dtClientes = accesoSqlServer.ExecuteDataTable(query);

                }


            }
            catch (Exception ex)
            {
                dtClientes = null;
                MessageBox.Show("Error al consultar usuarios",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                //Error.Guardar(accesoSqlServer.SqlConexion,
                //              "MAPER001",
                //              "AsignarUsuarioDAL",
                //              "ConsultarUsuarios",
                //              "proc_MaPer001CargaCatalogos",
                //              "0",
                //              ex.Message);
            }
            finally
            {
                accesoSqlServer.Close();
            }

            return dtClientes;
        }



    }
    #endregion Metodos Publicos
}
