
namespace CapaVista.Procesos.Inventarios
{
    partial class frmVistaMovimientoInventario
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
            this.dgvMovimiento = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.Filtros = new System.Windows.Forms.GroupBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.rbUsuario = new System.Windows.Forms.RadioButton();
            this.txtBodega = new System.Windows.Forms.TextBox();
            this.rbBodega = new System.Windows.Forms.RadioButton();
            this.txtRazon = new System.Windows.Forms.TextBox();
            this.rbRazon = new System.Windows.Forms.RadioButton();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.rbProducto = new System.Windows.Forms.RadioButton();
            this.btnFiltrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimiento)).BeginInit();
            this.Filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMovimiento
            // 
            this.dgvMovimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvMovimiento.Location = new System.Drawing.Point(16, 139);
            this.dgvMovimiento.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMovimiento.Name = "dgvMovimiento";
            this.dgvMovimiento.RowHeadersWidth = 51;
            this.dgvMovimiento.Size = new System.Drawing.Size(1591, 466);
            this.dgvMovimiento.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID MOVIMIENTO";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ID PRODUCTO";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "NOMBRE PRODUCTO";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ID BODEGA";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ID BODEGA DESTINO";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "CANTIDAD";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "RAZON";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "ENCARGADO";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(973, 626);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(140, 39);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.White;
            this.btnActualizar.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(819, 626);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(140, 39);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(663, 626);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(140, 39);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // Filtros
            // 
            this.Filtros.BackColor = System.Drawing.Color.Transparent;
            this.Filtros.Controls.Add(this.txtUsuario);
            this.Filtros.Controls.Add(this.rbUsuario);
            this.Filtros.Controls.Add(this.txtBodega);
            this.Filtros.Controls.Add(this.rbBodega);
            this.Filtros.Controls.Add(this.txtRazon);
            this.Filtros.Controls.Add(this.rbRazon);
            this.Filtros.Controls.Add(this.txtProducto);
            this.Filtros.Controls.Add(this.rbProducto);
            this.Filtros.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filtros.ForeColor = System.Drawing.Color.White;
            this.Filtros.Location = new System.Drawing.Point(16, 26);
            this.Filtros.Margin = new System.Windows.Forms.Padding(4);
            this.Filtros.Name = "Filtros";
            this.Filtros.Padding = new System.Windows.Forms.Padding(4);
            this.Filtros.Size = new System.Drawing.Size(1591, 106);
            this.Filtros.TabIndex = 4;
            this.Filtros.TabStop = false;
            this.Filtros.Text = "Filtros";
            this.Filtros.Enter += new System.EventHandler(this.Filtros_Enter);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(543, 57);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(132, 27);
            this.txtUsuario.TabIndex = 7;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // rbUsuario
            // 
            this.rbUsuario.AutoSize = true;
            this.rbUsuario.Location = new System.Drawing.Point(543, 28);
            this.rbUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.rbUsuario.Name = "rbUsuario";
            this.rbUsuario.Size = new System.Drawing.Size(91, 24);
            this.rbUsuario.TabIndex = 6;
            this.rbUsuario.TabStop = true;
            this.rbUsuario.Text = "Usuario";
            this.rbUsuario.UseVisualStyleBackColor = true;
            // 
            // txtBodega
            // 
            this.txtBodega.Location = new System.Drawing.Point(389, 57);
            this.txtBodega.Margin = new System.Windows.Forms.Padding(4);
            this.txtBodega.Name = "txtBodega";
            this.txtBodega.Size = new System.Drawing.Size(132, 27);
            this.txtBodega.TabIndex = 5;
            this.txtBodega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBodega_KeyPress);
            // 
            // rbBodega
            // 
            this.rbBodega.AutoSize = true;
            this.rbBodega.Location = new System.Drawing.Point(389, 28);
            this.rbBodega.Margin = new System.Windows.Forms.Padding(4);
            this.rbBodega.Name = "rbBodega";
            this.rbBodega.Size = new System.Drawing.Size(89, 24);
            this.rbBodega.TabIndex = 4;
            this.rbBodega.TabStop = true;
            this.rbBodega.Text = "Bodega";
            this.rbBodega.UseVisualStyleBackColor = true;
            // 
            // txtRazon
            // 
            this.txtRazon.Location = new System.Drawing.Point(225, 57);
            this.txtRazon.Margin = new System.Windows.Forms.Padding(4);
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.Size = new System.Drawing.Size(132, 27);
            this.txtRazon.TabIndex = 3;
            this.txtRazon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRazon_KeyPress);
            // 
            // rbRazon
            // 
            this.rbRazon.AutoSize = true;
            this.rbRazon.Location = new System.Drawing.Point(225, 28);
            this.rbRazon.Margin = new System.Windows.Forms.Padding(4);
            this.rbRazon.Name = "rbRazon";
            this.rbRazon.Size = new System.Drawing.Size(77, 24);
            this.rbRazon.TabIndex = 2;
            this.rbRazon.TabStop = true;
            this.rbRazon.Text = "Razon";
            this.rbRazon.UseVisualStyleBackColor = true;
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(57, 57);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(4);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(132, 27);
            this.txtProducto.TabIndex = 1;
            this.txtProducto.TextChanged += new System.EventHandler(this.txtProducto_TextChanged);
            this.txtProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProducto_KeyPress);
            // 
            // rbProducto
            // 
            this.rbProducto.AutoSize = true;
            this.rbProducto.Location = new System.Drawing.Point(57, 28);
            this.rbProducto.Margin = new System.Windows.Forms.Padding(4);
            this.rbProducto.Name = "rbProducto";
            this.rbProducto.Size = new System.Drawing.Size(101, 24);
            this.rbProducto.TabIndex = 0;
            this.rbProducto.TabStop = true;
            this.rbProducto.Text = "Producto";
            this.rbProducto.UseVisualStyleBackColor = true;
            this.rbProducto.CheckedChanged += new System.EventHandler(this.rbProducto_CheckedChanged);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.White;
            this.btnFiltrar.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.Location = new System.Drawing.Point(515, 626);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(140, 39);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // frmVistaMovimientoInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaVista.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(1623, 681);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.Filtros);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvMovimiento);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmVistaMovimientoInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVistaMovimientoInventario";
            this.Load += new System.EventHandler(this.frmVistaMovimientoInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimiento)).EndInit();
            this.Filtros.ResumeLayout(false);
            this.Filtros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMovimiento;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox Filtros;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.RadioButton rbProducto;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.RadioButton rbUsuario;
        private System.Windows.Forms.TextBox txtBodega;
        private System.Windows.Forms.RadioButton rbBodega;
        private System.Windows.Forms.TextBox txtRazon;
        private System.Windows.Forms.RadioButton rbRazon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}