using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AltaClientes
{
    public class AccesoSqlServer
    {
        /// <summary>
        /// Clase para las conexión a diferentes SGBD por medio de ODBC.
        /// </summary>
        
            #region Elementos

            private SqlConnection sqlConexion;
            private SqlCommand sqlComando;
            private String cadenaConexion;

            #endregion Elementos

            #region Propiedades

            /// <summary>
            /// Propiedad con la cual se conectara por medio de un dirver, a los
            /// diferentes de SGBD disponibles en el sistema central.
            /// </summary>
            public SqlConnection SqlConexion
            {
                get { return sqlConexion; }
                set { sqlConexion = value; }
            }

            #endregion Propiedades

            #region Constructores

            /// <summary>
            /// Crea una instancia a una conexíón a traves de una cadena de conexión.
            /// </summary>
            /// <param name="cadenaConexion"></param>
            public AccesoSqlServer(String cadenaConexion)
            {
                this.cadenaConexion = cadenaConexion;
                sqlConexion = new SqlConnection(this.cadenaConexion);
                sqlComando = sqlConexion.CreateCommand();
            }

            /// <summary>
            /// Constructor para la conexión con parametros.
            /// </summary>
            /// <param name="sgbd">Driver para la conexión al sistema gestor de base de datos</param>
            /// <param name="servidor">Ip del servidor a utilizar en la conexión</param>
            /// <param name="baseDatos">Nombre de la base de datos que se utilizara</param>
            /// <param name="usuario">Usuario en el SGBD</param>
            /// <param name="password">Contraseña para la conexión con el usario proporcionado</param>
            public AccesoSqlServer(String sgbd, String servidor, String baseDatos, String usuario, String password)
            {
                cadenaConexion = String.Format("Driver={0};Server={1};Database={2};Uid={3};Pwd={4}",
                                                sgbd, servidor, baseDatos, usuario, password);
                sqlConexion = new SqlConnection(this.cadenaConexion);
                sqlComando = sqlConexion.CreateCommand();
            }

            /// <summary>
            /// Constructor para la conexión con parametros, que incluye puerto.
            /// </summary>
            /// <param name="sgbd">Driver para la conexión al sistema gestor de base de datos</param>
            /// <param name="servidor">Ip del servidor a utilizar en la conexión</param>
            /// <param name="baseDatos">Nombre de la base de datos que se utilizara</param>
            /// <param name="usuario">Usuario en el SGBD</param>
            /// <param name="password">Contraseña para la conexión con el usario proporcionado</param>
            /// <param name="puerto">Puerto por el cual se conecta al servidor remoto</param>
            public AccesoSqlServer(String sgbd, String servidor, String baseDatos, String usuario, String password, String puerto)
            {
                cadenaConexion = String.Format("Driver={0};Server={1};Database={2};Uid={3};Pwd={4};Port={5}",
                                                sgbd, servidor, baseDatos, usuario, password, puerto);
                sqlConexion = new SqlConnection(this.cadenaConexion);
                sqlComando = sqlConexion.CreateCommand();
            }

            #endregion Constructores

            #region Métodos públicos

            /// <summary>
            /// Método para abrir la conexión al servidor.
            /// </summary>
            /// <returns></returns>
            public Boolean Open()
            {
                Boolean resultado = false;

                if (sqlConexion.State == ConnectionState.Closed)
                {
                    sqlConexion.Open();
                }

                resultado = true;

                return resultado;
            }

            /// <summary>
            /// Método para cerrar la conexión al servidor.
            /// </summary>
            /// <returns></returns>
            public Boolean Close()
            {
                Boolean resultado = false;

                if (sqlConexion.State == ConnectionState.Open)
                {
                    sqlConexion.Close();
                }

                resultado = true;

                return resultado;
            }

            /// <summary>
            /// Método para la verificación de conexión al sevidor.
            /// </summary>
            /// <returns>True en caso de que la conexión sea correcta, False en el caso contrario</returns>
            public Boolean VerificarConexion()
            {
                Boolean resultado = false;

                try
                {
                    sqlConexion.Open();
                    resultado = true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error al abrir conexión odbc.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al abrir conexión odbc.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlConexion.State == ConnectionState.Open)
                    {
                        sqlConexion.Close();
                    }
                }

                return resultado;
            }

            #region Opciones al momento de utilizar una transaccion.

            /// <summary>
            /// Método para iniciar la transacción.
            /// </summary>
            public void BeginTransaction()
            {
                this.sqlComando.Transaction = sqlConexion.BeginTransaction();
            }

            /// <summary>
            /// Método para aceptar la transacción.
            /// </summary>
            public void CommitTransaction()
            {
                this.sqlComando.Transaction.Commit();
            }

            /// <summary>
            /// Método para declinar la transacción.
            /// </summary>
            public void RollbackTransaccion()
            {
                this.sqlComando.Transaction.Rollback();
            }

            /// <summary>
            /// Método para liberar la transacción.
            /// </summary>
            public void DisposeTransaccion()
            {
                this.sqlComando.Transaction.Dispose();
            }

            #endregion Opciones al momento de utilizar una transaccion.

            #region Operaciones en el servidor

            /// <summary>
            /// Ejecuta una operación, ya sea, un insert, update o delete.
            /// </summary>
            /// <param name="query">Operación a ejecutar</param>
            /// <returns>Regresa el numero de consultas afectadas</returns>
            public Int32 ExecuteQuery(String query)
            {
                Int32 count = 0;

                if (this.sqlConexion.State == ConnectionState.Closed)
                {
                    this.Open();
                }

                this.sqlComando.CommandText = query;
                count = this.sqlComando.ExecuteNonQuery();

                return count;
            }

            /// <summary>
            /// Método el llena un data reader con los datos consultados.
            /// </summary>
            /// <param name="query">Consulta con los datos a obtener de servidor</param>
            /// <returns>Regresa un OdbcDataReader con los datos obtenidos</returns>
            public SqlDataReader ExecuteReader(String query)
            {
                SqlDataReader odbcDataReader = null;

                if (sqlConexion.State == ConnectionState.Closed)
                {
                    this.Open();
                }

                sqlComando.CommandText = query;
                odbcDataReader = sqlComando.ExecuteReader();

                return odbcDataReader;
            }

            /// <summary>
            /// Método el llena un data table con los datos consultados.
            /// </summary>
            /// <param name="query">Consulta con los datos a obtener de servidor</param>
            /// <returns>Regresa un DataTable con los datos obtenidos</returns>
            public DataTable ExecuteDataTable(String query)
            {
                DataTable dataTable = new DataTable();
                SqlDataAdapter odbcDataAdapter = new SqlDataAdapter(query, sqlConexion);

                if (sqlConexion.State == ConnectionState.Closed)
                {
                    this.Open();
                }

                odbcDataAdapter.Fill(dataTable);

                return dataTable;
            }

            #endregion Operaciones en el servidor

            #region Miembros de ICloneable

            /// <summary>
            /// Método para crear una copia exacta de la clase actual.
            /// </summary>
            /// <returns>Regresa un objeto con todas las propiedades de este objeto</returns>
            public object Clone()
            {
                return this.MemberwiseClone();
            }

            #endregion Miembros de ICloneable

            #endregion Métodos públicos
        
    }
}
