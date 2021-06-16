using System;
using System.Collections.Generic;
using System.Data;
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

        /// <summary>
        /// Método para consultar los usuarios.
        /// </summary>
        /// <returns>Regresa un DataTable con la lista de usuarios.</returns>
        /// 

        /// <summary>
        /// Método para agregar un usuario a la Base de Datos.
        /// </summary>
        /// <param name="u">Entidad usuario con los datos a guardar</param>
        /// <returns>Regresa true si guardó el registro, false si ocurrió un error.</returns>
        public Boolean GuardarUsuario(UsuarioInfo u)
        {
            Boolean resultado = false;
            string query = String.Empty;

            try
            {
                if (accesoSqlServer.Open())
                {
                    query = String.Format($"EXEC MonitorImportacion.dbo.proc_MaPer001GuardarUsuarios @numUsuario = {u.NumeroUsuario} ," +
                                        $" @usuario = '{u.NombreUsuario}', @pass = '{u.PassUsuario}',@rol = {u.RolUsuario}, @usuarioAutoriza = {Program.Usuario}");

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


    }
    #endregion Metodos Publicos
}
