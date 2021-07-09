using AltaClientes.Modelos;
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

namespace AltaClientes.Vistas
{
    public partial class FrmBuscar : Form
    {

            DataTable tabla = new DataTable();
            public string codigo { get; set; }
            public string dom {get; set;}
        




        public FrmBuscar(DataTable dtClientes)
        {
            InitializeComponent();

            tabla = dtClientes;
            

        }


        private void FrmBuscar_Load(object sender, EventArgs e)
        {
            if (!LlenaGrid())
            {
                MessageBox.Show("Error");
            }
            this.dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.MultiSelect = false;
        }

        private void salir() {
            if (MessageBox.Show("¿Desea salir?",
                    "Salir",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Dispose();
            }


        }

        private Boolean LlenaGrid()
        {
            Boolean resultado = false;

            try
            {
                foreach (DataRow dtRow in tabla.Rows)
                {

                    
                        dgvClientes.Rows.Add(dtRow["num_cliente"].ToString(),
                                                     dtRow["nom_cliente"].ToString().ToUpper(),
                                                    dtRow["domicilio"].ToString().ToUpper());
                 

                }

                resultado = true;

            }
            catch
            {
                MessageBox.Show("No se abre la tabla"
                              , "Error"
                              , MessageBoxButtons.OK
                              , MessageBoxIcon.Warning);
            }

            return resultado;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

            buscar();

        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            buscar();

        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void buscar() {

            dgvClientes.Rows.Clear();



            foreach (DataRow dtRow in tabla.Rows)
            {
                if (dtRow["nom_cliente"].ToString().Contains(txtNombre.Text))
                {
                    dgvClientes.Rows.Add(dtRow["num_cliente"].ToString(),
                                                 dtRow["nom_cliente"].ToString().ToUpper(),
                                                dtRow["domicilio"].ToString().ToUpper());
                }
              

            }
        }
        public void devuelveDatos()
        {
            DataGridViewRow dr;
            string codigo;

            dr = dgvClientes.CurrentRow;

            codigo = dr.Cells[0].Value.ToString();
            dom = dr.Cells[1].ToString();




            this.codigo = codigo;
          
            

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            devuelveDatos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            buscar();
        }
    }
}
