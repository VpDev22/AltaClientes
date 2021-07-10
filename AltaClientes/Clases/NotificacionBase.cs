using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AltaClientes.Clases
{
    
        /// <summary>
        /// Clase para notificar a los controles el cambio en sus propiedades.
        /// </summary>
        public abstract class NotificacionBase : INotifyPropertyChanged
        {
            /// <summary>
            /// Evento el cual notificara el cambio de una propiedad en un control,
            /// enlazado a una variable dentro de una entidad.
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;

            /// <summary>
            /// Método en cual notificara el cambio.s
            /// </summary>
            /// <param name="propertyName"></param>
            protected void RaisePropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
}
