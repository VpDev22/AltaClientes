using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using AltaClientes.Modelos;
using AltaClientes.Properties;
using AltaClientes.AcessoDatos;

namespace AltaClientes.Modelos
{
    class AltaClientesViewModel
    {
        #region Elementos

        private AltaClientesDAL asignarClienteDAL;

        #endregion Elementos

        #region Constructor

        /// <summary>
        /// Constructor que instancia todos los objeto usados en la clase. 
        /// </summary>
        public AltaClientesViewModel()
        {
            asignarClienteDAL = new AltaClientesDAL();
        }

        #endregion Constructor

        #region Métodos públicos

        public DataTable ConsultarUsuarios()
        {
            DataTable dtUsuarios;

            dtUsuarios = asignarClienteDAL.ConsultarUsuarios();

            return dtUsuarios;
        }
        #endregion Métodos públicos   
    }
}
