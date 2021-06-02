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
    public partial class frmDepartamento : Form
    {
        string UsuarioAplicacion;
        clsValidaciones vali = new clsValidaciones();
        public frmDepartamento(String usuario)
        {
            InitializeComponent();
            rbHabilitado.Checked = true;
            UsuarioAplicacion = usuario;
            navegador1.Usuario = UsuarioAplicacion;
        }

        private void navegador1_Load(object sender, EventArgs e)
        {
            List<string> CamposTabla = new List<string>();
            List<Control> lista = new List<Control>();
            //llenado de  parametros para la aplicacion 
            navegador1.aplicacion = 302;
            navegador1.tbl = "departamento";
            navegador1.campoEstado = "estadoDepar";

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
            navegador1.DatosActualizar = dgvDepartamento;
            navegador1.procActualizarData();
            navegador1.procCargar();
            navegador1.ayudaRuta = "Ayudas/MSantizo.chm";
            navegador1.ruta = "AyudaDepartamento.html";
            rbHabilitado.Checked = true;
            rbDeshabilitado.Checked = false;
        }

        private void txtdeparnombre_TextChanged(object sender, EventArgs e)
        {
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

        private void txtdeparnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CamposLetras(e);
        }

        private void txtdescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CamposLetras(e);
        }

        private void txtdescripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
