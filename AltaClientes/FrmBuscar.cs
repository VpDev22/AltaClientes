using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AltaClientes
{
    public partial class FrmBuscar : Form
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string domicili { get; set; }
        public string telefon { get; set; }
        public string fech { get; set; }
        public string numi { get; set; }

        public FrmBuscar(DataTable dtUsuarios)
        {
            InitializeComponent();
            tabla = dtUsuarios;
        }

        private void FrmBuscar_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'pruebaDataSet.proc_CargarClientes' Puede moverla o quitarla según sea necesario.
            this.proc_CargarClientesTableAdapter.Fill(this.pruebaDataSet.proc_CargarClientes);
            if (!LlenaGrid())
            {
                this.Dispose();
            }
            
            

           
        }
        #region Elementos

        DataTable tabla = new DataTable();

        #endregion Elementos

   
        private Boolean LlenaGrid()
        {
            Boolean resultado = true;

            try
            {
                foreach (DataRow dtRow in tabla.Rows)
                {
               
                    dgvDatosCliente.Rows.Add(dtRow["num_cliente"].ToString().ToUpper(),
                                                 dtRow["nom_cliente"].ToString().ToUpper(),
                                                 dtRow["domicilio"].ToString().ToUpper(),
                                                 dtRow["telefono"].ToString().ToUpper(),
                                                 dtRow["num_interior"].ToString().ToUpper(),
                                                 dtRow["fec_nacimiento"].ToString().ToUpper());

                    this.dgvDatosCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    this.dgvDatosCliente.MultiSelect = false;



                    dgvDatosCliente.DataSource = tabla.DataSet;
                }

                resultado = true;

            }
            catch
            { }
            
            return resultado;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Salir();
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
        public void devuelveCliente()
        {
            DataGridViewRow dr;
            string codigo;
            string nombre;
            string domicilio;
            string telefono;
            string numinterior;
            string fechan;


            dr = dgvDatosCliente.CurrentRow;
            codigo = dr.Cells[0].Value.ToString();
            nombre = dr.Cells[1].Value.ToString();
            domicilio = dr.Cells[2].Value.ToString();
            telefono = dr.Cells[3].Value.ToString();
            fechan = dr.Cells[5].Value.ToString();     
            numinterior = dr.Cells[4].Value.ToString();
   
            this.codigo = codigo;
            this.nombre = nombre;
            this.telefon = telefono;
            this.fech = fechan;
            this.domicili = domicilio;
            this.numi = numinterior;
            //this.estatus = estatus;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            devuelveCliente();
        }

        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
             tabla.DefaultView.RowFilter = $"Nombre LIKE '{txtBuscarNombre.Text}%'";
        }

        private void dgvDatosCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtBuscarNombre.Text = dgvDatosCliente.CurrentRow.Cells["Nombre"].Value.ToString();
        }
    }
}
