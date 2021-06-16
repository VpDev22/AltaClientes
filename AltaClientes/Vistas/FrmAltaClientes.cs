using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AltaClientes.Clases;

using AltaClientes.Modelos;
using System.Text.RegularExpressions;

namespace AltaClientes
{
    public partial class frmAltaClientes : Form
    {
        #region Elementos

        private AltaClientesViewModel asignarUsuarioViewModel;
        private ToolTip toolTip;
        private Regex caracterValido = new Regex(@"[^a-zA-Z0-9]");

        #endregion Elementos

        public frmAltaClientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Guardar()
        {
            if (ValidaTodosLosCampos(Controles.TODOS))
            {
                if (MessageBox.Show("¿Desea registrar al usuario?",
                    "Guardar",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    UsuarioInfo usuario = new UsuarioInfo();
                    usuario.NumeroUsuario = cbColaborador.SelectedValue.ToString();
                    usuario.NombreUsuario = txtUsuario.Text.Encrypt();
                    usuario.PassUsuario = txtPassword.Text.Encrypt();
                    usuario.RolUsuario = cbRol.SelectedValue.ToString();

                    if (asignarUsuarioViewModel.GuardarUsuario(usuario))
                    {
                        MessageBox.Show("Se guardó correctamente el usuario",
                                    "Guardar",
                                    MessageBoxButtons.OK);
                        Limpiar();
                        CargaCombos();
                    }

                }
            }
        }
    }
}
