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
    public partial class frmBodega : Form
    {
        string UsuarioAplicacion;
        ControladorJM con = new ControladorJM();
        clsValidaciones validaciones = new clsValidaciones();
        public frmBodega(string usuario)
        {
            InitializeComponent();
            LoadCombobox();
            rbHabilitado.Checked = true;
            UsuarioAplicacion = usuario;
            navegador1.Usuario = UsuarioAplicacion;
            rbHabilitado.Checked = true;
            txtEstado.Text = "1";
        }
        void LoadCombobox()
        {
            //fill cb Empresa
            cmbEmpresa.DisplayMember = "nombreEmpresa";
            cmbEmpresa.ValueMember = "pkIdEmpresa";
            cmbEmpresa.DataSource = con.FieldCombobox("pkIdEmpresa", "nombreEmpresa", "empresa", "estadoEmpresa");
            cmbEmpresa.SelectedIndex = -1;
            //fill cb Sucursal
            cmbSucursal.DisplayMember = "nombreSucursal";
            cmbSucursal.ValueMember = "pkIdSucursal";
            cmbSucursal.DataSource = con.FieldCombobox("pkIdSucursal", "nombreSucursal", "sucursal", "estadoSucursal");
            cmbSucursal.SelectedIndex = -1;
            //fill cb Departamento
            cmbDepartamento.DisplayMember = "nombreDepar";
            cmbDepartamento.ValueMember = "pkIdDepar";
            cmbDepartamento.DataSource = con.FieldCombobox("pkIdDepar", "nombreDepar", "departamento", "estadoDepar");
            cmbDepartamento.SelectedIndex = -1;
            //fill cb Municipio
            cmbMunicipio.DisplayMember = "nombreMuni";
            cmbMunicipio.ValueMember = "pkIdMuni";
            cmbMunicipio.DataSource = con.FieldCombobox("pkIdMuni", "nombreMuni", "municipio", "estadoMuni");
            cmbMunicipio.SelectedIndex = -1;
        }

        private void navegador1_Load(object sender, EventArgs e)
        {
            List<string> CamposTabla = new List<string>();
            List<Control> lista = new List<Control>();
            //llenado de  parametros para la aplicacion 
            navegador1.aplicacion = 303;
            navegador1.tbl = "bodega";
            navegador1.campoEstado = "estadoBodega";
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
            navegador1.DatosActualizar = dgvBodega;
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

        private void txtEmpresa_TextChanged(object sender, EventArgs e)
        {
            if (txtEmpresa.Text != "")
            {
                OdbcDataReader reader = con.FieldComboboxtxt("nombreEmpresa", "empresa", "estadoEmpresa", "pkIdEmpresa", txtEmpresa.Text);
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

        private void txtSucursal_TextChanged(object sender, EventArgs e)
        {
            if (txtSucursal.Text != "")
            {
                OdbcDataReader reader = con.FieldComboboxtxt("nombreSucursal", "sucursal", "estadoSucursal", "pkIdSucursal", txtSucursal.Text);
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

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSucursal.SelectedIndex != -1)
            {
                txtSucursal.Text = cmbSucursal.SelectedValue.ToString();
            }
            txtEstado.Text = "1";
        }

        private void txtDepartamento_TextChanged(object sender, EventArgs e)
        {
            if (txtDepartamento.Text != "")
            {
                OdbcDataReader reader = con.FieldComboboxtxt("nombreDepar", "departamento", "estadoDepar", "pkIdDepar", txtDepartamento.Text);
                if (reader.Read())
                {
                    cmbDepartamento.Text = reader.GetString(0);
                }
                else
                {
                    cmbDepartamento.SelectedIndex = -1;
                }
            }
        }

        private void txtMunicipio_TextChanged(object sender, EventArgs e)
        {
            if (txtMunicipio.Text != "")
            {
                OdbcDataReader reader = con.FieldComboboxtxt("nombreMuni", "municipio", "estadoMuni", "pkIdMuni", txtMunicipio.Text);
                if (reader.Read())
                {
                    cmbMunicipio.Text = reader.GetString(0);
                }
                else
                {
                    cmbMunicipio.SelectedIndex = -1;
                }
            }
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartamento.SelectedIndex != -1)
            {
                txtDepartamento.Text = cmbDepartamento.SelectedValue.ToString();
            }
            txtEstado.Text = "1";
        }

        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMunicipio.SelectedIndex != -1)
            {
                txtMunicipio.Text = cmbMunicipio.SelectedValue.ToString();
            }
            txtEstado.Text = "1";
        }

        private void rbHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "1";
        }

        private void rbDeshabilitado_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "0";
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.CampoNumerico(e);
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.CamposLetras(e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.CamposNumerosYLetras(e);
        }
    }
}
