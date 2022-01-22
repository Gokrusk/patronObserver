using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace patronObserver
{
    public partial class Form1 : Form
    {
        public void Notificar(string s)
        {
            this.lstNotificaciones.Items.Add(s);
        }

        private List<interfaceSujetoProducto> _productos;
        private List<interfaceObserverUsuario> _usuarios;

        private interfaceSujetoProducto _producto;
        private interfaceObserverUsuario _usuario;

        public Form1()
        {
            InitializeComponent();

            _productos = new List<interfaceSujetoProducto>();
            _usuarios = new List<interfaceObserverUsuario>();
            agregarDatos();
        }

        private void agregarDatos()
        {
            //Agregando medicamentos
            _productos.Add(new producto("Paracetamol", 10));
            _productos.Add(new producto("Penicilina", 5));
            _productos.Add(new producto("Loratadina", 7));
            //Agregando usuarios
            _usuarios.Add(new usuario("Nigell", "Jama"));
            _usuarios.Add(new usuario("Omar", "Grefa"));
            _usuarios.Add(new usuario("Joseph", "Gonzalez"));
            //Mostrando en listbox
            mostrarProductos();
            mostrarUsuarios();
        }

        private void mostrarProductos()
        {
            this.lstProductos.DataSource = null;
            this.lstProductos.DataSource = _productos;
        }

        private void mostrarUsuarios()
        {
            this.lstUsuarios.DataSource = null;
            this.lstUsuarios.DataSource = _usuarios;
        }

        private void lstProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _producto = (interfaceSujetoProducto)((ListBox)sender).SelectedItem;
        }

        private void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            _usuario = (interfaceObserverUsuario)((ListBox)sender).SelectedItem;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(_producto!=null && _usuario != null)
            {
                try
                {
                    _producto.Agregar(_usuario);
                    MessageBox.Show("Suscripción correcta");

                }
                catch (Exception ee)
                {

                    MessageBox.Show(ee.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto y un usuario");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_producto != null && _usuario != null)
            {
                try
                {
                    _producto.Quitar(_usuario);
                    MessageBox.Show("Desuscripción correcta");

                }
                catch (Exception ee)
                {

                    MessageBox.Show(ee.Message);
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar producto y usuario");
            }
        }

        private void lstProductos_DoubleClick(object sender, EventArgs e)
        {
            double p;

            if (double.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nuevo precio: "), out p))
            {
                ((producto)_producto).Precio = p;
                mostrarProductos();
            }
        }

    }
}
