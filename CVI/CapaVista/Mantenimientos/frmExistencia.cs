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
    public partial class frmExistencia : Form
    {
        string UsuarioAplicacion;
        ControladorJM con = new ControladorJM();
        clsValidaciones vali = new clsValidaciones();
        public frmExistencia(string usuario)
        { 
            InitializeComponent();
            LoadCombobox();
            rbHabilitado.Checked = true;
            UsuarioAplicacion = usuario;
            navegador1.Usuario = UsuarioAplicacion;
            txtEstado.Text = "1";
           
        }
        void LoadCombobox()
        {
            //fill cb Producto
            cmbProducto.DisplayMember = "nombrePro";
            cmbProducto.ValueMember = "pkIdProducto";
            cmbProducto.DataSource = con.FieldCombobox("pkIdProducto", "nombrePro", "producto", "estadoPro");
            cmbProducto.SelectedIndex = -1;

            //fill cb Bodega Origen
            cmbBodega.DisplayMember = "descripcionBodega";
            cmbBodega.ValueMember = "pkIdBodega";
            cmbBodega.DataSource = con.FieldCombobox("pkIdBodega", "descripcionBodega", "bodega", "estadoBodega");
            cmbBodega.SelectedIndex = -1;

            //fill cb Sucursal
            cmbSucursal.DisplayMember = "nombreSucursal";
            cmbSucursal.ValueMember = "pkIdSucursal";
            cmbSucursal.DataSource = con.FieldCombobox("pkIdSucursal", "nombreSucursal", "sucursal", "estadoSucursal");
            cmbSucursal.SelectedIndex = -1;

            //fill cb Empresa
            cmbEmpresa.DisplayMember = "nombreEmpresa";
            cmbEmpresa.ValueMember = "pkIdEmpresa";
            cmbEmpresa.DataSource = con.FieldCombobox("pkIdEmpresa", "nombreEmpresa", "empresa", "estadoEmpresa");
            cmbEmpresa.SelectedIndex = -1;


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
            navegador1.tbl = "existencia";
            navegador1.campoEstado = "estado_existencia";
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
            navegador1.DatosActualizar = dgvExistencia;
            navegador1.procActualizarData();
            navegador1.procCargar();
            navegador1.ayudaRuta = "Ayudas/MBodega.chm";
            navegador1.ruta = "Mantenimiento Bodega.html";
            rbHabilitado.Checked = true;
            rbDeshabilitado.Checked = false;
            txtEstado.Text = "1";
        }

        private void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpresa.SelectedIndex != -1)
            {
                txtEmpresa.Text = cmbEmpresa.SelectedValue.ToString();
            }
            txtEstado.Text = "1";
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex != -1)
            {
                txtPro.Text = cmbProducto.SelectedValue.ToString();
            }
            txtEstado.Text = "1";
        }

        private void txtBodega_TextChanged(object sender, EventArgs e)
        {
            if (txtBodega.Text != "")
            {
                OdbcDataReader reader = con.FieldComboboxtxt( "descripcionBodega", "bodega", "estadoBodega","pkIdBodega", txtBodega.Text);
                if (reader.Read())
                {
                    cmbBodega.Text = reader.GetString(0);
                }
                else
                {
                    cmbBodega.SelectedIndex = -1;
                }
            }
        }

        private void txtSucursal_TextChanged(object sender, EventArgs e)
        {
            if (txtSucursal.Text != "")
            {
                OdbcDataReader reader = con.FieldComboboxtxt( "nombreSucursal", "sucursal", "estadoSucursal","pkIdSucursal", txtSucursal.Text);
                if (reader.Read())
                {
                    cmbSucursal.Text = reader.GetString(0);
                }
                else
                {
                    cmbSucursal.SelectedIndex = -1;
                }
            }
        }

        private void txtEmpresa_TextChanged(object sender, EventArgs e)
        {
            if (txtEmpresa.Text != "")
            {
                OdbcDataReader reader = con.FieldComboboxtxt( "nombreEmpresa", "empresa", "estadoEmpresa","pkIdEmpresa", txtEmpresa.Text);
                if (reader.Read())
                {
                    cmbEmpresa.Text = reader.GetString(0);
                }
                else
                {
                    cmbEmpresa.SelectedIndex = -1;
                }
            }
        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSucursal.SelectedIndex != -1)
            {
                txtSucursal.Text = cmbSucursal.SelectedValue.ToString();
            }
            txtEstado.Text = "1";
        }

        private void cmbBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBodega.SelectedIndex != -1)
            {
                txtBodega.Text = cmbBodega.SelectedValue.ToString();
            }
            txtEstado.Text = "1";
        }

        private void txtPro_TextChanged(object sender, EventArgs e)
        {
            if (txtPro.Text != "")
            {
                OdbcDataReader reader = con.FieldComboboxtxt( "nombrePro", "producto", "estadoPro", "pkIdProducto",txtPro.Text);
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

        private void frmExistencia_Load(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            
            txtEstado.Text = "1";
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void txtMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void txtMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }
    }
}
