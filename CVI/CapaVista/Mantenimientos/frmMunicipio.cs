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
    public partial class frmMunicipio : Form
    {
        string UsuarioAplicacion;
        clsValidaciones vali = new clsValidaciones();
        Controlador con = new Controlador();
        public frmMunicipio(string usuario)
        {
            InitializeComponent();
            CargarCombobox();
            rbHabilitado.Checked = true;
            UsuarioAplicacion = usuario;
            navegador1.Usuario = UsuarioAplicacion;
        }
        public void CargarCombobox()
        {
            //llenado de combobox de producto
            cmbDepar.DisplayMember = "nombreDepar";
            cmbDepar.ValueMember = "pkIdDepar";
            cmbDepar.DataSource = con.funcObtenerCamposComboboxPais("pkIdDepar", "nombreDepar", "departamento", "estadoDepar");
            cmbDepar.SelectedIndex = -1;
        }

        private void navegador1_Load(object sender, EventArgs e)
        {
            List<string> CamposTabla = new List<string>();
            List<Control> lista = new List<Control>();
            //llenado de  parametros para la aplicacion 
            navegador1.aplicacion = 303;
            navegador1.tbl = "municipio";
            navegador1.campoEstado = "estadoMuni";

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
            navegador1.DatosActualizar = dgvMunicipio;
            navegador1.procActualizarData();
            navegador1.procCargar();
            navegador1.ayudaRuta = "Ayudas/MSantizo.chm";
            navegador1.ruta = "AyudaMunicipio.html";
            rbHabilitado.Checked = true;
            rbDeshabilitado.Checked = false;
        }
        private void frmMunicipio_Load(object sender, EventArgs e)
        {
        }

        private void cmbDepar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepar.SelectedIndex != -1)
            {
                txtDepar.Text = cmbDepar.SelectedValue.ToString();
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "1";
        }

        private void rbDeshabilitado_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "0";
        }

        private void rbHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "1";
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CamposLetras(e);
        }
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CamposLetras(e);
        }
    }
}
