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
        //private void Actualizar()
        //{
        //    //if (ValidaTodosLosCampos(Controles.TODOS))
        //    //{
        //    if (MessageBox.Show("¿Desea actualizar al usuario?",
        //        "Modificar",
        //        MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    {

        //        int num = int.Parse(txtCodigo.Text);
        //        string nombre = txtNombre.Text;
        //        int telefono = int.Parse(txtTelefono.Text);
        //        string fechanac = dtpFechaNacimiento.Value.ToString("yyyy/MM/dd");
        //        string domicilio = txtDomicilio.Text;
        //        int numinterior = int.Parse(txtNumCasa.Text);

        //        try
        //        {
        //            if (altaclientesviewmodel.ModificarCliente(num, nombre, telefono, fechanac, domicilio, numinterior))
        //            {
        //                MessageBox.Show("Se modificó correctamente el usuario",
        //                            "Modificar",
        //                            MessageBoxButtons.OK);
        //                Limpiar();
        //                //CargaCombos();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "No se pudo Modificar");

        //        }
        //        //}
        //    }
        //}
        //private void Deshabilita()
        //{
        //    //if (ValidaTodosLosCampos(Controles.TODOS))
        //    //{
        //    if (MessageBox.Show("¿Desea deshabilitar al usuario?",
        //        "Deshabilitar",
        //        MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    {

        //        int codigo = int.Parse(txtCodigo.Text);
                
        //        try
        //        {
        //            if (altaclientesviewmodel.DeshabilitarCliente(codigo))
        //            {
        //                MessageBox.Show("Se deshabilitó correctamente el usuario",
        //                            "Modificar",
        //                            MessageBoxButtons.OK);
        //                Limpiar();
        //                //CargaCombos();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "No se pudo deshabilitar");

        //        }
        //        //}
        //    }
        //}
        private void frmAltaClientes_Load(object sender, EventArgs e)
        {
            altaclientesviewmodel = new AltaClientesViewModel();
 

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

                    this.txtCodigo.Text = cod;
                    this.txtNombre.Text = nom;
                    this.txtDomicilio.Text = dom;
                    this.txtTelefono.Text = tel;
                    this.txtNumCasa.Text = num;
                    this.dtpFechaNacimiento.Text = fec;



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

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //    try
            //    {
            //        SqlConnection cnn = new SqlConnection(Program.CadenaConexionSqlServer);
            //        SqlCommand comando = new SqlCommand("select * from cat_clientes where num_cliente=" + txtCodigo.Text, cnn);
            //        cnn.Open();
            //        SqlDataReader myReader = comando.ExecuteReader();
            //        comando.Dispose();
                    
            //        if (myReader.HasRows)
            //        {
            //            while (myReader.Read())
            //            {
            //                txtNombre.Text = myReader.GetValue(1).ToString();
            //                txtTelefono.Text = myReader.GetValue(2).ToString();
            //                dtpFechaNacimiento.Text = myReader.GetValue(3).ToString();
            //                txtDomicilio.Text = myReader.GetValue(4).ToString();
            //                txtNumCasa.Text = myReader.GetValue(5).ToString();
            //            }

            //            txtNombre.Focus();
            //        }
            //        else
            //        {
            //        }
            //        myReader.Close();
            //        myReader.Dispose();
            //        cnn.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error:" + ex.Message);
            //    }
        }
    }
}
