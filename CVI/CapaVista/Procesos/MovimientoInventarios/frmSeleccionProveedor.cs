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
    public partial class frmSeleccionProveedor : Form
    {
        DataTable Dt = new DataTable();
        clsMovInventariosCon Controlador = new clsMovInventariosCon();
        public frmSeleccionProveedor()
        {
            InitializeComponent();
            LlenarDgv();
        }
        public void LlenarDgv()
        {
            dgvProveedor.Rows.Clear();
            Dt.Columns.Add("pkIdProv", typeof(string));
            Dt.Columns.Add("nitProv", typeof(string));
            Dt.Columns.Add("telProv", typeof(string));
            Dt.Columns.Add("correoProv", typeof(string));
            OdbcDataReader mostrar = Controlador.funcCopnsultaProveedores();
            try
            {
                while (mostrar.Read())
                {
                    DataRow row;
                    row = Dt.NewRow();
                    row["pkIdProv"] = mostrar.GetString(0);
                    row["nitProv"] = mostrar.GetString(1);
                    row["telProv"] = mostrar.GetString(2);
                    row["correoProv"] = mostrar.GetString(3);
                    Dt.Rows.Add(row);
                }
                dgvProveedor.DataSource = Dt;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void txtIdProveedor_TextChanged(object sender, EventArgs e)
        {
            if (txtIdProveedor.Text == " ")
            {
                dgvProveedor.Rows.Clear();
                dgvProveedor.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"pkIdProv LIKE '{txtIdProveedor.Text}%'";
        }

        private void txtNIT_TextChanged(object sender, EventArgs e)
        {
            if (txtNIT.Text == " ")
            {
                dgvProveedor.Rows.Clear();
                dgvProveedor.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"nitProv LIKE '{txtNIT.Text}%'";
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (txtTelefono.Text == " ")
            {
                dgvProveedor.Rows.Clear();
                dgvProveedor.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"telProv LIKE '{txtTelefono.Text}%'";
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvProveedor.Rows.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar Un Cliente");
                //return;
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
    }
}
