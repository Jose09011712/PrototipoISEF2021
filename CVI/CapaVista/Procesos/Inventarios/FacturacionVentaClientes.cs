using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;


namespace CapaVista.Procesos.Inventarios
{
    public partial class FacturacionVentaClientes : Form
    {
        Controlador Cn = new Controlador();
        int total = 0;
        public FacturacionVentaClientes()
        {
            InitializeComponent();
            llenarCombos();
            CodigoMaximo("ventaEncabezado", "idVentaEncabezado", txtCodigo);
        }
        public void CodigoMaximo(string tabla, string campo, TextBox txt)
        {
            string tbl = tabla;
            string cmp1 = campo;
            TextBox txt1 = txt;
            int codigo = Cn.funcCodigoMaximo(tbl, cmp1);
            txt1.Text = codigo.ToString();
            txt1.Enabled = false;
        }
        void llenarCombos()
        {
            cmbCliente.Items.Clear();
            cmbCliente.Items.Add("Seleccione...");
            llenarse("cliente", "nombreCliente", "pkIdCliente", "estadoCliente", cmbCliente);
            cmbCliente.SelectedIndex = 0;
            ///////////////////////
            cmbProducto.Items.Clear();
            cmbProducto.Items.Add("Seleccione...");
            llenarse("producto", "nombrePro", "pkIdProducto", "estadoPro", cmbProducto);
            cmbProducto.SelectedIndex = 0;
        }

        void llenarse(string tabla, string campo1, string campo2, string estado, ComboBox ComboBox)
        {

            string[] items = Cn.itemsDosParametros(tabla, campo1, campo2, estado);
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    if (items[i] != "")
                    {
                        ComboBox.Items.Add(items[i]);
                    }
                }

            }
            var dt2 = Cn.enviarDosParametros(tabla, campo1, campo2, estado);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt2.Rows)
            {
                coleccion.Add(Convert.ToString(row[campo1]) + "-" + Convert.ToString(row[campo2]));
            }
            ComboBox.AutoCompleteCustomSource = coleccion;
            ComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex != 0)
            {
                if (cmbCliente.SelectedItem != null)
                {
                    string[] codigo = cmbCliente.SelectedItem.ToString().Split('-');
                    try
                    {
                        Int32.Parse(codigo[0]);
                        txtCliente.Text = codigo[0];
                    }
                    catch (Exception)
                    {
                        Int32.Parse(codigo[1]);
                        txtCliente.Text = codigo[1];
                    }
                }
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex != 0)
            {
                if (cmbProducto.SelectedItem != null)
                {
                    string[] codigo = cmbProducto.SelectedItem.ToString().Split('-');
                    try
                    {
                        Int32.Parse(codigo[0]);
                        txtProducto.Text = codigo[0];
                    }
                    catch (Exception)
                    {
                        Int32.Parse(codigo[1]);
                        txtProducto.Text = codigo[1];
                    }
                }
                txtPresioUnitario.Text = Cn.funcPrecio(txtProducto.Text);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex == 0 || cmbCliente.SelectedItem == null || cmbProducto.SelectedItem == null || cmbProducto.SelectedIndex == 0 || txtCantidad.Text == "")
            {
                MessageBox.Show("Debe seleccionar un elemento valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bool validar = true;
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView1);
                string Codigo;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    Codigo = Convert.ToString(item.Cells["Column4"].Value);
                    if (Codigo == txtProducto.Text)
                    {
                        MessageBox.Show("No se puede agregar 2 veces el mismo producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        validar = false;
                    }
                }
                if (validar)
                {
                    fila.Cells[0].Value = txtCodigo.Text;
                    fila.Cells[1].Value = txtCliente.Text;
                    fila.Cells[2].Value = cmbCliente.SelectedItem.ToString();
                    fila.Cells[3].Value = txtProducto.Text;
                    fila.Cells[4].Value = cmbProducto.SelectedItem.ToString();
                    fila.Cells[5].Value = txtPresioUnitario.Text; //presio unitario
                    fila.Cells[6].Value = txtCantidad.Text;
                    fila.Cells[7].Value = (Int32.Parse(txtCantidad.Text)) * (float.Parse(txtPresioUnitario.Text)); //subtotal
                    dataGridView1.Rows.Add(fila);
                    cmbProducto.SelectedIndex = 0;
                    txtPresioUnitario.Text = "";
                    txtProducto.Text = "";
                    txtTotal.Text = "";
                    txtCantidad.Text = "";
                    total = 0;
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        string nuevo = Convert.ToString(item.Cells["Column8"].Value);
                        total += Int32.Parse(nuevo);
                        txtTotal.Text = total.ToString();

                    }

                }
            }
        }

        private void FacturacionVentaClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            int contador = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                contador++;
            }
            if (contador > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                total = 0;
                txtTotal.Text = "";
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    string nuevo = Convert.ToString(item.Cells["Column8"].Value);
                    total += Int32.Parse(nuevo);
                    txtTotal.Text = total.ToString();

                }

            }
        }

        private void btnVaciar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            txtTotal.Text = "";
        }
        void imprimir()
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Detalle de productos";
            printer.SubTitle = string.Format("Fecha: {0}", DateTime.Today.ToString("dd-MM-yyyy "));
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int Contador = 0, VerificacionIngreso = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Contador++;
            }
            if (Contador == 0)
            {
                MessageBox.Show("Debe agregar un registro en a la tabla.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                List<string> ventaEncabezado = new List<string>();
                List<string> ventaDetalle = new List<string>();
                string  fecha;
                fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                ventaEncabezado.Add(txtCodigo.Text);
                ventaEncabezado.Add(txtCliente.Text);
                ventaEncabezado.Add(fecha);
                ventaEncabezado.Add(txtTotal.Text);
                Cn.procDatosInsertar("ventaencabezado", ventaEncabezado);
                ///////////
                string VentaDetalleCodigo, codigoProducto, precioU,cantidad, subtotal;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    ventaDetalle.Clear();
                    VentaDetalleCodigo = Convert.ToString(item.Cells["Column1"].Value);
                    codigoProducto = Convert.ToString(item.Cells["Column4"].Value);
                    precioU = Convert.ToString(item.Cells["Column6"].Value);
                    cantidad = Convert.ToString(item.Cells["Column7"].Value);
                    subtotal = Convert.ToString(item.Cells["Column8"].Value);

                    ventaDetalle.Add(VentaDetalleCodigo);
                    ventaDetalle.Add(codigoProducto);
                    ventaDetalle.Add(precioU);
                    ventaDetalle.Add(cantidad);
                    ventaDetalle.Add(subtotal);
                    if (Cn.procDatosInsertar("ventadetalle", ventaDetalle))
                    {
                        VerificacionIngreso++;
                    }
                }
                if (VerificacionIngreso > 0)
                {
                    MessageBox.Show("Los Datos han sido Guardados Exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    imprimir();
                    CodigoMaximo("ventaEncabezado", "idVentaEncabezado", txtCodigo);
                    dataGridView1.Rows.Clear();
                    txtTotal.Text = "";
                }
                else
                {
                    MessageBox.Show("Upss, ha ocurrido un error, consulta con un experto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
