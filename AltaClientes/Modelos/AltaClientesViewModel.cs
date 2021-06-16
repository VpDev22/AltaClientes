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
        /*
            public DataTable ConsultarUsuarios()
            {
                DataTable dtUsuarios;

                dtUsuarios = altaClientesDAL.ConsultarUsuarios();

                return dtUsuarios;
            }
        
            public DataTable ConsultarRoles()
            {
                DataTable dtRoles;

                dtRoles = altaClientesDAL.ConsultarRoles();

                return dtRoles;
            }

            public DataTable ConsultarSuplentes()
            {
                DataTable dtSuplentes;

                dtSuplentes = altaClientesDAL.ConsultarSuplentes();

                return dtSuplentes;
            }

            public Int32 ValidarUsuario(String usuario)
            {
                int resultado = 0;

                resultado = altaClientesDAL.ValidarUsuario(usuario);

                return resultado;
            }
 */
            public Boolean GuardarUsuario(UsuarioInfo usuario)
            {
                Boolean resultado = false;

                resultado = altaClientesDAL.GuardarUsuario(usuario);

                return resultado;
            }
           
        #endregion Métodos públicos
    }


}
