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
namespace CapaVista.Procesos.Inventarios
{
    public partial class frmInventarioTotal : Form
    {
        clsValidaciones validaciones = new clsValidaciones();
        ControladorJM con = new ControladorJM();
        int controlseleccion = 0;
        public frmInventarioTotal()
        {
            InitializeComponent();
            CargarComboboxEmpresa();
        }
        public void CargarComboboxEmpresa()
        {
            //llenado de combobox de Empresa
            cmbEmpresa.DisplayMember = "nombreEmpresa";
            cmbEmpresa.ValueMember = "pkIdEmpresa";
            cmbEmpresa.DataSource = con.FieldCombobox("pkIdEmpresa", "nombreEmpresa", "empresa", "estadoEmpresa");
            cmbEmpresa.SelectedIndex = -1;
        }
        private void bodega()
        {
            //llenado de combobox de bodega
            cmbBodega.DisplayMember = "descripcionBodega";
            cmbBodega.ValueMember = "pkIdBodega";
            cmbBodega.DataSource = con.FieldComboboxCondition("pkIdBodega", "descripcionBodega", "bodega", "fkIdEmpresa", lblEmpresa.Text,"estadoBodega");
            cmbBodega.SelectedIndex = -1;
        }
        public void CargarTotal()
        {
                dgvInventarioT.Rows.Clear();
                OdbcDataReader mostrar = con.funcSelectAll();
                try
                {
                    while (mostrar.Read())
                    {
                        dgvInventarioT.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2), mostrar.GetString(3), mostrar.GetString(4), mostrar.GetString(5));
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
        }
        private void color()
        {
            foreach (DataGridViewRow Myrow in dgvInventarioT.Rows)
            {
                if (Convert.ToInt32(Myrow.Cells[3].Value) <= Convert.ToInt32(Myrow.Cells[5].Value))
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Red;
                }
                if (Convert.ToInt32(Myrow.Cells[3].Value) >= Convert.ToInt32(Myrow.Cells[4].Value))
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CargarTotal();
            controlseleccion = 0;
        }
   
        private void button2_Click(object sender, EventArgs e)
        {
            if (rbProducto.Checked == true && txtProducto.Text != null && controlseleccion==1)
            {
                dgvInventarioT.Rows.Clear();
                OdbcDataReader mostrar = con.funcSelectSearchInvproduct(lblEmpresa.Text, cmbBodega.Text,txtProducto.Text);
                try
                {
                    while (mostrar.Read())
                    {
                        dgvInventarioT.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2), mostrar.GetString(3), mostrar.GetString(4), mostrar.GetString(5));
                        controlseleccion = 1;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            if (rbProducto.Checked == true && txtProducto.Text != null && controlseleccion == 0)
            {
                dgvInventarioT.Rows.Clear();
                OdbcDataReader mostrar = con.funcSelectSearchInvproductotal(txtProducto.Text);
                try
                {
                    while (mostrar.Read())
                    {
                        dgvInventarioT.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2), mostrar.GetString(3), mostrar.GetString(4), mostrar.GetString(5));
                        controlseleccion = 1;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            /*Existencia MINIMA*/
            if (rbExistencia.Checked == true && cbExistencia.Text=="MINIMA" && controlseleccion == 1)
            {
                dgvInventarioT.Rows.Clear();
                OdbcDataReader mostrar = con.funcSelectSearchInvproductminima(lblEmpresa.Text, cmbBodega.Text);
                try
                {
                    while (mostrar.Read())
                    {
                        dgvInventarioT.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2), mostrar.GetString(3), mostrar.GetString(4), mostrar.GetString(5));
                        controlseleccion = 1;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            if (rbExistencia.Checked == true && cbExistencia.Text == "MINIMA" && controlseleccion == 0)
            {
                dgvInventarioT.Rows.Clear();
                OdbcDataReader mostrar = con.funcSelectSearchInvproductotalminima();
                try
                {
                    while (mostrar.Read())
                    {
                        dgvInventarioT.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2), mostrar.GetString(3), mostrar.GetString(4), mostrar.GetString(5));
                        controlseleccion = 1;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            /*Existencia MAXIMA*/
            if (rbExistencia.Checked == true && cbExistencia.Text == "MAXIMA" && controlseleccion == 1)
            {
                dgvInventarioT.Rows.Clear();
                OdbcDataReader mostrar = con.funcSelectSearchInvproductmaxima(lblEmpresa.Text, cmbBodega.Text);
                try
                {
                    while (mostrar.Read())
                    {
                        dgvInventarioT.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2), mostrar.GetString(3), mostrar.GetString(4), mostrar.GetString(5));
                        controlseleccion = 1;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            if (rbExistencia.Checked == true && cbExistencia.Text == "MAXIMA" && controlseleccion == 0)
            {
                dgvInventarioT.Rows.Clear();
                OdbcDataReader mostrar = con.funcSelectSearchInvproductotalmaxima();
                try
                {
                    while (mostrar.Read())
                    {
                        dgvInventarioT.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2), mostrar.GetString(3), mostrar.GetString(4), mostrar.GetString(5));
                        controlseleccion = 1;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            color();
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.CamposNumerosYLetras(e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cmbEmpresa.Text != null && cmbBodega.Text != null) 
            {
                dgvInventarioT.Rows.Clear();
                OdbcDataReader mostrar = con.funcSelectSearchInv(lblEmpresa.Text, cmbBodega.Text);
                try
                {
                    while (mostrar.Read())
                    {
                        dgvInventarioT.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2), mostrar.GetString(3), mostrar.GetString(4), mostrar.GetString(5));
                        controlseleccion = 1;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }
        private void lblEmpresa_Click(object sender, EventArgs e)
        {
        }
        private void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpresa.SelectedIndex != -1)
            {
                lblEmpresa.Text = cmbEmpresa.SelectedValue.ToString();
            }
            bodega();
        }

        private void cmbEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbExistencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbBodega_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbExistencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Ayudas/MSantizo2.chm", "AyudaInventario.html");
        }
    }
}
