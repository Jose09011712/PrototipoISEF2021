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

namespace CapaVista.Procesos.Saldos
{
    public partial class frmReciboCompras : Form
    {
        clsMovInventariosCon Controlador = new clsMovInventariosCon();
        ControladorJM jm = new ControladorJM();
        VariableGlobal glo = new VariableGlobal();
        DataTable Dt = new DataTable();
        Controlador con = new Controlador();
        double saldoanterior;
        public frmReciboCompras(string usuario)
        {
            InitializeComponent();
            mostraractualizacion2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
        private void mostraractualizacion2()
        {
            OdbcDataReader mostrar = jm.funcMostrarRecibo();
            try
            {
                while (mostrar.Read())
                {
                    dgvReciboCompras.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2), mostrar.GetString(3), mostrar.GetString(4), mostrar.GetString(5), mostrar.GetString(6));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void limpiar()
        {

            dgvhistoricorecibo.Rows.Clear();
            txtcodigo.Text = "";
            txtcantidad.Text = "";
        }
        private void realizarpago()
        {

            string fecha, saldonuevostring;
            double saldonuevo, abono;
            abono = Double.Parse(txtcantidad.Text);
            saldonuevo = saldoanterior - abono;
            saldonuevostring = Convert.ToString(saldonuevo);
            fecha = DateTime.Now.ToString("dd/MM/yyyy");
            if (dgvhistoricorecibo.Rows.Count > 1)
            {

                OdbcDataReader consulta3 = jm.funcInsertarsaldocomprasdefinitivo(txtnotas.Text, saldonuevostring);
                OdbcDataReader consulta2 = jm.funcInsertarSaldocompras5(fecha, txtcodigo.Text, Convert.ToString(saldoanterior), txtcantidad.Text, txtnotas.Text);
                MessageBox.Show("ABONO REALIZADO CON EXITO");
            }
            limpiar();


        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            realizarpago();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtcodigo.Text != "")
            {
                OdbcDataReader mostrar1 = jm.funcSelectllenardgvmorososfiltro2(txtcodigo.Text);
                try
                {
                    while (mostrar1.Read())
                    {
                        dgvhistoricorecibo.Rows.Add(mostrar1.GetString(0), mostrar1.GetString(1), mostrar1.GetString(2), mostrar1.GetString(3), mostrar1.GetString(4), mostrar1.GetString(5));
                        saldoanterior = mostrar1.GetDouble(6);
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }
        private void dgvReciboCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvhistorico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
