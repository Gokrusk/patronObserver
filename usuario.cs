using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patronObserver
{
    public class usuario : interfaceObserverUsuario
    {

        public usuario(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }


        public override string ToString()
        {
            return $"{Nombre} {Apellido}";
        }


        public void Actualizar(producto p)
        {
            
            Form1 f = (Form1)System.Windows.Forms.Application.OpenForms[0];

            f.Notificar($"El usuario {this} recibio la notificacion del producto {p}");


        }
    }
}
