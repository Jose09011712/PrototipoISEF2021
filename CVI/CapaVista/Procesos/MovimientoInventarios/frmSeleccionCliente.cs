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
    public partial class frmSeleccionCliente : Form
    {
        DataTable Dt = new DataTable();
        clsMovInventariosCon Controlador = new clsMovInventariosCon();
        public frmSeleccionCliente()
        {
            InitializeComponent();
            LlenarDgv();
        }
        public void LlenarDgv()
        {
            dgvClientes.Rows.Clear();
            Dt.Columns.Add("pkIdCliente", typeof(string));
            Dt.Columns.Add("nombreCliente", typeof(string));
            Dt.Columns.Add("apellidoCliente", typeof(string));
            Dt.Columns.Add("nitCliente", typeof(string));
            OdbcDataReader mostrar = Controlador.funcCopnsultaClientes();
            try
            {
                while (mostrar.Read())
                {
                    DataRow row;
                    row = Dt.NewRow();
                    row["pkIdCliente"] = mostrar.GetString(0);
                    row["nombreCliente"] = mostrar.GetString(1);
                    row["apellidoCliente"] = mostrar.GetString(2);
                    row["nitCliente"] = mostrar.GetString(3);
                    Dt.Rows.Add(row);
                }
                dgvClientes.DataSource = Dt;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }

        private void txtIdClientes_TextChanged(object sender, EventArgs e)
        {
            if (txtIdClientes.Text == " ")
            {
                dgvClientes.Rows.Clear();
                dgvClientes.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"pkIdCliente LIKE '{txtIdClientes.Text}%'";
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text == " ")
            {
                dgvClientes.Rows.Clear();
                dgvClientes.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"nombreCliente LIKE '{txtNombre.Text}%'";
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (txtApellido.Text == " ")
            {
                dgvClientes.Rows.Clear();
                dgvClientes.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"apellidoCliente LIKE '{txtApellido.Text}%'";
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.Rows.Count == 0)
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
