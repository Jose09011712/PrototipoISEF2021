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
    public partial class frmGuardar1 : Form
    {
        clsValidaciones vali = new clsValidaciones();
        clsMoverAExistencias mover = new clsMoverAExistencias();
        DataTable Dt = new DataTable();
        DataTable Dt2 = new DataTable();
        DataTable Dt3 = new DataTable();
        int intObtenerFinalDGV;
        public frmGuardar1()
        {
            InitializeComponent();
            llenadocolumnas();
            funcMostrarEncabezadoCompras();
            funcMostrarExistencia();
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

            Dt3.Columns.Add("CODIGO", typeof(string));
            Dt3.Columns.Add("ID_EMPRESA", typeof(string));
            Dt3.Columns.Add("EMPRESA", typeof(string));
            Dt3.Columns.Add("ID_SUCURSAL", typeof(string));
            Dt3.Columns.Add("SUCURSAL", typeof(string));
            Dt3.Columns.Add("ID_BODEGA", typeof(string));
            Dt3.Columns.Add("BODEGA", typeof(string));
            Dt3.Columns.Add("ID_PRODUCTO", typeof(string));
            Dt3.Columns.Add("PRODUCTO", typeof(string));
            Dt3.Columns.Add("CANTIDAD", typeof(string));
            Dt3.Columns.Add("MINIMO", typeof(string));
            Dt3.Columns.Add("MAXIMO", typeof(string));
            dgvExistencia.Rows.Clear();
        }
        public void funcMostrarEncabezadoCompras()
        {
            Dt.Rows.Clear();
            OdbcDataReader mostrar = mover.funcMostrarEncabezado("5");
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
        public void funcMostrarExistencia()
        {
            Dt3.Rows.Clear();
            OdbcDataReader mostrar = mover.funcMostrarExistencia();
            try
            {
                while (mostrar.Read())
                {
                    DataRow row;
                    row = Dt3.NewRow();
                    row["CODIGO"] = mostrar.GetString(0);
                    row["ID_EMPRESA"] = mostrar.GetString(1);
                    row["EMPRESA"] = mostrar.GetString(2);
                    row["ID_SUCURSAL"] = mostrar.GetString(3);
                    row["SUCURSAL"] = mostrar.GetString(4);
                    row["ID_BODEGA"] = mostrar.GetString(5);
                    row["BODEGA"] = mostrar.GetString(6);
                    row["ID_PRODUCTO"] = mostrar.GetString(7);
                    row["PRODUCTO"] = mostrar.GetString(8);
                    row["CANTIDAD"] = mostrar.GetString(9);
                    row["MINIMO"] = mostrar.GetString(10);
                    row["MAXIMO"] = mostrar.GetString(11);
                    Dt3.Rows.Add(row);
                }
                dgvExistencia.DataSource = Dt3;
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

        public string funcVerificarExistencia(string strIDEmpres, string strIDSucursal, string IDBodega, string IDProducto)
        {
            string strCantidad = mover.funcVerificarExistencia(strIDEmpres, strIDSucursal, IDBodega, IDProducto);
            if (string.IsNullOrEmpty(strCantidad))
            {
                return "1";//esta vacio Insertar
            }
            else
            {
                return "2";//esta lleno Actualizar
            }
        }
        public void funcLlenarLista()
        {
            string intAccion;
            for (int intContador = 0; intContador < dgvDetallesCompra.Rows.Count; intContador++)
            {
                intAccion = funcVerificarExistencia(txtIdEmpresa.Text, txtIdSucursal.Text, txtIdBodega.Text,
                    dgvDetallesCompra.Rows[intContador].Cells[1].Value.ToString());
                Console.WriteLine(intContador + "\n" + txtIdEmpresa.Text + "\n" +
                    txtIdSucursal.Text + "\n" +
                    txtIdBodega.Text + "\n" +
                    dgvDetallesCompra.Rows[intContador].Cells[1].Value.ToString() + "\n" +
                    dgvDetallesCompra.Rows[intContador].Cells[3].Value.ToString() + "\n" +
                    intAccion + "Fin");
                mover.funcLlenarListaExistencia(txtIdEmpresa.Text, txtIdSucursal.Text, txtIdBodega.Text,
                    dgvDetallesCompra.Rows[intContador].Cells[1].Value.ToString(),
                    dgvDetallesCompra.Rows[intContador].Cells[3].Value.ToString(), intAccion);
            }
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

        private void btnMover_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFiltroCE.Text))
            {
                return;
            }
            else
            {
                funcLlenarLista();
                mover.insertarEnTransaccion(txtFiltroCE.Text);
                funcMostrarEncabezadoCompras();
                Dt2.Rows.Clear();
                Dt3.Rows.Clear();
                funcMostrarExistencia();
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Dt.Rows.Clear();
            funcMostrarEncabezadoCompras();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtempresa.Text == " ")
            {
                dgvExistencia.Rows.Clear();
                dgvExistencia.DataSource = Dt;
                return;
            }
            Dt3.DefaultView.RowFilter = $"ID_EMPRESA LIKE '{txtempresa.Text}%'";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (txtsucusal.Text == " ")
            {
                dgvExistencia.Rows.Clear();
                dgvExistencia.DataSource = Dt;
                return;
            }
            Dt3.DefaultView.RowFilter = $"ID_SUCURSAL LIKE '{txtIdEmpresa.Text}%'";
        }

        private void txtbodega_TextChanged(object sender, EventArgs e)
        {
            if (txtbodega.Text == " ")
            {
                dgvExistencia.Rows.Clear();
                dgvExistencia.DataSource = Dt;
                return;
            }
            Dt3.DefaultView.RowFilter = $"ID_BODEGA LIKE '{txtbodega.Text}%'";
            
        }

        private void txtproducto_TextChanged(object sender, EventArgs e)
        {
            if (txtproducto.Text == " ")
            {
                dgvExistencia.Rows.Clear();
                dgvExistencia.DataSource = Dt;
                return;
            }
            Dt3.DefaultView.RowFilter = $"ID_PRODUCTO LIKE '{txtproducto.Text}%'";
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

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

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            frmVisualizarTodo visualizarTodo = new frmVisualizarTodo();
            visualizarTodo.Show();
        }

        private void frmGuardar1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void txtproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void txtIdEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void txtIdSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void txtIdBodega_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Ayuda/AyudasPC.chm", "Ayuda-GuardarEnExistencia_1.html");
        }
    }
}
