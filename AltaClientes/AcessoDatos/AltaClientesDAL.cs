using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;




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
        public void AsignarClienteDAL()
        {
            accesoSqlServer = new AccesoSqlServer(Program.CadenaConexionSqlServer);
        }

        #endregion Constructor

        /// <summary>
        /// Método para consultar los usuarios.
        /// </summary>
        /// <returns>Regresa un DataTable con la lista de usuarios.</returns>
        public DataTable ConsultarUsuarios()
        {
            String query = String.Empty;
            DataTable dtUsuarios;

            try
            {
                dtUsuarios = new DataTable();
                query = "EXEC prueba.dbo.proc_BuscarDatosCliente @codigo = 0";

                if (accesoSqlServer.Open())
                {
                    dtUsuarios = accesoSqlServer.ExecuteDataTable(query);
                }


            }
            catch (Exception ex)
            {
                dtUsuarios = null;
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

            return dtUsuarios;
        }





    }
}
