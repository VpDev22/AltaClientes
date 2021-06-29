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

        private AltaClientesDAL altaclientesDAL;

        #endregion Elementos

        #region Constructor

        /// <summary>
        /// Constructor que instancia todos los objeto usados en la clase. 
        /// </summary>
        public AltaClientesViewModel()
        {
            altaclientesDAL = new AltaClientesDAL();
        }

        #endregion Constructor

        #region Métodos públicos

        public DataTable ConsultarUsuarios()
        {
            DataTable dtUsuarios;

            dtUsuarios = altaclientesDAL.CargarClientes();

            return dtUsuarios;
        }
        
        public Boolean GuardarCliente(int num, string nombre, int telefono, string fechanac, string domicilio, int numeroint)
        {
            Boolean resultado = false;

            resultado = altaclientesDAL.GuardarCliente(num, nombre, telefono, fechanac, domicilio, numeroint);
            return resultado;
        }
        //public Boolean ModificarCliente(int num, string nombre, int telefono, string fechanac, string domicilio, int numeroint)
        //{
        //    Boolean resultado = false;

        //    resultado = altaclientesDAL.ActualizarCliente(num, nombre, telefono, fechanac, domicilio, numeroint);
        //    return resultado;
        //}
        //public Boolean DeshabilitarCliente(int codigo)
        //{
        //    Boolean resultado = false;

        //    resultado = altaclientesDAL.DeshabilitaCliente(codigo);
        //    return resultado;
        //}
        #endregion Métodos públicos   
    }
}
