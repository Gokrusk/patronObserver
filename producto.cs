using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patronObserver
{
    public class producto : interfaceSujetoProducto
    {
        private List<interfaceObserverUsuario> _usuarios;
        public producto(string nombre, double precio)
        {

            _usuarios = new List<interfaceObserverUsuario>();
            Nombre = nombre;
            _precio = precio;
        }

        public string Nombre { get; set; }

        double _precio;

        public double Precio
        {
            get
            {
                return _precio;
            }
            set
            {
                _precio = value;
                this.Notificar();
            }
        }

        public override string ToString()
        {
            return $"{Nombre} (${_precio})";
        }

        public void Agregar(interfaceObserverUsuario usuario)
        {
            if (!_usuarios.Contains(usuario))
            {
                _usuarios.Add(usuario);
            }
            else
            {
                throw new Exception($"Ya existe una suscripción para {((usuario)usuario)}");
            }
        }

        public void Notificar()
        {
            foreach (var usuario in _usuarios)
            {
                usuario.Actualizar(this);
            }

            Form1 f = (Form1)System.Windows.Forms.Application.OpenForms[0];

            if (_usuarios.Count == 0)
            {
                f.Notificar($"No hay suscripciones");
            }

            f.Notificar($"--------------------------------------------------------------------------------------------------------------------");
        }

        public void Quitar(interfaceObserverUsuario usuario)
        {
            if (_usuarios.Contains(usuario))
            {
                _usuarios.Remove(usuario);
            }
            else
            {
                throw new Exception($"Na existe una suscripción para {((usuario)usuario)}");
            }
        }
    }
}
