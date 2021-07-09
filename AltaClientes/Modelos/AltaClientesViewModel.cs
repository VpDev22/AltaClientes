using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;


using AltaClientes.Clases;
using AltaClientes.AcessoDatos;

namespace AltaClientes.Modelos
{
    /// <summary>
    /// Clase de vista-modelo para el formulario principal,
    /// la cual es una clase intermedia entra las vistas y
    /// la capa de acceso a datos (DAL).
    /// </summary>
    class AltaClientesViewModel
    {
     
            #region Elementos

            private AltaClientesDAL altaClientesDAL;

        public object altaClienteDAL { get; private set; }

        #endregion Elementos

        #region Constructor

        /// <summary>
        /// Constructor que instancia todos los objeto usados en la clase. 
        /// </summary>
        public AltaClientesViewModel()
            {
            altaClientesDAL = new AltaClientesDAL();
            }

        #endregion Constructor

        #region Métodos públicos
        
            public Boolean AltaCliente(int codigo, string nombre, string telefono, string fecha, string domicilio, int numero, int estatus)
            {
                Boolean resultado = false;

                resultado = altaClientesDAL.AltaCliente(codigo,nombre, telefono, fecha,  domicilio, numero, estatus);

                return resultado;
            }
           //public Boolean ActualizarClientes(int codigo, string nombre, string telefono, string fecha, string domicilio, int numero)
           // {
           //     Boolean resultado = false;

           //     resultado = altaClientesDAL.ActualizarClientes(codigo,nombre, telefono, fecha,  domicilio, numero);

           //     return resultado;
           // }
        public Boolean DeshabilitarClientes(int codigo)
            {
                Boolean resultado = false;

                resultado = altaClientesDAL.DeshabilitarClientes(codigo);

                return resultado;
            }

        public DataTable CargarClientes()
        {
            DataTable dtClientes;

            dtClientes = altaClientesDAL.CargarClientes();

            return dtClientes;
        }
        #endregion Métodos públicos
    }


}
