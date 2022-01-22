using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patronObserver
{
    public interface interfaceSujetoProducto
    {
        void Agregar(interfaceObserverUsuario usuario);
        void Quitar(interfaceObserverUsuario usuario);
        void Notificar();
    }
}
