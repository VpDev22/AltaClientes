using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AltaClientes.AcessoDatos;
using AltaClientes.Modelos;


namespace AltaClientes
{
    public partial class frmAltaClientes : Form
    {
        private AltaClientesViewModel altaclientesviewmodel;
        public frmAltaClientes()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void Limpiar()
        {
            txtCodigo.Clear();
            txtDomicilio.Clear();
            txtNombre.Clear();
            txtNumCasa.Clear();
            txtTelefono.Clear();
        }
        private void Salir()
        {
            if (MessageBox.Show("¿Desea salir del formulario?",
                     "Salir",
                     MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
        private void Guardar()
        {
            //if (ValidaTodosLosCampos(Controles.TODOS))
            //{
                if (MessageBox.Show("¿Desea registrar al usuario?",
                    "Guardar",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    int num = int.Parse(txtCodigo.Text);
                    string nombre = txtNombre.Text;
                    int telefono = int.Parse(txtTelefono.Text);
                    string fechanac = dtpFechaNacimiento.Value.ToString("yyyy/MM/dd");
                    string domicilio = txtDomicilio.Text;
                    int numinterior = int.Parse(txtNumCasa.Text);

                try
                {
                    if (altaclientesviewmodel.GuardarCliente(num, nombre, telefono, fechanac, domicilio, numinterior))
                    {
                        MessageBox.Show("Se guardó correctamente el usuario",
                                    "Guardar",
                                    MessageBoxButtons.OK);
                        Limpiar();
                        //CargaCombos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudo guardar");
                    
                }
                
                
                   

                //}
            }
        }
        private void Actualizar()
        {
            //if (ValidaTodosLosCampos(Controles.TODOS))
            //{
            if (MessageBox.Show("¿Desea actualizar al usuario?",
                "Modificar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                int num = int.Parse(txtCodigo.Text);
                string nombre = txtNombre.Text;
                int telefono = int.Parse(txtTelefono.Text);
                string fechanac = dtpFechaNacimiento.Value.ToString("yyyy/MM/dd");
                string domicilio = txtDomicilio.Text;
                int numinterior = int.Parse(txtNumCasa.Text);

                try
                {
                    if (altaclientesviewmodel.ModificarCliente(num, nombre, telefono, fechanac, domicilio, numinterior))
                    {
                        MessageBox.Show("Se modificó correctamente el usuario",
                                    "Modificar",
                                    MessageBoxButtons.OK);
                        Limpiar();
                        //CargaCombos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudo Modificar");

                }




                //}
            }
        }
        private void Deshabilita()
        {
            //if (ValidaTodosLosCampos(Controles.TODOS))
            //{
            if (MessageBox.Show("¿Desea deshabilitar al usuario?",
                "Deshabilitar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                int codigo = int.Parse(txtCodigo.Text);
                
                try
                {
                    if (altaclientesviewmodel.DeshabilitarCliente(codigo))
                    {
                        MessageBox.Show("Se deshabilitó correctamente el usuario",
                                    "Modificar",
                                    MessageBoxButtons.OK);
                        Limpiar();
                        //CargaCombos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudo deshabilitar");

                }




                //}
            }
        }
        private void frmAltaClientes_Load(object sender, EventArgs e)
        {
            altaclientesviewmodel = new AltaClientesViewModel();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            Deshabilita();
        }
    }
}
