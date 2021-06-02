
namespace CapaVista.Mantenimientos
{
    partial class frmSucursal
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
            this.navegador1 = new CapaVistaNavegador.Navegador();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblMuni = new System.Windows.Forms.Label();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.lblIdPais = new System.Windows.Forms.Label();
            this.lblNombreSucursal = new System.Windows.Forms.Label();
            this.lblIdEmpresa = new System.Windows.Forms.Label();
            this.lblIdSucursal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdSucursal = new System.Windows.Forms.TextBox();
            this.txtIdEmpresa = new System.Windows.Forms.TextBox();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.txtNombreSucursal = new System.Windows.Forms.TextBox();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.cmbPais = new System.Windows.Forms.ComboBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.txtMunicipalidad = new System.Windows.Forms.TextBox();
            this.cmbMunicipalidad = new System.Windows.Forms.ComboBox();
            this.rbHabilitado = new System.Windows.Forms.RadioButton();
            this.rbDeshabilitado = new System.Windows.Forms.RadioButton();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.dgvSucursal = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursal)).BeginInit();
            this.SuspendLayout();
            // 
            // navegador1
            // 
            this.navegador1.BackColor = System.Drawing.Color.Transparent;
            this.navegador1.Location = new System.Drawing.Point(16, 15);
            this.navegador1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.navegador1.Name = "navegador1";
            this.navegador1.Size = new System.Drawing.Size(1412, 103);
            this.navegador1.TabIndex = 38;
            this.navegador1.Load += new System.EventHandler(this.navegador1_Load);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(129, 400);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(139, 21);
            this.lblEstado.TabIndex = 26;
            this.lblEstado.Text = "Municipalidad";
            // 
            // lblMuni
            // 
            this.lblMuni.AutoSize = true;
            this.lblMuni.BackColor = System.Drawing.Color.Transparent;
            this.lblMuni.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMuni.Location = new System.Drawing.Point(129, 357);
            this.lblMuni.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMuni.Name = "lblMuni";
            this.lblMuni.Size = new System.Drawing.Size(136, 21);
            this.lblMuni.TabIndex = 25;
            this.lblMuni.Text = "Departamento";
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.BackColor = System.Drawing.Color.Transparent;
            this.lblDepartamento.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartamento.Location = new System.Drawing.Point(172, 316);
            this.lblDepartamento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(97, 21);
            this.lblDepartamento.TabIndex = 24;
            this.lblDepartamento.Text = "Direccion";
            // 
            // lblIdPais
            // 
            this.lblIdPais.AutoSize = true;
            this.lblIdPais.BackColor = System.Drawing.Color.Transparent;
            this.lblIdPais.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdPais.Location = new System.Drawing.Point(151, 278);
            this.lblIdPais.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdPais.Name = "lblIdPais";
            this.lblIdPais.Size = new System.Drawing.Size(116, 21);
            this.lblIdPais.TabIndex = 23;
            this.lblIdPais.Text = "Pais/Region";
            // 
            // lblNombreSucursal
            // 
            this.lblNombreSucursal.AutoSize = true;
            this.lblNombreSucursal.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreSucursal.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreSucursal.Location = new System.Drawing.Point(44, 231);
            this.lblNombreSucursal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreSucursal.Name = "lblNombreSucursal";
            this.lblNombreSucursal.Size = new System.Drawing.Size(217, 21);
            this.lblNombreSucursal.TabIndex = 22;
            this.lblNombreSucursal.Text = "Nombre De La Sucursal";
            // 
            // lblIdEmpresa
            // 
            this.lblIdEmpresa.AutoSize = true;
            this.lblIdEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.lblIdEmpresa.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdEmpresa.Location = new System.Drawing.Point(157, 186);
            this.lblIdEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdEmpresa.Name = "lblIdEmpresa";
            this.lblIdEmpresa.Size = new System.Drawing.Size(113, 21);
            this.lblIdEmpresa.TabIndex = 21;
            this.lblIdEmpresa.Text = "ID Empresa";
            // 
            // lblIdSucursal
            // 
            this.lblIdSucursal.AutoSize = true;
            this.lblIdSucursal.BackColor = System.Drawing.Color.Transparent;
            this.lblIdSucursal.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdSucursal.Location = new System.Drawing.Point(159, 142);
            this.lblIdSucursal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdSucursal.Name = "lblIdSucursal";
            this.lblIdSucursal.Size = new System.Drawing.Size(110, 21);
            this.lblIdSucursal.TabIndex = 20;
            this.lblIdSucursal.Text = "ID Sucursal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 446);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 21);
            this.label1.TabIndex = 39;
            this.label1.Text = "Estado";
            // 
            // txtIdSucursal
            // 
            this.txtIdSucursal.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdSucursal.Location = new System.Drawing.Point(284, 138);
            this.txtIdSucursal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdSucursal.Name = "txtIdSucursal";
            this.txtIdSucursal.Size = new System.Drawing.Size(237, 30);
            this.txtIdSucursal.TabIndex = 40;
            this.txtIdSucursal.Tag = "pkIdSucursal";
            // 
            // txtIdEmpresa
            // 
            this.txtIdEmpresa.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdEmpresa.Location = new System.Drawing.Point(284, 182);
            this.txtIdEmpresa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdEmpresa.Name = "txtIdEmpresa";
            this.txtIdEmpresa.Size = new System.Drawing.Size(68, 30);
            this.txtIdEmpresa.TabIndex = 41;
            this.txtIdEmpresa.Tag = "fkIdEmpresa";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpresa.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(361, 182);
            this.cmbEmpresa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(160, 29);
            this.cmbEmpresa.TabIndex = 42;
            this.cmbEmpresa.Tag = "saltar";
            this.cmbEmpresa.SelectedIndexChanged += new System.EventHandler(this.cmbEmpresa_SelectedIndexChanged);
            // 
            // txtNombreSucursal
            // 
            this.txtNombreSucursal.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreSucursal.Location = new System.Drawing.Point(284, 228);
            this.txtNombreSucursal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombreSucursal.Name = "txtNombreSucursal";
            this.txtNombreSucursal.Size = new System.Drawing.Size(237, 30);
            this.txtNombreSucursal.TabIndex = 43;
            this.txtNombreSucursal.Tag = "nombreSucursal";
            this.txtNombreSucursal.TextChanged += new System.EventHandler(this.txtNombreSucursal_TextChanged);
            this.txtNombreSucursal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreSucursal_KeyPress);
            // 
            // txtPais
            // 
            this.txtPais.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPais.Location = new System.Drawing.Point(284, 274);
            this.txtPais.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(68, 30);
            this.txtPais.TabIndex = 44;
            this.txtPais.Tag = "fkIdPais";
            // 
            // cmbPais
            // 
            this.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPais.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPais.FormattingEnabled = true;
            this.cmbPais.Location = new System.Drawing.Point(361, 274);
            this.cmbPais.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPais.Name = "cmbPais";
            this.cmbPais.Size = new System.Drawing.Size(160, 29);
            this.cmbPais.TabIndex = 45;
            this.cmbPais.Tag = "saltar";
            this.cmbPais.SelectedIndexChanged += new System.EventHandler(this.cmbPais_SelectedIndexChanged);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(284, 313);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(237, 30);
            this.txtDireccion.TabIndex = 46;
            this.txtDireccion.Tag = "direccionDeLugar";
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartamento.Location = new System.Drawing.Point(284, 353);
            this.txtDepartamento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(68, 30);
            this.txtDepartamento.TabIndex = 47;
            this.txtDepartamento.Tag = "fkIdDepar";
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(361, 353);
            this.cmbDepartamento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(160, 29);
            this.cmbDepartamento.TabIndex = 48;
            this.cmbDepartamento.Tag = "saltar";
            this.cmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamento_SelectedIndexChanged);
            // 
            // txtMunicipalidad
            // 
            this.txtMunicipalidad.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMunicipalidad.Location = new System.Drawing.Point(284, 400);
            this.txtMunicipalidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMunicipalidad.Name = "txtMunicipalidad";
            this.txtMunicipalidad.Size = new System.Drawing.Size(68, 30);
            this.txtMunicipalidad.TabIndex = 49;
            this.txtMunicipalidad.Tag = "fkIdMuni";
            // 
            // cmbMunicipalidad
            // 
            this.cmbMunicipalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMunicipalidad.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMunicipalidad.FormattingEnabled = true;
            this.cmbMunicipalidad.Location = new System.Drawing.Point(361, 400);
            this.cmbMunicipalidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbMunicipalidad.Name = "cmbMunicipalidad";
            this.cmbMunicipalidad.Size = new System.Drawing.Size(160, 29);
            this.cmbMunicipalidad.TabIndex = 50;
            this.cmbMunicipalidad.Tag = "saltar";
            this.cmbMunicipalidad.SelectedIndexChanged += new System.EventHandler(this.cmbMunicipalidad_SelectedIndexChanged);
            // 
            // rbHabilitado
            // 
            this.rbHabilitado.AutoSize = true;
            this.rbHabilitado.BackColor = System.Drawing.Color.Transparent;
            this.rbHabilitado.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHabilitado.Location = new System.Drawing.Point(212, 443);
            this.rbHabilitado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbHabilitado.Name = "rbHabilitado";
            this.rbHabilitado.Size = new System.Drawing.Size(123, 25);
            this.rbHabilitado.TabIndex = 51;
            this.rbHabilitado.TabStop = true;
            this.rbHabilitado.Text = "Habilitado";
            this.rbHabilitado.UseVisualStyleBackColor = false;
            this.rbHabilitado.CheckedChanged += new System.EventHandler(this.rbHabilitado_CheckedChanged);
            // 
            // rbDeshabilitado
            // 
            this.rbDeshabilitado.AutoSize = true;
            this.rbDeshabilitado.BackColor = System.Drawing.Color.Transparent;
            this.rbDeshabilitado.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDeshabilitado.Location = new System.Drawing.Point(355, 443);
            this.rbDeshabilitado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbDeshabilitado.Name = "rbDeshabilitado";
            this.rbDeshabilitado.Size = new System.Drawing.Size(155, 25);
            this.rbDeshabilitado.TabIndex = 52;
            this.rbDeshabilitado.TabStop = true;
            this.rbDeshabilitado.Text = "Deshabilitado";
            this.rbDeshabilitado.UseVisualStyleBackColor = false;
            this.rbDeshabilitado.CheckedChanged += new System.EventHandler(this.rbDeshabilitado_CheckedChanged);
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(33, 442);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(87, 22);
            this.txtEstado.TabIndex = 53;
            this.txtEstado.Tag = "estadoSucursal";
            // 
            // dgvSucursal
            // 
            this.dgvSucursal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSucursal.Location = new System.Drawing.Point(548, 142);
            this.dgvSucursal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvSucursal.Name = "dgvSucursal";
            this.dgvSucursal.ReadOnly = true;
            this.dgvSucursal.RowHeadersWidth = 51;
            this.dgvSucursal.Size = new System.Drawing.Size(831, 309);
            this.dgvSucursal.TabIndex = 54;
            // 
            // frmSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaVista.Properties.Resources.Mantenimiento_Centro_1141515;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1441, 575);
            this.Controls.Add(this.dgvSucursal);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.rbDeshabilitado);
            this.Controls.Add(this.rbHabilitado);
            this.Controls.Add(this.cmbMunicipalidad);
            this.Controls.Add(this.txtMunicipalidad);
            this.Controls.Add(this.cmbDepartamento);
            this.Controls.Add(this.txtDepartamento);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.cmbPais);
            this.Controls.Add(this.txtPais);
            this.Controls.Add(this.txtNombreSucursal);
            this.Controls.Add(this.cmbEmpresa);
            this.Controls.Add(this.txtIdEmpresa);
            this.Controls.Add(this.txtIdSucursal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.navegador1);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblMuni);
            this.Controls.Add(this.lblDepartamento);
            this.Controls.Add(this.lblIdPais);
            this.Controls.Add(this.lblNombreSucursal);
            this.Controls.Add(this.lblIdEmpresa);
            this.Controls.Add(this.lblIdSucursal);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSucursal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Sucursal";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CapaVistaNavegador.Navegador navegador1;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblMuni;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.Label lblIdPais;
        private System.Windows.Forms.Label lblNombreSucursal;
        private System.Windows.Forms.Label lblIdEmpresa;
        private System.Windows.Forms.Label lblIdSucursal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdSucursal;
        private System.Windows.Forms.TextBox txtIdEmpresa;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.TextBox txtNombreSucursal;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.ComboBox cmbPais;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.TextBox txtMunicipalidad;
        private System.Windows.Forms.ComboBox cmbMunicipalidad;
        private System.Windows.Forms.RadioButton rbHabilitado;
        private System.Windows.Forms.RadioButton rbDeshabilitado;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.DataGridView dgvSucursal;
    }
}