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
    public partial class frmImpresionfacturaCompras : Form
    {
        clsMovInventariosCon Controlador = new clsMovInventariosCon();
        ControladorJM jm = new ControladorJM();
        VariableGlobal glo = new VariableGlobal();
        DataTable Dt = new DataTable();
        clsValidaciones vali = new clsValidaciones();
        Controlador con = new Controlador();


        public frmImpresionfacturaCompras(string usuario)
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "COMPROBANTE DE COMPRAS A PROVEEDORES ";//header
            printer.SubTitle = string.Format("Numero de encabezado: " +txtimpresion.Text);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageSettings.Landscape = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "ASC";//Foote
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dgvimpresioncompras);
        }

        private void frmImpresionfacturaCompras_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtimpresion.Text != "")
            {
                OdbcDataReader mostrar = jm.funcMostrarimpresion(txtimpresion.Text);
                try
                {
                    while (mostrar.Read())
                    {
                        dgvimpresioncompras.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2), mostrar.GetString(3), mostrar.GetString(4), mostrar.GetString(5), mostrar.GetString(6), mostrar.GetString(7));
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("INGRESE NUMERO DE FACTURA");
                    Console.WriteLine(err.Message);
                }
            }
            else
            {
                MessageBox.Show("favor de verificar los campos");
            }
        }
        private void mostraractualizacion2()
        {
            OdbcDataReader mostrar = jm.funcMostrarEncabezadoCompras();
            try
            {
                while (mostrar.Read())
                {
                    dgv2.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2), mostrar.GetString(3), mostrar.GetString(4));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            mostraractualizacion2();
        }

        private void txtimpresion_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Ayuda/AyudasPC.chm", "AyudaImpresionOrdeCompra_1.html");
        }
    }
}
