
namespace CapaVista.Procesos.OrdenesCompra
{
    partial class frmGuardar1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGuardar1));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDetallesCompra = new System.Windows.Forms.DataGridView();
            this.btnMover = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCompraEncabezado = new System.Windows.Forms.DataGridView();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.txtIdBodega = new System.Windows.Forms.TextBox();
            this.txtIdSucursal = new System.Windows.Forms.TextBox();
            this.txtFiltroCE = new System.Windows.Forms.TextBox();
            this.txtIdEmpresa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtproducto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbodega = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtsucusal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtempresa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvExistencia = new System.Windows.Forms.DataGridView();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesCompra)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompraEncabezado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistencia)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.dgvDetallesCompra);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(12, 279);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(898, 195);
            this.groupBox3.TabIndex = 81;
            this.groupBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(397, 19);
            this.label3.TabIndex = 72;
            this.label3.Text = "DETALLES DEL ENCABEZADO SELECCIONADO";
            // 
            // dgvDetallesCompra
            // 
            this.dgvDetallesCompra.AllowUserToAddRows = false;
            this.dgvDetallesCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetallesCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallesCompra.Location = new System.Drawing.Point(7, 34);
            this.dgvDetallesCompra.Name = "dgvDetallesCompra";
            this.dgvDetallesCompra.ReadOnly = true;
            this.dgvDetallesCompra.RowHeadersWidth = 51;
            this.dgvDetallesCompra.Size = new System.Drawing.Size(885, 150);
            this.dgvDetallesCompra.TabIndex = 65;
            // 
            // btnMover
            // 
            this.btnMover.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMover.ForeColor = System.Drawing.Color.Black;
            this.btnMover.Image = global::CapaVista.Properties.Resources.mover;
            this.btnMover.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMover.Location = new System.Drawing.Point(925, 295);
            this.btnMover.Name = "btnMover";
            this.btnMover.Size = new System.Drawing.Size(115, 77);
            this.btnMover.TabIndex = 79;
            this.btnMover.Text = "Mover A Existencia";
            this.btnMover.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMover.UseVisualStyleBackColor = true;
            this.btnMover.Click += new System.EventHandler(this.btnMover_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnActualizar);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dgvCompraEncabezado);
            this.groupBox2.Controls.Add(this.txtFiltro);
            this.groupBox2.Controls.Add(this.txtIdBodega);
            this.groupBox2.Controls.Add(this.txtIdSucursal);
            this.groupBox2.Controls.Add(this.txtFiltroCE);
            this.groupBox2.Controls.Add(this.txtIdEmpresa);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSeleccionar);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1105, 229);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(715, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 16);
            this.label10.TabIndex = 75;
            this.label10.Text = "ID BODEGA";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(510, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 16);
            this.label11.TabIndex = 74;
            this.label11.Text = "ID SUCURSAL";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(304, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 16);
            this.label12.TabIndex = 73;
            this.label12.Text = "ID EMPRESA";
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizar.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.Black;
            this.btnActualizar.Image = global::CapaVista.Properties.Resources.Regrescar;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnActualizar.Location = new System.Drawing.Point(980, 141);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(115, 51);
            this.btnActualizar.TabIndex = 72;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(317, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(346, 19);
            this.label2.TabIndex = 71;
            this.label2.Text = "ENCABEZADO DE LA COMPRA A MOVER";
            // 
            // dgvCompraEncabezado
            // 
            this.dgvCompraEncabezado.AllowUserToAddRows = false;
            this.dgvCompraEncabezado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompraEncabezado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCompraEncabezado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompraEncabezado.Location = new System.Drawing.Point(5, 84);
            this.dgvCompraEncabezado.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCompraEncabezado.Name = "dgvCompraEncabezado";
            this.dgvCompraEncabezado.ReadOnly = true;
            this.dgvCompraEncabezado.RowHeadersWidth = 51;
            this.dgvCompraEncabezado.RowTemplate.Height = 24;
            this.dgvCompraEncabezado.Size = new System.Drawing.Size(970, 140);
            this.dgvCompraEncabezado.TabIndex = 60;
            this.dgvCompraEncabezado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompraEncabezado_CellClick);
            // 
            // txtFiltro
            // 
            this.txtFiltro.ForeColor = System.Drawing.Color.Black;
            this.txtFiltro.Location = new System.Drawing.Point(198, 43);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(100, 20);
            this.txtFiltro.TabIndex = 70;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltro_KeyPress);
            // 
            // txtIdBodega
            // 
            this.txtIdBodega.ForeColor = System.Drawing.Color.Black;
            this.txtIdBodega.Location = new System.Drawing.Point(799, 42);
            this.txtIdBodega.Name = "txtIdBodega";
            this.txtIdBodega.Size = new System.Drawing.Size(100, 20);
            this.txtIdBodega.TabIndex = 68;
            this.txtIdBodega.TextChanged += new System.EventHandler(this.txtIdBodega_TextChanged);
            this.txtIdBodega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdBodega_KeyPress);
            // 
            // txtIdSucursal
            // 
            this.txtIdSucursal.ForeColor = System.Drawing.Color.Black;
            this.txtIdSucursal.Location = new System.Drawing.Point(606, 42);
            this.txtIdSucursal.Name = "txtIdSucursal";
            this.txtIdSucursal.Size = new System.Drawing.Size(100, 20);
            this.txtIdSucursal.TabIndex = 67;
            this.txtIdSucursal.TextChanged += new System.EventHandler(this.txtIdSucursal_TextChanged);
            this.txtIdSucursal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdSucursal_KeyPress);
            // 
            // txtFiltroCE
            // 
            this.txtFiltroCE.Enabled = false;
            this.txtFiltroCE.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroCE.ForeColor = System.Drawing.Color.Black;
            this.txtFiltroCE.Location = new System.Drawing.Point(31, 13);
            this.txtFiltroCE.Name = "txtFiltroCE";
            this.txtFiltroCE.Size = new System.Drawing.Size(100, 22);
            this.txtFiltroCE.TabIndex = 61;
            this.txtFiltroCE.Visible = false;
            this.txtFiltroCE.TextChanged += new System.EventHandler(this.txtFiltroCE_TextChanged);
            // 
            // txtIdEmpresa
            // 
            this.txtIdEmpresa.ForeColor = System.Drawing.Color.Black;
            this.txtIdEmpresa.Location = new System.Drawing.Point(392, 43);
            this.txtIdEmpresa.Name = "txtIdEmpresa";
            this.txtIdEmpresa.Size = new System.Drawing.Size(100, 20);
            this.txtIdEmpresa.TabIndex = 66;
            this.txtIdEmpresa.TextChanged += new System.EventHandler(this.txtIdEmpresa_TextChanged);
            this.txtIdEmpresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdEmpresa_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 17);
            this.label1.TabIndex = 62;
            this.label1.Text = "Codigo De La Compra";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BackColor = System.Drawing.Color.Transparent;
            this.btnSeleccionar.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.ForeColor = System.Drawing.Color.Black;
            this.btnSeleccionar.Image = global::CapaVista.Properties.Resources.comprobar;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeleccionar.Location = new System.Drawing.Point(980, 84);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(115, 51);
            this.btnSeleccionar.TabIndex = 64;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // button5
            // 
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(1079, 1);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(38, 38);
            this.button5.TabIndex = 82;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgvExistencia);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 480);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1104, 195);
            this.groupBox1.TabIndex = 83;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtproducto);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtbodega);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtsucusal);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtempresa);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(855, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(240, 165);
            this.groupBox4.TabIndex = 73;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "FILTROS";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // txtproducto
            // 
            this.txtproducto.ForeColor = System.Drawing.Color.Black;
            this.txtproducto.Location = new System.Drawing.Point(123, 125);
            this.txtproducto.Name = "txtproducto";
            this.txtproducto.Size = new System.Drawing.Size(100, 25);
            this.txtproducto.TabIndex = 7;
            this.txtproducto.TextChanged += new System.EventHandler(this.txtproducto_TextChanged);
            this.txtproducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtproducto_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "ID PRODUCTO";
            // 
            // txtbodega
            // 
            this.txtbodega.ForeColor = System.Drawing.Color.Black;
            this.txtbodega.Location = new System.Drawing.Point(123, 94);
            this.txtbodega.Name = "txtbodega";
            this.txtbodega.Size = new System.Drawing.Size(100, 25);
            this.txtbodega.TabIndex = 5;
            this.txtbodega.TextChanged += new System.EventHandler(this.txtbodega_TextChanged);
            this.txtbodega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtproducto_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "ID BODEGA";
            // 
            // txtsucusal
            // 
            this.txtsucusal.ForeColor = System.Drawing.Color.Black;
            this.txtsucusal.Location = new System.Drawing.Point(123, 63);
            this.txtsucusal.Name = "txtsucusal";
            this.txtsucusal.Size = new System.Drawing.Size(100, 25);
            this.txtsucusal.TabIndex = 3;
            this.txtsucusal.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtsucusal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtproducto_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "ID SUCURSAL";
            // 
            // txtempresa
            // 
            this.txtempresa.ForeColor = System.Drawing.Color.Black;
            this.txtempresa.Location = new System.Drawing.Point(123, 32);
            this.txtempresa.Name = "txtempresa";
            this.txtempresa.Size = new System.Drawing.Size(100, 25);
            this.txtempresa.TabIndex = 1;
            this.txtempresa.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtempresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtproducto_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "ID EMPRESA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 19);
            this.label4.TabIndex = 72;
            this.label4.Text = "EXISTENCIAS EN BODEGA";
            // 
            // dgvExistencia
            // 
            this.dgvExistencia.AllowUserToAddRows = false;
            this.dgvExistencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExistencia.Location = new System.Drawing.Point(7, 34);
            this.dgvExistencia.Name = "dgvExistencia";
            this.dgvExistencia.ReadOnly = true;
            this.dgvExistencia.RowHeadersWidth = 51;
            this.dgvExistencia.Size = new System.Drawing.Size(842, 150);
            this.dgvExistencia.TabIndex = 65;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrar.Image = global::CapaVista.Properties.Resources.lista_de_verificacion;
            this.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMostrar.Location = new System.Drawing.Point(925, 378);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(115, 87);
            this.btnMostrar.TabIndex = 84;
            this.btnMostrar.Text = "Revisar Productos Almacenados";
            this.btnMostrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // frmGuardar1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaVista.Properties.Resources.fondo3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1128, 706);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnMover);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmGuardar1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guardar Inventario";
            this.Load += new System.EventHandler(this.frmGuardar1_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesCompra)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompraEncabezado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDetallesCompra;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCompraEncabezado;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.TextBox txtIdBodega;
        private System.Windows.Forms.TextBox txtIdSucursal;
        private System.Windows.Forms.TextBox txtFiltroCE;
        private System.Windows.Forms.TextBox txtIdEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnMover;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtproducto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtbodega;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtsucusal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtempresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvExistencia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnMostrar;
    }
}