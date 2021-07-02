namespace AltaClientes
{
    partial class FrmBuscar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarNombre = new System.Windows.Forms.TextBox();
            this.dgvDatosCliente = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pruebaDataSet = new AltaClientes.pruebaDataSet();
            this.procCargarClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proc_CargarClientesTableAdapter = new AltaClientes.pruebaDataSetTableAdapters.proc_CargarClientesTableAdapter();
            this.num_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fec_nacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_interior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pruebaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.procCargarClientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.Location = new System.Drawing.Point(206, 26);
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(100, 26);
            this.txtBuscarNombre.TabIndex = 6;
            // 
            // dgvDatosCliente
            // 
            this.dgvDatosCliente.AllowUserToAddRows = false;
            this.dgvDatosCliente.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatosCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatosCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num_cliente,
            this.nom_cliente,
            this.domicilio,
            this.fec_nacimiento,
            this.telefono,
            this.num_interior});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatosCliente.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatosCliente.Location = new System.Drawing.Point(12, 80);
            this.dgvDatosCliente.Name = "dgvDatosCliente";
            this.dgvDatosCliente.ReadOnly = true;
            this.dgvDatosCliente.RowTemplate.Height = 28;
            this.dgvDatosCliente.Size = new System.Drawing.Size(552, 312);
            this.dgvDatosCliente.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(390, 415);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(78, 33);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(474, 415);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 33);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pruebaDataSet
            // 
            this.pruebaDataSet.DataSetName = "pruebaDataSet";
            this.pruebaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // procCargarClientesBindingSource
            // 
            this.procCargarClientesBindingSource.DataMember = "proc_CargarClientes";
            this.procCargarClientesBindingSource.DataSource = this.pruebaDataSet;
            // 
            // proc_CargarClientesTableAdapter
            // 
            this.proc_CargarClientesTableAdapter.ClearBeforeFill = true;
            // 
            // num_cliente
            // 
            this.num_cliente.HeaderText = "Codigo Cliente";
            this.num_cliente.Name = "num_cliente";
            this.num_cliente.ReadOnly = true;
            this.num_cliente.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.num_cliente.Visible = false;
            // 
            // nom_cliente
            // 
            this.nom_cliente.HeaderText = "Nombre Cliente";
            this.nom_cliente.Name = "nom_cliente";
            this.nom_cliente.ReadOnly = true;
            this.nom_cliente.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.nom_cliente.Width = 150;
            // 
            // domicilio
            // 
            this.domicilio.HeaderText = "Domicilio";
            this.domicilio.Name = "domicilio";
            this.domicilio.ReadOnly = true;
            this.domicilio.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.domicilio.Width = 150;
            // 
            // fec_nacimiento
            // 
            this.fec_nacimiento.HeaderText = "Fecha Nacimiento";
            this.fec_nacimiento.Name = "fec_nacimiento";
            this.fec_nacimiento.ReadOnly = true;
            this.fec_nacimiento.Visible = false;
            // 
            // telefono
            // 
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            this.telefono.Visible = false;
            // 
            // num_interior
            // 
            this.num_interior.HeaderText = "Numero Interior";
            this.num_interior.Name = "num_interior";
            this.num_interior.ReadOnly = true;
            this.num_interior.Visible = false;
            // 
            // FrmBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 474);
            this.ControlBox = false;
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvDatosCliente);
            this.Controls.Add(this.txtBuscarNombre);
            this.Controls.Add(this.label1);
            this.Name = "FrmBuscar";
            this.Text = "Buscar Clientes";
            this.Load += new System.EventHandler(this.FrmBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pruebaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.procCargarClientesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscarNombre;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
        private pruebaDataSet pruebaDataSet;
        private System.Windows.Forms.BindingSource procCargarClientesBindingSource;
        private pruebaDataSetTableAdapters.proc_CargarClientesTableAdapter proc_CargarClientesTableAdapter;
        private System.Windows.Forms.DataGridView dgvDatosCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn domicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fec_nacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_interior;
    }
}