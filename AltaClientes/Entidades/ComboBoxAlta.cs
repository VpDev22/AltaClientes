using AltaClientes.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AltaClientes.Entidades
{
    

        /// <summary>
        /// Clase para las propiedades de un combobox, para mantener oculto el id,
        /// con el fin de solo mostrar la descripcion.
        /// </summary>
        public class ComboBoxAlta : NotificacionBase
        {
            #region Elementos

            private String id;
            private String descripcion;

            #endregion Elementos

            #region Propiedades

            public String ID
            {
                get { return id; }
                set
                {
                    id = value;
                    RaisePropertyChanged();
                }
            }

            public String Descripcion
            {
                get { return descripcion; }
                set
                {
                    descripcion = value;
                    RaisePropertyChanged();
                }
            }

            #endregion Propiedades

            #region Constructor

            public ComboBoxAlta()
            {
                id = String.Empty;
                descripcion = String.Empty;
            }

            #endregion Constructor
        }
    }

