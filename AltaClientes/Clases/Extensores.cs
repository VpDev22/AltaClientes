using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;


namespace AltaClientes
{
    public static class Extensores
    {
        /// <summary>
        /// Verifica la conexión con la cadena que se genero
        /// con los parametros que toma del menú
        /// </summary>
        /// <param name="cadenaConexion"></param>
        /// <returns></returns>
        public static Boolean VerificaConexion(this String cadenaConexion)
        {
            Boolean resultado = false;
            SqlConnection sqlConexion = new SqlConnection();

            try
            {
                sqlConexion.ConnectionString = cadenaConexion;
                sqlConexion.Open();
                resultado = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("ERROR EN CONEXIÓN AL SERVIDOR",
                                "ERROR",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                MessageBox.Show(ex.Message,
                                "ERROR",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "ERROR",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                sqlConexion.Dispose();
            }

            return resultado;
        }

    }
}
