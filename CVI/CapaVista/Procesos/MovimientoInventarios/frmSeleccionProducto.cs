using CapaControlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista.Procesos.MovimientoInventarios
{
    public partial class frmSeleccionProducto : Form
    {
        DataTable Dt = new DataTable();
        clsMovInventariosCon Controlador = new clsMovInventariosCon();
        public frmSeleccionProducto()
        {
            InitializeComponent();
            LlenarDgv();
        }
        //Llenar los datos para el dgvProducto
        public void LlenarDgv()
        {
            dgvProducto.Rows.Clear();
            Dt.Columns.Add("Id_Producto", typeof(string));
            Dt.Columns.Add("Id_Empresa", typeof(string));
            Dt.Columns.Add("Id_Linea", typeof(string));
            Dt.Columns.Add("Id_Marca", typeof(string));
            Dt.Columns.Add("Nombre_Producto", typeof(string));
            OdbcDataReader mostrar = Controlador.funcConsultaProducto();
            try
            {
                while (mostrar.Read())
                {
                    DataRow row;
                    row = Dt.NewRow();
                    row["Id_Producto"] = mostrar.GetString(0);
                    row["Id_Empresa"] = mostrar.GetString(1);
                    row["Id_Linea"] = mostrar.GetString(2);
                    row["Id_Marca"] = mostrar.GetString(3);
                    row["Nombre_Producto"] = mostrar.GetString(4);
                    Dt.Rows.Add(row);
                }
                dgvProducto.DataSource = Dt;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvProducto.Rows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar El Producto Deceado.");
                // return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtIdProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtIdProducto.Text == " ")
            {
                dgvProducto.Rows.Clear();
                dgvProducto.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"Id_Producto LIKE '{txtIdProducto.Text}%'";
        }

        private void txtIdEmpresa_TextChanged(object sender, EventArgs e)
        {
            if (txtIdEmpresa.Text == " ")
            {
                dgvProducto.Rows.Clear();
                dgvProducto.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"Id_Empresa LIKE '{txtIdEmpresa.Text}%'";
        }

        private void txtIdLinea_TextChanged(object sender, EventArgs e)
        {
            if (txtIdLinea.Text == " ")
            {
                dgvProducto.Rows.Clear();
                dgvProducto.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"Id_Linea LIKE '{txtIdLinea.Text}%'";
        }

        private void txtIdMarca_TextChanged(object sender, EventArgs e)
        {
            if (txtIdMarca.Text == " ")
            {
                dgvProducto.Rows.Clear();
                dgvProducto.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"Id_Marca LIKE '{txtIdMarca.Text}%'";
        }

        private void txtNomProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtNomProducto.Text == " ")
            {
                dgvProducto.Rows.Clear();
                dgvProducto.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"Nombre_Producto LIKE '{txtNomProducto.Text}%'";
        }
    }
}
