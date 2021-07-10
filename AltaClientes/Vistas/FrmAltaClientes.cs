using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AltaClientes.AcessoDatos;
using AltaClientes.Entidades;
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
            cboEstatus.Text = "";
        }
        private void Limpiar1()
        {

            txtDomicilio.Clear();
            txtNombre.Clear();
            txtNumCasa.Clear();
            txtTelefono.Clear();
            cboEstatus.Text = "";
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
                string telefono = Convert.ToString(txtTelefono.Text).Replace("-", string.Empty);
                string fechanac = dtpFechaNacimiento.Value.ToString("yyyy/MM/dd");
                string domicilio = txtDomicilio.Text;
                int numinterior = int.Parse(txtNumCasa.Text);
                string estatus = cboEstatus.SelectedValue.ToString();
                MessageBox.Show(estatus);

                try
                {
                    if (altaclientesviewmodel.GuardarCliente(num, nombre, telefono, fechanac, domicilio, numinterior, estatus))
                    {
                        MessageBox.Show("Se guardó correctamente el usuario",
                                    "Guardar",
                                    MessageBoxButtons.OK);
                        Limpiar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudo guardar");

                }
                //}
            }
        }
        
        private void frmAltaClientes_Load(object sender, EventArgs e)
        {
            inicio();
            altaclientesviewmodel = new AltaClientesViewModel();
            cboAccion.Items.Add("Guardar");
            cboAccion.Items.Add("Modificar");
            
            cboEstatus.Items.Add("1");
            cboEstatus.Items.Add("0");
            
        }

      
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea realizar una nueva consulta?",
                "Limpiar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Limpiar();
                btnGuardar.Enabled = false;
            }
      
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
           
        }

        public void buscar()
        {
            DataTable dtUsuarios;

            dtUsuarios = altaclientesviewmodel.ConsultarUsuarios();

            if (dtUsuarios.Rows.Count > 0)
            {
                FrmBuscar frmBuscar = new FrmBuscar(dtUsuarios);

                var resultado = frmBuscar.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    string cod = frmBuscar.codigo;
                    string nom = frmBuscar.nombre;
                    string dom = frmBuscar.domicili;
                    string tel = frmBuscar.telefon;
                    string num = frmBuscar.numi;
                    string fec = frmBuscar.fech;
                    string opcac = frmBuscar.opc;

                    this.txtCodigo.Text = cod;
                    this.txtNombre.Text = nom;
                    this.txtDomicilio.Text = dom;
                    this.txtTelefono.Text = tel;
                    this.txtNumCasa.Text = num;
                    this.dtpFechaNacimiento.Text = fec;
                    this.cboEstatus.Text = opcac;
                }
            }
            else
            {
                MessageBox.Show("No se encontraron los datos"
                            , "Error"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Warning);
            }
        }

        public void inicio()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtNumCasa.Enabled = false;
            txtTelefono.Enabled = false;
            txtDomicilio.Enabled = false;
            txtNumCasa.Enabled = false;
            cboEstatus.Enabled = false;
            dtpFechaNacimiento.Enabled = false;
            btnGuardar.Enabled = false;
            btnBuscar.Enabled = false;



        }

        public void inicioGuardar()
        {
            txtNombre.Enabled = true;
            txtNumCasa.Enabled = true;
            txtTelefono.Enabled = true;
            txtDomicilio.Enabled = true;
            txtNumCasa.Enabled = true;
            cboEstatus.Enabled = true;
            dtpFechaNacimiento.Enabled = true;
            btnGuardar.Enabled = true;
            txtCodigo.Enabled = false;
            CargarEstatus();


        }

        public void inicioModificar()
        {
            btnBuscar.Enabled = true;
          
            CargarEstatus();


        }

        public void CodigoSiguiente() {

            DataTable dtultimoCodigo;
            dtultimoCodigo = altaclientesviewmodel.ultimoCodigo();


            string codigo = dtultimoCodigo.Rows[0]["numeroCliente"].ToString();
            txtCodigo.Text = codigo;
           

        }

        private void cboAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int indice = cboAccion.SelectedIndex;

            if (cboAccion.Text == "Guardar")
            {
                inicioGuardar();
                CodigoSiguiente();
                Limpiar1();
            }
            else
            {
                inicioModificar();
                Limpiar();
                ;

            }
        }
        private Boolean CargarEstatus()
        {
            Boolean resultado = false;
            DataTable dtEstatus;
            List<ComboBoxAlta> listaEstatus = new List<ComboBoxAlta>();

            dtEstatus = altaclientesviewmodel.cargarEstatus();

            if (dtEstatus != null)
            {

                foreach (DataRow dtRow in dtEstatus.Rows)
                {
                    listaEstatus.Add(new ComboBoxAlta
                    {
                        ID = dtRow[0].ToString().Trim(),
                        Descripcion = dtRow[1].ToString().Trim(),
                    });
                }

                cboEstatus.DataSource = listaEstatus;
                cboEstatus.ValueMember = "ID";
                cboEstatus.DisplayMember = "Descripcion";
                cboEstatus.SelectedIndex = -1;
                resultado = true;
            }

            return resultado;
        }



        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                MessageBox.Show("Ingrese solo números");
                return;
            }
        }

        private void txtNumCasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                MessageBox.Show("Ingrese solo números");
                return;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                MessageBox.Show("Ingrese solo letra");
                return;
            }
        }

        private void cboEstatus_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }
    }
}
