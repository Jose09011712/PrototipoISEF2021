using CapaControlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista.Mantenimientos
{
    public partial class frmCliente : Form
    {
        string UsuarioAplicacion;
        Controlador con = new Controlador();
        clsValidaciones vali = new clsValidaciones();
        public frmCliente(string usuario)
        {
            InitializeComponent();
            CargarCombobox1();
            CargarCombobox2();
            rbHabilitado.Checked = true;
            UsuarioAplicacion = usuario;
            navegador1.Usuario = UsuarioAplicacion;
        }
        public void CargarCombobox1()
        {
            //llenado de combobox de producto
            cmbDepar.DisplayMember = "nombreDepar";
            cmbDepar.ValueMember = "pkIdDepar";
            cmbDepar.DataSource = con.funcObtenerCamposComboboxPais("pkIdDepar", "nombreDepar", "departamento", "estadoDepar");
            cmbDepar.SelectedIndex = -1;
        }
        public void CargarCombobox2()
        {
            //llenado de combobox de producto
            cmbMuni.DisplayMember = "nombreMuni";
            cmbMuni.ValueMember = "pkIdMuni";
            cmbMuni.DataSource = con.funcObtenerCamposComboboxPais("pkIdMuni", "nombreMuni", "municipio", "estadoMuni");
            cmbMuni.SelectedIndex = -1;
        }

        private void navegador1_Load(object sender, EventArgs e)
        {
            List<string> CamposTabla = new List<string>();
            List<Control> lista = new List<Control>();
            //llenado de  parametros para la aplicacion 
            navegador1.aplicacion = 3;
            navegador1.tbl = "cliente";
            navegador1.campoEstado = "estadoCliente";

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
            navegador1.DatosActualizar = dgvCliente;
            navegador1.procActualizarData();
            navegador1.procCargar();
            navegador1.ayudaRuta = "Ayudas/MSantizo.chm";
            navegador1.ruta = "AyudaCliente.html";
            rbHabilitado.Checked = true;
            rbDeshabilitado.Checked = false;
        }

        private void rbHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "1";
        }

        private void rbDeshabilitado_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "0";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepar.SelectedIndex != -1)
            {
                txtDepar.Text = cmbDepar.SelectedValue.ToString();
            }
        }

        private void cmbMuni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMuni.SelectedIndex != -1)
            {
                txtMuni.Text = cmbMuni.SelectedValue.ToString();
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "1";
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CamposLetras(e);
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CamposLetras(e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CamposNumerosYLetras(e);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void txtNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
