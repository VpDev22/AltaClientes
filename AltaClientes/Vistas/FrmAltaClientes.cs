using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using AltaClientes.AcessoDatos;
using AltaClientes.Entidades;
using AltaClientes.Modelos;


namespace AltaClientes
{
    public partial class frmAltaClientes : Form
    {
        #region Elementos

        private AltaClientesViewModel altaclientesviewmodel;
        private ToolTip toolTip;
        private Regex caracterValido = new Regex(@"[^a-zA-Z0-9]");

        #endregion Elementos
       



        #region Constructor
        public frmAltaClientes()
        {
            InitializeComponent();
        }

        #endregion Constructor


        private void frmAltaClientes_Load(object sender, EventArgs e)
        {
            inicio();
            altaclientesviewmodel = new AltaClientesViewModel();
            cboAccion.Items.Add("Guardar");
            cboAccion.Items.Add("Modificar");

            //cboEstatus.Items.Add("1");
            //cboEstatus.Items.Add("0");
            Regex x = new Regex(@"[^a-zA-Z]");

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }



        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaAlfanumerico(e);

        }

        private void txtNumCasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaAlfanumerico(e);

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

    

        private void cboEstatus_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }
        private void cboAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int indice = cboAccion.SelectedIndex;

            if (cboAccion.Text == "Guardar")
            {

                CodigoSiguiente();
                Limpiar1();
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
                txtNombre.Focus();

            }
            else
            {
                Limpiar();
                btnBuscar.Enabled = true;
                txtCodigo.Enabled = true;
                txtNombre.Enabled = true;
                txtTelefono.Enabled = true;
                dtpFechaNacimiento.Enabled = true;
                txtDomicilio.Enabled = true;
                txtNumCasa.Enabled = true;
                cboEstatus.Enabled = true;
                btnGuardar.Enabled = true;
                btnBuscar.Focus();
                CargarEstatus();

            }
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

        #region Métodos privados



        private void ValidaAlfanumerico(KeyPressEventArgs e)
        {
            if (caracterValido.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        private void Limpiar()
        {
            txtCodigo.Clear();
            txtDomicilio.Clear();
            txtNombre.Clear();
            txtNumCasa.Clear();
            txtTelefono.Clear();
            cboEstatus.Text = "";
            txtTelefono.ForeColor = Color.Black;
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
            if (ValidaTodosLosCampos(Controles.TODOS))
            {
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
                }
            }
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
        private Boolean ValidaTodosLosCampos(Controles control)
        {
            Boolean bRegresa = true;

            for (int iControl = 0; iControl < (int)control; iControl++)
            {
                if (!ValidaCampo((Controles)iControl))
                {
                    bRegresa = false;
                    break;
                }
            }

            return bRegresa;
        }

        public Boolean ValidaCampo(Controles control)
        {
            Boolean regresa = true;

            switch (control)
            {
                case Controles.TB_NOMBRE:
                    {
                        if (String.IsNullOrWhiteSpace(txtNombre.Text))
                        {
                            toolTip = new ToolTip();
                            toolTip.ToolTipIcon = ToolTipIcon.Info;
                            toolTip.Show("Ingrese nombre", txtNombre, 1100);
                            txtNombre.Focus();
                            regresa = false;
                            txtNombre.ForeColor = Color.DarkRed;
                            txtNombre.Focus();
                            regresa = false;
                        }
                        else
                        {
                            txtNombre.ForeColor = Color.Green;

                        }
                    }
                    break;


                

                case Controles.TB_TELEFONO:

                   
                    string texto1 = txtTelefono.Text;
                    texto1 = texto1.Replace(" ", String.Empty);
                    string texto = "   -   -    ";
                    texto = texto.Replace(" ", String.Empty);


                    if ( texto == texto1 )
                    {
                        toolTip = new ToolTip();
                        toolTip.ToolTipIcon = ToolTipIcon.Info;
                        toolTip.Show("Ingrese numero telefonico", txtTelefono, 1100);
                        txtTelefono.Focus();
                        txtDomicilio.ForeColor = Color.DarkRed;
                        regresa = false;
                        
                    }
                    else
                    {
                        txtTelefono.ForeColor = Color.Green;

                    }
                    break;

                case Controles.TB_DOMICILIO:
                    {
                        if (String.IsNullOrWhiteSpace(txtDomicilio.Text))
                        {
                            toolTip = new ToolTip();
                            toolTip.ToolTipIcon = ToolTipIcon.Info;
                            toolTip.Show("Ingrese domicilio", txtDomicilio, 1100);
                            txtDomicilio.Focus();
                            txtDomicilio.ForeColor = Color.DarkRed;
                            txtDomicilio.Focus();
                            regresa = false;
                        }
                        else
                        {
                            txtDomicilio.ForeColor = Color.Green;

                        }
                    }
                    break;

                case Controles.DTP_FECHANACIMIENTO:

                    int fecha;
                    int fechaHoy;

                    fecha = Int32.Parse(dtpFechaNacimiento.Value.Date.ToString("yyyy"));
                    fechaHoy = Int32.Parse(DateTime.Now.ToString("yyyy"));

                    if (fecha >= fechaHoy - 18 ) 
                    {
                        toolTip = new ToolTip();
                        toolTip.ToolTipIcon = ToolTipIcon.Info;
                        toolTip.Show("Fecha incorrecta", dtpFechaNacimiento, 1100);
                        dtpFechaNacimiento.Focus();
                        dtpFechaNacimiento.ForeColor = Color.DarkRed;
                        regresa = false;
                    }
                    else
                    {
                        dtpFechaNacimiento.CalendarForeColor = Color.Green;

                    }

                    break;

                case Controles.TB_INTERIOR:
                    {
                        if (String.IsNullOrWhiteSpace(txtDomicilio.Text))
                        {
                            toolTip = new ToolTip();
                            toolTip.ToolTipIcon = ToolTipIcon.Info;
                            toolTip.Show("Ingrese domicilio", txtNumCasa, 1100);
                            txtNumCasa.Focus();
                            txtNumCasa.ForeColor = Color.DarkRed;
                            regresa = false;
                        }
                        else
                        {
                            txtDomicilio.ForeColor = Color.Green;

                        }
                    }
                    break;



            }

            return regresa;
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
        

        public void CodigoSiguiente() {

            DataTable dtultimoCodigo;
            dtultimoCodigo = altaclientesviewmodel.ultimoCodigo();


            string codigo = dtultimoCodigo.Rows[0]["numeroCliente"].ToString();
            txtCodigo.Text = codigo;
           

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

        #endregion Métodos privados


        #region Métodos para el control del foco en el formulario

        /// <summary>
        /// Método para detectar la tecla pulsada dentro del formulario (dialogo)
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F10:
                    Guardar();
                    return true;

                case Keys.Escape:
                    Salir();
                    return true;

                case Keys.Tab:
                    NextCtrl();
                    return true;

                case Keys.PageDown:
                    SendKeys.Send("{DOWN}");
                    return true;

                case Keys.PageUp:
                    SendKeys.Send("{UP}");
                    return true;

                default:
                    if (keyData == (Keys.Shift | Keys.Tab))
                    {
                        try
                        {
                            PrevCtrl();
                            return true;

                        }
                        catch
                        {
                            NextCtrl();
                            return true;
                        }
                    }
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Salta al siguiente control dependiento del order de tabulacion.
        /// </summary>
        private void NextCtrl()
        {
            this.SelectNextControl(ActiveControl, true, true, true, true);
        }

        /// <summary>
        /// Regresa al control dependiento del order de tabulacion.
        /// </summary>
        private void PrevCtrl()
        {
            this.SelectNextControl(ActiveControl, false, true, true, true);
        }



        #endregion Métodos para el control del foco en el formulario

        
    }
}
