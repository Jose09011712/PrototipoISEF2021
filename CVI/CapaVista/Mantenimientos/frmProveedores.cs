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

namespace CapaVista
{
    public partial class frmProveedores : Form
    {
        string UsuarioAplicacion;
        Controlador con = new Controlador();
        clsValidaciones vali = new clsValidaciones();

        public frmProveedores(string usuario)
        {
            InitializeComponent();
            CargarCombobox();
            rbHabilitado.Checked = true;
            UsuarioAplicacion = usuario;
            navegador1.Usuario = UsuarioAplicacion;
            txtTelefono.Text = "1";
        }
        public void CargarCombobox()
        {
            //llenado de combobox de producto
            cmb_pais.DisplayMember = "nombrePais";
            cmb_pais.ValueMember = "pkIdPais";
            cmb_pais.DataSource = con.funcObtenerCamposComboboxPais("pkIdPais", "nombrePais", "pais", "estadoPais");
            cmb_pais.SelectedIndex = -1;
        }

        private void navegador1_Load(object sender, EventArgs e)
        {
            List<string> CamposTabla = new List<string>();
            List<Control> lista = new List<Control>();
            //llenado de  parametros para la aplicacion 
            navegador1.aplicacion = 1501;
            navegador1.tbl = "proveedor";
            navegador1.campoEstado = "estadoProv";

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
            navegador1.DatosActualizar = dgvProveedores;
            navegador1.procActualizarData();
            navegador1.procCargar();
            navegador1.ayudaRuta = "Ayudas/MSantizo.chm";
            navegador1.ruta = "AyudaProveedores.html";
            rbHabilitado.Checked = true;
           rbDeshabilitado.Checked = false;
        }

        private void frmMantenimiento_Load(object sender, EventArgs e)
        {

        }

        private void cmb_pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_pais.SelectedIndex != -1)
            {
                txtPais.Text = cmb_pais.SelectedValue.ToString();
            }
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "1";
        }

        private void rbDeshabilitado_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "0";
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CamposNumerosYLetras(e);
        }

        private void txtNit_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CampoNumerico(e);
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CamposNumerosYLetras(e);
        }
    }
}
