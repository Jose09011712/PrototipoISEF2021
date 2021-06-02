
namespace CapaVistaSeguridad.Formularios.Mantenimientos
{
    partial class frmMantenimientoAplicacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIdAplicacion = new System.Windows.Forms.TextBox();
            this.txtIdModulo = new System.Windows.Forms.TextBox();
            this.cmbModulo = new System.Windows.Forms.ComboBox();
            this.txtNombreAplicacion = new System.Windows.Forms.TextBox();
            this.txtDescripcionApli = new System.Windows.Forms.TextBox();
            this.txtAyudaCHM = new System.Windows.Forms.TextBox();
            this.dgvAplicacion = new System.Windows.Forms.DataGridView();
            this.btnBuscarCHM = new System.Windows.Forms.Button();
            this.btnBuscarHTML = new System.Windows.Forms.Button();
            this.txtAyudaHTML = new System.Windows.Forms.TextBox();
            this.rbHabilitado = new System.Windows.Forms.RadioButton();
            this.rbDeshabilitado = new System.Windows.Forms.RadioButton();
            this.txtEstado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAplicacion)).BeginInit();
            this.SuspendLayout();
            // 
            // navegador1
            // 
            this.navegador1.BackColor = System.Drawing.Color.Transparent;
            this.navegador1.Location = new System.Drawing.Point(12, 12);
            this.navegador1.Name = "navegador1";
            this.navegador1.Size = new System.Drawing.Size(1059, 94);
            this.navegador1.TabIndex = 0;
            this.navegador1.Load += new System.EventHandler(this.navegador1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID Aplicacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID Modulo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(428, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre De La Aplicacion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(53, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Descripcion De La Aplicacion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(452, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Archivo Ayuda .CHM";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(452, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Archivo Ayuda HTML";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(856, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Estado Aplicacion";
            // 
            // txtIdAplicacion
            // 
            this.txtIdAplicacion.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAplicacion.Location = new System.Drawing.Point(236, 129);
            this.txtIdAplicacion.Name = "txtIdAplicacion";
            this.txtIdAplicacion.Size = new System.Drawing.Size(73, 23);
            this.txtIdAplicacion.TabIndex = 8;
            this.txtIdAplicacion.Tag = "pk_id_aplicacion";
            // 
            // txtIdModulo
            // 
            this.txtIdModulo.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdModulo.Location = new System.Drawing.Point(91, 167);
            this.txtIdModulo.Name = "txtIdModulo";
            this.txtIdModulo.Size = new System.Drawing.Size(31, 23);
            this.txtIdModulo.TabIndex = 9;
            this.txtIdModulo.Tag = "fk_id_modulo";
            // 
            // cmbModulo
            // 
            this.cmbModulo.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModulo.FormattingEnabled = true;
            this.cmbModulo.Location = new System.Drawing.Point(236, 168);
            this.cmbModulo.Name = "cmbModulo";
            this.cmbModulo.Size = new System.Drawing.Size(165, 24);
            this.cmbModulo.TabIndex = 10;
            this.cmbModulo.Tag = "saltar";
            this.cmbModulo.SelectedIndexChanged += new System.EventHandler(this.cmbModulo_SelectedIndexChanged);
            // 
            // txtNombreAplicacion
            // 
            this.txtNombreAplicacion.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreAplicacion.Location = new System.Drawing.Point(589, 168);
            this.txtNombreAplicacion.Name = "txtNombreAplicacion";
            this.txtNombreAplicacion.Size = new System.Drawing.Size(165, 23);
            this.txtNombreAplicacion.TabIndex = 11;
            this.txtNombreAplicacion.Tag = "nombre_aplicacion";
            this.txtNombreAplicacion.TextChanged += new System.EventHandler(this.txtNombreAplicacion_TextChanged);
            // 
            // txtDescripcionApli
            // 
            this.txtDescripcionApli.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionApli.Location = new System.Drawing.Point(236, 210);
            this.txtDescripcionApli.Multiline = true;
            this.txtDescripcionApli.Name = "txtDescripcionApli";
            this.txtDescripcionApli.Size = new System.Drawing.Size(165, 74);
            this.txtDescripcionApli.TabIndex = 12;
            this.txtDescripcionApli.Tag = "descripcion_aplicacion";
            // 
            // txtAyudaCHM
            // 
            this.txtAyudaCHM.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAyudaCHM.Location = new System.Drawing.Point(589, 222);
            this.txtAyudaCHM.Name = "txtAyudaCHM";
            this.txtAyudaCHM.Size = new System.Drawing.Size(165, 23);
            this.txtAyudaCHM.TabIndex = 13;
            this.txtAyudaCHM.Tag = "archivoCHM";
            // 
            // dgvAplicacion
            // 
            this.dgvAplicacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAplicacion.Location = new System.Drawing.Point(21, 310);
            this.dgvAplicacion.Name = "dgvAplicacion";
            this.dgvAplicacion.Size = new System.Drawing.Size(1050, 225);
            this.dgvAplicacion.TabIndex = 18;
            // 
            // btnBuscarCHM
            // 
            this.btnBuscarCHM.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarCHM.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCHM.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarCHM.Location = new System.Drawing.Point(760, 222);
            this.btnBuscarCHM.Name = "btnBuscarCHM";
            this.btnBuscarCHM.Size = new System.Drawing.Size(28, 23);
            this.btnBuscarCHM.TabIndex = 19;
            this.btnBuscarCHM.Text = "?";
            this.btnBuscarCHM.UseVisualStyleBackColor = false;
            this.btnBuscarCHM.Click += new System.EventHandler(this.btnBuscarCHM_Click);
            // 
            // btnBuscarHTML
            // 
            this.btnBuscarHTML.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarHTML.Location = new System.Drawing.Point(760, 251);
            this.btnBuscarHTML.Name = "btnBuscarHTML";
            this.btnBuscarHTML.Size = new System.Drawing.Size(28, 23);
            this.btnBuscarHTML.TabIndex = 20;
            this.btnBuscarHTML.Text = "?";
            this.btnBuscarHTML.UseVisualStyleBackColor = true;
            this.btnBuscarHTML.Click += new System.EventHandler(this.btnBuscarHTML_Click);
            // 
            // txtAyudaHTML
            // 
            this.txtAyudaHTML.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAyudaHTML.Location = new System.Drawing.Point(589, 251);
            this.txtAyudaHTML.Name = "txtAyudaHTML";
            this.txtAyudaHTML.Size = new System.Drawing.Size(165, 23);
            this.txtAyudaHTML.TabIndex = 14;
            this.txtAyudaHTML.Tag = "archivoHTML";
            // 
            // rbHabilitado
            // 
            this.rbHabilitado.AutoSize = true;
            this.rbHabilitado.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHabilitado.Location = new System.Drawing.Point(827, 252);
            this.rbHabilitado.Name = "rbHabilitado";
            this.rbHabilitado.Size = new System.Drawing.Size(85, 20);
            this.rbHabilitado.TabIndex = 15;
            this.rbHabilitado.TabStop = true;
            this.rbHabilitado.Tag = "saltar";
            this.rbHabilitado.Text = "Habilitado";
            this.rbHabilitado.UseVisualStyleBackColor = true;
            this.rbHabilitado.CheckedChanged += new System.EventHandler(this.rbHabilitado_CheckedChanged);
            // 
            // rbDeshabilitado
            // 
            this.rbDeshabilitado.AutoSize = true;
            this.rbDeshabilitado.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDeshabilitado.Location = new System.Drawing.Point(918, 252);
            this.rbDeshabilitado.Name = "rbDeshabilitado";
            this.rbDeshabilitado.Size = new System.Drawing.Size(105, 20);
            this.rbDeshabilitado.TabIndex = 16;
            this.rbDeshabilitado.TabStop = true;
            this.rbDeshabilitado.Tag = "saltar";
            this.rbDeshabilitado.Text = "Deshabilitado";
            this.rbDeshabilitado.UseVisualStyleBackColor = true;
            this.rbDeshabilitado.CheckedChanged += new System.EventHandler(this.rbDeshabilitado_CheckedChanged);
            // 
            // txtEstado
            // 
            this.txtEstado.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(895, 196);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(46, 23);
            this.txtEstado.TabIndex = 17;
            this.txtEstado.Tag = "estado_aplicacion";
            // 
            // frmMantenimientoAplicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1087, 597);
            this.Controls.Add(this.btnBuscarHTML);
            this.Controls.Add(this.btnBuscarCHM);
            this.Controls.Add(this.dgvAplicacion);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.rbDeshabilitado);
            this.Controls.Add(this.rbHabilitado);
            this.Controls.Add(this.txtAyudaHTML);
            this.Controls.Add(this.txtAyudaCHM);
            this.Controls.Add(this.txtDescripcionApli);
            this.Controls.Add(this.txtNombreAplicacion);
            this.Controls.Add(this.cmbModulo);
            this.Controls.Add(this.txtIdModulo);
            this.Controls.Add(this.txtIdAplicacion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.navegador1);
            this.Name = "frmMantenimientoAplicacion";
            this.Text = "0003-Mantenimiento Aplicación";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAplicacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CapaVistaNavegador.Navegador navegador1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIdAplicacion;
        private System.Windows.Forms.TextBox txtIdModulo;
        private System.Windows.Forms.ComboBox cmbModulo;
        private System.Windows.Forms.TextBox txtNombreAplicacion;
        private System.Windows.Forms.TextBox txtDescripcionApli;
        private System.Windows.Forms.TextBox txtAyudaCHM;
        private System.Windows.Forms.DataGridView dgvAplicacion;
        private System.Windows.Forms.Button btnBuscarCHM;
        private System.Windows.Forms.Button btnBuscarHTML;
        private System.Windows.Forms.TextBox txtAyudaHTML;
        private System.Windows.Forms.RadioButton rbHabilitado;
        private System.Windows.Forms.RadioButton rbDeshabilitado;
        private System.Windows.Forms.TextBox txtEstado;
    }
}