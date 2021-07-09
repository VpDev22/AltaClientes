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
using AltaClientes.Entidades;
using AltaClientes.Modelos;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data.SqlClient;
using AltaClientes.Vistas;

namespace AltaClientes
{
    public partial class frmAltaClientes : Form
    {
        #region Elementos

        private AltaClientesViewModel altaClientesViewModel;

        //private ToolTip toolTip;
        private Regex caracterValido = new Regex(@"[^a-zA-Z0-9]");

        #endregion Elementos
        #region Constructor
        public frmAltaClientes()
        {
            InitializeComponent();
        }

        #endregion Constructor



        #region Eventos
        private void frmAltaClientes_Load(object sender, EventArgs e)
        {

            altaClientesViewModel = new AltaClientesViewModel();
            Regex x = new Regex(@"[^a-zA-Z]");
            cboAccion.Items.Add("Guardar");
            cboAccion.Items.Add("Modificar");
            MessageBox.Show(NumeroSiguiente().ToString());
            btnBuscar.Enabled = false;
            Regex telefono = new Regex(@"[^a-zA-Z]");


        }


        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {


        }


        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void txtDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void txtNumCasa_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {

           

        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {

        }

        private void txtTelefono_Enter(object sender, EventArgs e)
        {


        }         
    

        private void txtDomicilio_Enter(object sender, EventArgs e)
        {

        }

        private void txtNumCasa_Enter(object sender, EventArgs e)
        {
            //ValidaTodosLosCampos(Controles.TB_INTERIOR);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Salir();

        }
        #endregion Eventos

        #region Métodos privados


        //private Boolean ValidaTodosLosCampos(Controles control)
        //{
        //    Boolean bRegresa = true;

        //    for (int iControl = 0; iControl < (int)control; iControl++)
        //    {
        //        if (!ValidaCampo((Controles)iControl))
        //        {
        //            bRegresa = false;
        //            break;
        //        }
        //    }

        //    return bRegresa;
        //}

        //public Boolean ValidaCampo(Controles control)
        //{
        //    Boolean regresa = true;

        //    switch (control)
        //    {
        //        //agregar cases validador de cada text
        //        case Controles.TB_CODIGO:
        //            {
        //                if (String.IsNullOrWhiteSpace(txtCodigo.Text))
        //                {
        //                    toolTip = new ToolTip();
        //                    toolTip.ToolTipIcon = ToolTipIcon.Info;
        //                    toolTip.Show("Ingrese nombre de usuario", txtCodigo, 1100);
        //                    txtCodigo.Focus();
        //                    regresa = false;
        //                }
        //                else { }

        //            }
        //            break;


        //    }

        //    return regresa;
        //}

        private void Salir()
        {
            if (MessageBox.Show("¿Desea salir de registro de usuarios?",
                     "Salir",
                     MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void Guardar()
        {

            if (MessageBox.Show("¿Desea registrar al usuario?",
                "Guardar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

               
                int codigo = Convert.ToInt32(txtCodigo.Text);
                string nombre = txtNombre.Text;
                string telefono = Convert.ToString(txtTelefono.Text).Replace("-", string.Empty);
                string fecha = dtpFechaNacimiento.Value.ToString("yyyy/MM/dd");
                string domicilio = txtDomicilio.Text;
                int numero = int.Parse(txtNumCasa.Text);
                int estatus = 1;







                if (altaClientesViewModel.AltaCliente(codigo, nombre, telefono, fecha, domicilio, numero, estatus))
                    {
                        MessageBox.Show("Se guardó correctamente el usuario",
                                    "Guardar",
                                    MessageBoxButtons.OK);
                        Limpiar();

                    }

                }
            
        }
       
        public int NumeroSiguiente()
        {
            SqlConnection cnn = new SqlConnection(Program.CadenaConexionSqlServer);
            SqlCommand cmd = new SqlCommand("Select max(num_cliente) from cat_clientes");
            cmd.Connection = cnn;
            try
            {
                cnn.Open();
                object res = cmd.ExecuteScalar();
                if (res == System.DBNull.Value)
                    return 0;
                else
                {
                    return Convert.ToInt32(res) + 1;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
           
            return 0;
        }

        private void Deshabilitar()
        {
           
                if (MessageBox.Show("¿Desea modificar al usuario?",
                    "Guardar",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {



                    int codigo = Convert.ToInt32(txtCodigo.Text);


                    //MessageBox.Show(fecha);

                    if (altaClientesViewModel.DeshabilitarClientes(codigo))
                    {
                        MessageBox.Show("Se deshabilito correctamente el usuario",
                                    "Guardar",
                                    MessageBoxButtons.OK);
                        Limpiar();

                    }

                }
            
        }
        //private void ValidaAlfanumerico(KeyPressEventArgs e)
        //{
        //    if (caracterValido.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
        //    {
        //        e.Handled = true;
        //        return;
        //    }
        //}




        private void Limpiar()

        {


            txtCodigo.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtDomicilio.Clear();
            txtNumCasa.Clear();
            cboAccion.Text = "";

            txtCodigo.Focus();
        }

        private void Limpiar1()

        {


            txtNombre.Clear();
            txtTelefono.Clear();
            txtDomicilio.Clear();
            txtNumCasa.Clear();
            cboAccion.Text = "";
                txtNombre.Focus();
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        


       

        public void btnBuscar_Click(object sender, EventArgs e)
        {

            buscar();
            
            
        }

        public void buscar()
        {
           
            DataTable dtClientes;

            dtClientes = altaClientesViewModel.CargarClientes();

            if (dtClientes.Rows.Count > 0)
            {
                FrmBuscar frmBuscar = new FrmBuscar(dtClientes);

                var resultado = frmBuscar.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    string val1 = frmBuscar.codigo;
                    this.txtCodigo.Text = val1;

                    SqlConnection cnn = new SqlConnection(Program.CadenaConexionSqlServer);
                    SqlCommand comando = new SqlCommand($"EXEC prueba.dbo.proc_BuscarDatosCliente  @codigo =" + txtCodigo.Text, cnn);
                    cnn.Open();
                    SqlDataReader myReader = comando.ExecuteReader();
                    comando.Dispose();
                    
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            txtNombre.Text = myReader.GetValue(1).ToString();
                            txtTelefono.Text = myReader.GetValue(2).ToString();
                            dtpFechaNacimiento.Text = myReader.GetValue(3).ToString();
                            txtDomicilio.Text = myReader.GetValue(4).ToString();
                            txtNumCasa.Text = myReader.GetValue(5).ToString();
                           cboEstatus.Text = myReader.GetValue(6).ToString();
                            if (cboEstatus.Text == "1")  {
                                cboEstatus.DisplayMember = "Activo";
                                cboEstatus.ValueMember = "1" ;

                            }

                            else {
                                cboEstatus.DisplayMember = "Inactivo";
                                cboEstatus.ValueMember = "0";
                            }

                        }
                      

                    }
                    else { }

                }
            }
            else
            {
                MessageBox.Show("No se encontraron los datos de totales por estatus"
                            , "Error"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Warning);
            }
        }

        private void cboAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cboAccion.SelectedIndex;

            if (cboAccion.Text == "Guardar")
            {
                txtCodigo.Enabled = false;
                btnBuscar.Enabled = false;
                txtCodigo.Text = NumeroSiguiente().ToString();
                Limpiar1();
            }
            else {
                Limpiar();
                btnBuscar.Enabled = true; 
            }



        }

        private void cboEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //if (cboEstatus.ValueMember == "1")
            //{
            //    estatus = 1;
            //}

            //else
            //{
            //    estatus = 0;
            //}

            
        }
    }



}


