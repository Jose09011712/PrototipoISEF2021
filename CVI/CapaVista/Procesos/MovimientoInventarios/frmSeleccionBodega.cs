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
    public partial class frmSeleccionBodega : Form
    {
        DataTable Dt = new DataTable();
        clsMovInventariosCon Controlador = new clsMovInventariosCon();
        clsValidaciones vali = new clsValidaciones();
        public frmSeleccionBodega()
        {
            InitializeComponent();
            LlenarDgv();
        }

        //Llenar los datos para el dgvBodega
        public void LlenarDgv()
        {
            dgvBodega.Rows.Clear();
            Dt.Columns.Add("pkIdBodega", typeof(string));
            Dt.Columns.Add("fkIdEmpresa", typeof(string));
            Dt.Columns.Add("fkIdSucursal", typeof(string));
            Dt.Columns.Add("direccionBodega", typeof(string));
            OdbcDataReader mostrar = Controlador.funcConsulta();
            try
            {
                while (mostrar.Read())
                {
                    DataRow row;
                    row = Dt.NewRow();
                    row["pkIdBodega"] = mostrar.GetString(0);
                    row["fkIdEmpresa"] = mostrar.GetString(1);
                    row["fkIdSucursal"] = mostrar.GetString(2);
                    row["direccionBodega"] = mostrar.GetString(3);
                    Dt.Rows.Add(row);
                }
                dgvBodega.DataSource = Dt;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }

        private void txtEmpresa_TextChanged(object sender, EventArgs e)
        {
            if (txtEmpresa.Text == " ")
            {
                dgvBodega.Rows.Clear();
                dgvBodega.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"fkIdEmpresa LIKE '{txtEmpresa.Text}%'";
        }

        private void txtSucursal_TextChanged(object sender, EventArgs e)
        {
            if (txtSucursal.Text == " ")
            {
                dgvBodega.Rows.Clear();
                dgvBodega.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"fkIdSucursal LIKE '{txtSucursal.Text}%'";
        }

        private void txtIdBodega_TextChanged(object sender, EventArgs e)
        {
            if (txtIdBodega.Text == " ")
            {
                dgvBodega.Rows.Clear();
                dgvBodega.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"pkIdBodega LIKE '{txtIdBodega.Text}%'";
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvBodega.Rows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar La Bodega Deceada");
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

        private void dgvBodega_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void txtSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void txtIdBodega_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }
    }
}
