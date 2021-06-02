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
using CapaControlador;

namespace CapaVista.Procesos.Inventarios
{
    public partial class frmVistaMovimientoInventario : Form
    {
        ControladorJM controlador = new ControladorJM();
        clsValidaciones valida = new clsValidaciones();
        string campo, dato;
        public frmVistaMovimientoInventario()
        {
            InitializeComponent();
            llenar_dgv();
        }
       private void llenar_dgv()
        {
            dgvMovimiento.Rows.Clear();

            OdbcDataReader mostrar = controlador.funcSelectllenardgvOrdenes();
            try
            {
                while (mostrar.Read())
                {
                    dgvMovimiento.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2), mostrar.GetString(3), mostrar.GetString(4), mostrar.GetString(5), mostrar.GetString(6), mostrar.GetString(7));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        public void CargarDetallesFiltro()
        {
            dgvMovimiento.Rows.Clear();

            OdbcDataReader mostrar = controlador.funcSelectllenardgvMovimientofiltro(campo, dato);
            try
            {
                while (mostrar.Read())
                {
                    dgvMovimiento.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2), mostrar.GetString(3), mostrar.GetString(4), mostrar.GetString(5), mostrar.GetString(6), mostrar.GetString(7));

                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (rbProducto.Checked == false && rbBodega.Checked == false && rbRazon.Checked == false && rbUsuario.Checked == false)
            {
                MessageBox.Show("Seleccione el campo a filtar");
            }
            if (rbProducto.Checked == true && txtProducto.Text != "")
            {
                campo = "pro.fkidproducto";
                dato = txtProducto.Text;
                CargarDetallesFiltro();
            }
            if (rbBodega.Checked == true && txtBodega.Text != "")
            {
                campo = "moven.fkbodegaorigen";
                dato = txtBodega.Text;
                CargarDetallesFiltro();
            }
            if (rbRazon.Checked == true && txtRazon.Text != "")
            {
                campo = "rm.nombrerazon";
                dato = "'"+txtRazon.Text+"'";
                CargarDetallesFiltro();
            }
            if (rbUsuario.Checked == true && txtUsuario.Text != "")
            {
                campo = "logi.usuario_login";
                dato = "'" + txtUsuario.Text + "'";
                CargarDetallesFiltro();
            }
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.CampoNumerico(e);
        }

        private void txtRazon_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.CamposLetras(e);
        }

        private void txtBodega_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.CampoNumerico(e);
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.CamposLetrasTexto(e);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            rbBodega.Checked = false;
            rbProducto.Checked = false;
            rbRazon.Checked = false;
            rbUsuario.Checked = false;
            txtBodega.Text = "";
            txtProducto.Text = "";
            txtRazon.Text = "";
            txtUsuario.Text = "";
            dgvMovimiento.Rows.Clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            llenar_dgv();
        }

        private void Filtros_Enter(object sender, EventArgs e)
        {

        }

        private void frmVistaMovimientoInventario_Load(object sender, EventArgs e)
        {

        }

        private void rbProducto_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "REPORTE MOVIMIENTO INVENTARIO";//header
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "ASC";//Foote
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dgvMovimiento);
        }
    }
}
