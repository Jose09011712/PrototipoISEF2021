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

namespace CapaVista.Mantenimientos
{
    public partial class frmMovimientoInventario : Form
    {
        string UsuarioAplicacion;
        ControladorJM con = new ControladorJM();
        clsValidaciones validaciones = new clsValidaciones();
        public frmMovimientoInventario(string usuario)
        {
            InitializeComponent();
            rbHabilitado.Checked = true;
            UsuarioAplicacion = usuario;
            navegador1.Usuario = UsuarioAplicacion;
            rbHabilitado.Checked = true;
            txtEstado.Text = "1";
            LoadCombobox();
        }
        void LoadCombobox()
        {
            //fill cb Producto
            cmbProducto.DisplayMember = "nombrePro";
            cmbProducto.ValueMember = "pkIdProducto";
            cmbProducto.DataSource = con.FieldCombobox("pkIdProducto", "nombrePro", "producto", "estadoPro");
            cmbProducto.SelectedIndex = -1;
            //fill cb Bodega Origen
            cmbBodegaO.DisplayMember = "descripcionBodega";
            cmbBodegaO.ValueMember = "pkIdBodega";
            cmbBodegaO.DataSource = con.FieldCombobox("pkIdBodega", "descripcionBodega", "bodega", "estadoBodega");
            cmbBodegaO.SelectedIndex = -1;
            //fill cb Bodega Destino
            cmbBodegaD.DisplayMember = "descripcionBodega";
            cmbBodegaD.ValueMember = "pkIdBodega";
            cmbBodegaD.DataSource = con.FieldCombobox("pkIdBodega", "descripcionBodega", "bodega", "estadoBodega");
            cmbBodegaD.SelectedIndex = -1;
        }

        private void rbHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "1";
        }

        private void rbDeshabilitado_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "0";
        }

        private void navegador1_Load(object sender, EventArgs e)
        {
            List<string> CamposTabla = new List<string>();
            List<Control> lista = new List<Control>();
            //llenado de  parametros para la aplicacion 
            navegador1.aplicacion = 303;
            navegador1.tbl = "movimientoinventario";
            navegador1.campoEstado = "estado";
            //se agregan los componentes del formulario a la lista tipo control
            foreach (Control C in this.Controls)
            {
                if (C.Tag != null)
                {
                    if (C.Tag.ToString() == "saltar")
                    {

                    }
                    else
                    {
                        if (C is TextBox)
                        {
                            lista.Add(C);
                        }
                        else if (C is ComboBox)
                        {
                            lista.Add(C);
                        }
                        else if (C is DateTimePicker)
                        {
                            lista.Add(C);
                        }
                    }
                }
            }
            navegador1.control = lista;
            navegador1.formulario = this;
            navegador1.DatosActualizar = dgvMovimiento;
            navegador1.procActualizarData();
            navegador1.procCargar();
            navegador1.ayudaRuta = "Ayudas/MBodega.chm";
            navegador1.ruta = "Mantenimiento Bodega.html";
            rbHabilitado.Checked = true;
            rbDeshabilitado.Checked = false;
            txtEstado.Text = "1";
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex != -1)
            {
                txtProducto.Text = cmbProducto.SelectedValue.ToString();
            }
            txtEstado.Text = "1";
        }

        private void cmbBodegaO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBodegaO.SelectedIndex != -1)
            {
                txtBodegaO.Text = cmbBodegaO.SelectedValue.ToString();
            }
            txtEstado.Text = "1";
        }

        private void cmbBodegaD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBodegaD.SelectedIndex != -1)
            {
                txtBodegaD.Text = cmbBodegaD.SelectedValue.ToString();
            }
            txtEstado.Text = "1";
        }

        private void cmbEncargado_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text != "")
            {
                OdbcDataReader reader = con.FieldComboboxtxt( "nombrePro", "producto", "estadoPro","pkIdProducto", txtProducto.Text);
                if (reader.Read())
                {
                    cmbProducto.Text = reader.GetString(0);
                }
                else
                {
                    cmbProducto.SelectedIndex = -1;
                }
            }
        }

        private void txtBodegaO_TextChanged(object sender, EventArgs e)
        {
            if (txtBodegaO.Text != "")
            {
                OdbcDataReader reader = con.FieldComboboxtxt( "descripcionBodega", "bodega", "estadoBodega","pkIdBodega", txtBodegaO.Text);
                if (reader.Read())
                {
                    cmbBodegaO.Text = reader.GetString(0);
                }
                else
                {
                    cmbBodegaO.SelectedIndex = -1;
                }
            }
        }

        private void txtBodegaD_TextChanged(object sender, EventArgs e)
        {
            if (txtBodegaD.Text != "")
            {
                OdbcDataReader reader = con.FieldComboboxtxt( "descripcionBodega", "bodega", "estadoBodega","pkIdBodega", txtBodegaD.Text);
                if (reader.Read())
                {
                    cmbBodegaD.Text = reader.GetString(0);
                }
                else
                {
                    cmbBodegaD.SelectedIndex = -1;
                }
            }
        }

        private void txtEncargado_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
