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
         
    public partial class frmEstadoCompras : Form
    {
         clsMovInventariosCon Controlador = new clsMovInventariosCon();
         ControladorJM jm = new ControladorJM();
         Controlador con = new Controlador();
        clsValidaciones vali = new clsValidaciones();
        string filtro; 
        public frmEstadoCompras(string usuario)
        {
            InitializeComponent();
            CargarCombobox();
        }
        public void CargarCombobox()
        {
            //llenado de combobox de tipo compra
            cmbtipocompra.DisplayMember = "nombretipocompra";
            cmbtipocompra.ValueMember = "pktipocompra";
            cmbtipocompra.DataSource = con.funcObtenerCamposComboboxPais("pktipocompra", "nombretipocompra", "tipocompra", "estado");
            cmbtipocompra.SelectedIndex = -1;
        }
        private void mostraractualizacion() {
            OdbcDataReader mostrar = jm.funcMostrarEncabezado();
            try
            {
                while (mostrar.Read())
                {
                    dgvEstados.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2), mostrar.GetString(3), mostrar.GetString(4));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }
       
        private void cmbtipocompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbtipocompra.SelectedIndex != -1)
            {
                txttipocompra.Text = cmbtipocompra.SelectedValue.ToString();
            }
        }

        private void txttipocompra_TextChanged(object sender, EventArgs e)
        {
            if (txttipocompra.Text != "")
            {
                OdbcDataReader reader = jm.FieldComboboxtxt("nombretipocompra", "tipocompra", "estado", "pktipocompra", txttipocompra.Text);
                if (reader.Read())
                {
                    cmbtipocompra.Text = reader.GetString(0);
                }
                else
                {
                    cmbtipocompra.SelectedIndex = -1;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgvEstados.Rows.Clear();
            mostraractualizacion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvEstados.Rows.Clear();
            OdbcDataReader mostrar = jm.funcActualizarestado(txtenca.Text, txttipocompra.Text);
            mostraractualizacion();
        }

        private void frmEstadoCompras_Load(object sender, EventArgs e)
        {

        }
        private void filtroscompra(string filtroc) {
            dgvEstados.Rows.Clear();
            OdbcDataReader mostrar = jm.funcEstadosfiltroCompras(filtroc);
            try
            {
                while (mostrar.Read())
                {
                    dgvEstados.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2), mostrar.GetString(3), mostrar.GetString(4));
                }
            }
            catch (Exception err)
            {

                Console.WriteLine(err.Message);
            }



        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            filtro = "";
            filtro = "SOLICITUD";
            filtroscompra(filtro);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            filtro = "";
            filtro = "ORDEN";
            filtroscompra(filtro);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            filtro = "";
            filtro = "PROCESO";
            filtroscompra(filtro);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            filtro = "";
            filtro = "EN CURSO";
            filtroscompra(filtro);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            filtro = "";
            filtro = "RECIBIDA";
            filtroscompra(filtro);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            filtro = "";
            filtro = "SOLICITUD RECHAZADA";
            filtroscompra(filtro);
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            filtro = "";
            filtro = "ORDEN RECHAZADA";
            filtroscompra(filtro);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            filtro = "";
            filtro = "DEVOLUCION";
            filtroscompra(filtro);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "PROCESOS DE COMRPAS A PROVEEDORES ";//header
            printer.SubTitle = string.Format("ASC");
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageSettings.Landscape = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "ASC";//Foote
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dgvEstados);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void txtenca_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void txttipocompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Ayuda/AyudasPC.chm", "AyudaEstadoDeCompra_1.html");
        }
    }
}
