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
    public partial class frmRazonMovimiento : Form
    {
        string UsuarioAplicacion;
        public frmRazonMovimiento(string usuario)
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
            navegador1.aplicacion = 401;
            navegador1.tbl = "razonmovimiento";
            navegador1.campoEstado = "estadorazon";

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
            navegador1.DatosActualizar = dgvRazon;
            navegador1.procActualizarData();
            navegador1.procCargar();
            navegador1.ayudaRuta = "AyudaES/AyudasES.chm";
            navegador1.ruta = "AyudaEmpresa.html";
            rbHabilitado.Checked = true;
            rbDeshabilitado.Checked = false;
        }

        private void rbIngreso_CheckedChanged(object sender, EventArgs e)
        {
            txtAccion.Text = "+";
        }

        private void rbEgreso_CheckedChanged(object sender, EventArgs e)
        {
            txtAccion.Text = "-";
        }

        private void rbMovimientos_CheckedChanged(object sender, EventArgs e)
        {
            txtAccion.Text = "=";
        }

        private void rbHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "1";
        }

        private void rbDeshabilitado_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "0";
        }
    }
}
