using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace AltaClientes
{
    static class Program
    {
        /// <summary>
        /// Elemento para la conexion
        /// </summary>
        private static String cadenaConexionSqlServer;

        /// <summary>
        /// Propiedad para la conexion
        /// </summary>
        public static String CadenaConexionSqlServer
        {
            get { return Program.cadenaConexionSqlServer; }
            set { Program.cadenaConexionSqlServer = value; }
        }

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                frmAltaClientes frmaltaclientes = new frmAltaClientes();
                cadenaConexionSqlServer = "server=MOV-230542-9015\\SQLEXPRESS ; database=prueba ; integrated security = true";

                

                if (cadenaConexionSqlServer.VerificaConexion())
                {
                    frmaltaclientes.ShowDialog();
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
       
           
        
    }
}
