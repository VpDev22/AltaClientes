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
                    string telefono = txtTelefono.Text;
                    string fechanac = dtpFechaNacimiento.Value.ToString("yyyy/MM/dd");
                    string domicilio = txtDomicilio.Text;
                    int numinterior = int.Parse(txtNumCasa.Text);
                    int estatus = int.Parse(cboEstatus.Text);

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
        //Dictionary<string, int> integers = new Dictionary<string, int>();
        private void frmAltaClientes_Load(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            altaclientesviewmodel = new AltaClientesViewModel();
            cboAccion.Items.Add("Guardar");
            cboAccion.Items.Add("Modificar");
            //integers.Add(Text="Activo", value: 1);
            //integers.Add(Text="Inactivo", value: 0);
            cboEstatus.Items.Add(1);
            cboEstatus.Items.Add(0);

            //    var itemList = new List<Item>()
            //    {
            //        new Item() { Text = "Activo", Value = 1 },
            //        new Item() { Text = "Inactivo", Value = 0 }
            //    };

            //    cboEstatus.DataSource = itemList;
            //    cboEstatus.DisplayMember = "Text";
            //    cboEstatus.ValueMember = "Value";
            //}

            //public class Item
            //{
            //    public int Value { get; set; }
            //    public string Text { get; set; }
            //}
        }
            private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
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

        private void cboAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cboAccion.SelectedIndex;
            
            if (cboAccion.Text=="Guardar")
            {
                txtCodigo.Enabled = false;
                btnBuscar.Enabled = false;
                txtCodigo.Text = NumeroSiguiente().ToString();
                Limpiar1();  
            }
            else
            {
                Limpiar();
                btnBuscar.Enabled = true;
            }
        }

        private void cboEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int intValue = integers[(string)cboEstatus.SelectedItem];
            if (cboEstatus.Text == "1")
            {
                cboEstatus.Text = "Activo";
            }
            else if (cboEstatus.Text == "0")
            {
                cboEstatus.Text = "Inactivo";
            }
        }
    }
}
