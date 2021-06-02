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

namespace CapaVista.Procesos.OrdenesCompra
{
    public partial class frmVisualizarTodo : Form
    {
        clsMoverAExistencias mover = new clsMoverAExistencias();
        DataTable Dt = new DataTable();
        DataTable Dt2 = new DataTable();
        public frmVisualizarTodo()
        {
            InitializeComponent();
            llenadocolumnas();
            funcMostrarEncabezadoCompras();
        }
        public void llenadocolumnas()
        {
            Dt.Columns.Add("CODIGO", typeof(string));
            Dt.Columns.Add("ID_EMPRESA", typeof(string));
            Dt.Columns.Add("EMPRESA", typeof(string));
            Dt.Columns.Add("ID_SUCURSAL", typeof(string));
            Dt.Columns.Add("SUCURSAL", typeof(string));
            Dt.Columns.Add("ID_BODEGA", typeof(string));
            Dt.Columns.Add("BODEGA", typeof(string));
            Dt.Columns.Add("PROVEEDOR", typeof(string));
            Dt.Columns.Add("FECHA", typeof(string));
            Dt.Columns.Add("TOTAL", typeof(string));
            Dt.Columns.Add("ESTADO", typeof(string));
            dgvCompraEncabezado.Rows.Clear();

            Dt2.Columns.Add("NoDOCUMENTO", typeof(string));
            Dt2.Columns.Add("ID_PRODUCTO", typeof(string));
            Dt2.Columns.Add("PRODUCTO", typeof(string));
            Dt2.Columns.Add("CANTIDAD", typeof(string));
            Dt2.Columns.Add("COSTO", typeof(string));
            dgvDetallesCompra.Rows.Clear();

        }
        public void funcMostrarEncabezadoCompras()
        {
            Dt.Rows.Clear();
            OdbcDataReader mostrar = mover.funcMostrarEncabezado("9");
            try
            {
                while (mostrar.Read())
                {
                    DataRow row;
                    row = Dt.NewRow();
                    row["CODIGO"] = mostrar.GetString(0);
                    row["ID_EMPRESA"] = mostrar.GetString(1);
                    row["EMPRESA"] = mostrar.GetString(2);
                    row["ID_SUCURSAL"] = mostrar.GetString(3);
                    row["SUCURSAL"] = mostrar.GetString(4);
                    row["ID_BODEGA"] = mostrar.GetString(5);
                    row["BODEGA"] = mostrar.GetString(6);
                    row["PROVEEDOR"] = mostrar.GetString(7);
                    row["FECHA"] = mostrar.GetString(8);
                    row["TOTAL"] = mostrar.GetString(9);
                    row["ESTADO"] = mostrar.GetString(10);
                    Dt.Rows.Add(row);
                }
                dgvCompraEncabezado.DataSource = Dt;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }       
        public void funcMostrarDetalleCompras(string strDocumento)
        {
            Dt2.Rows.Clear();
            OdbcDataReader mostrar = mover.funcMostrarDetalle(strDocumento);
            try
            {
                while (mostrar.Read())
                {
                    DataRow row;
                    row = Dt2.NewRow();
                    row["NoDOCUMENTO"] = mostrar.GetString(0);
                    row["ID_PRODUCTO"] = mostrar.GetString(1);
                    row["PRODUCTO"] = mostrar.GetString(2);
                    row["CANTIDAD"] = mostrar.GetString(3);
                    row["COSTO"] = mostrar.GetString(4);
                    Dt2.Rows.Add(row);
                }
                dgvDetallesCompra.DataSource = Dt2;
            }
            catch (Exception err)
            {

                Console.WriteLine(err.Message);
            }
        }

        private void txtFiltroCE_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltro.Text == " ")
            {
                dgvCompraEncabezado.Rows.Clear();
                dgvCompraEncabezado.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"CODIGO LIKE '{txtFiltro.Text}%'";
        }

        private void txtIdEmpresa_TextChanged(object sender, EventArgs e)
        {
            if (txtIdEmpresa.Text == " ")
            {
                dgvCompraEncabezado.Rows.Clear();
                dgvCompraEncabezado.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"ID_EMPRESA LIKE '{txtIdEmpresa.Text}%'";
        }

        private void txtIdSucursal_TextChanged(object sender, EventArgs e)
        {
            if (txtIdSucursal.Text == " ")
            {
                dgvCompraEncabezado.Rows.Clear();
                dgvCompraEncabezado.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"ID_SUCURSAL LIKE '{txtIdSucursal.Text}%'";
        }

        private void txtIdBodega_TextChanged(object sender, EventArgs e)
        {
            if (txtIdBodega.Text == " ")
            {
                dgvCompraEncabezado.Rows.Clear();
                dgvCompraEncabezado.DataSource = Dt;
                return;
            }
            Dt.DefaultView.RowFilter = $"ID_BODEGA LIKE '{txtIdBodega.Text}%'";
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFiltroCE.Text))
            {
                MessageBox.Show("Debe Seleccionar un Encabezado");
                return;
            }
            else
            {
                funcMostrarDetalleCompras(txtFiltroCE.Text);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Dt.Rows.Clear();
            funcMostrarEncabezadoCompras();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvCompraEncabezado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtIdEmpresa.Text = dgvCompraEncabezado.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtIdSucursal.Text = dgvCompraEncabezado.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtIdBodega.Text = dgvCompraEncabezado.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtFiltroCE.Text = dgvCompraEncabezado.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
