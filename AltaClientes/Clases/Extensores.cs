using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static String Encrypt(this String cadena)
        {
            StringBuilder sb = new StringBuilder();
            string encriptado = String.Empty;
            List<Byte> byteList = new List<Byte>();

            foreach (char c in cadena.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }

            var plainTextBytes = Encoding.UTF8.GetBytes(sb.ToString());
            return Convert.ToBase64String(plainTextBytes);

        }

        public static String Decrypt(this String cadena)
        {
            List<Byte> byteList = new List<Byte>();

            byte[] base64EncodedBytes = Convert.FromBase64String(cadena);
            string binario = Encoding.UTF8.GetString(base64EncodedBytes);


            for (int i = 0; i < binario.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(binario.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }
    }
}
