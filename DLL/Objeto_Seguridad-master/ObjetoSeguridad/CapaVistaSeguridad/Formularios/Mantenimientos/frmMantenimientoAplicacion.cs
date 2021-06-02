using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using CapaControladorSeguridad;

namespace CapaVistaSeguridad.Formularios.Mantenimientos
{
    public partial class frmMantenimientoAplicacion : Form
    {
        clsAplicacionMantenimiento apliMantenimiento = new clsAplicacionMantenimiento();
        clsFuncionesAyudas funcionesAyudas = new clsFuncionesAyudas();
        string UsuarioAplicacion;
        string strAyudachm = "";
        string strAyudahtml = "";
        public frmMantenimientoAplicacion(string usuario)
        {
            InitializeComponent();
            UsuarioAplicacion = usuario;
            navegador1.Usuario = UsuarioAplicacion;
            rbHabilitado.Checked = true;
            CargarCombobox();
            CargarAyudas();
        }
        public void CargarCombobox()
        {
            //llenado de combobox de Modulo
            cmbModulo.DisplayMember = "nombre_modulo";
            cmbModulo.ValueMember = "pk_id_modulo";
            cmbModulo.DataSource = apliMantenimiento.funcObtenerCamposComboboxPais("pk_id_modulo", "nombre_modulo", "modulo", "estado_modulo");
            cmbModulo.SelectedIndex = -1;
        }
        public void CargarAyudas()
        {
            strAyudachm = funcionesAyudas.AyudaCHM(3);
            strAyudahtml = funcionesAyudas.AyudaHTML(3);
        }
        private void navegador1_Load(object sender, EventArgs e)
        {
            List<string> CamposTabla = new List<string>();
            List<Control> lista = new List<Control>();
            //List<Control> lista = new List<Control>();
            navegador1.aplicacion = 3;
            navegador1.tbl = "aplicacion";
            navegador1.campoEstado = "estado_aplicacion";

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
                    //  MessageBox.Show(""+C.Name)                   
                }
            }

            navegador1.control = lista;
            navegador1.formulario = this;
            navegador1.DatosActualizar = dgvAplicacion;
            navegador1.procActualizarData();
            navegador1.procCargar();
            navegador1.ayudaRuta = strAyudachm;
            navegador1.ruta = strAyudahtml;
            cmbModulo.SelectedIndex = -1;
        }

        private void btnBuscarCHM_Click(object sender, EventArgs e)
        {
            string strBuscarOriginal = "";
            string strAuxCHM = "";
            OpenFileDialog buscarchm = new OpenFileDialog();
            buscarchm.Title = "Buscar Archivo chm";
            buscarchm.Filter = "Archivo CHM(*.chm)|*.chm";
            if (buscarchm.ShowDialog() == DialogResult.OK)
            {
                strBuscarOriginal = buscarchm.FileName;
            }
            strAuxCHM = strBuscarOriginal.Replace(@"\", "/");
            txtAyudaCHM.Text = strAuxCHM.Replace(".chm", "");
        }

        private void btnBuscarHTML_Click(object sender, EventArgs e)
        {
            //string strBuscarOriginal = "";
            OpenFileDialog buscarhtml = new OpenFileDialog();
            buscarhtml.Title = "Buscar Archivo html";
            buscarhtml.Filter = "Archivo HTML(*.html)|*.html";
            if (buscarhtml.ShowDialog() == DialogResult.OK)
            {
                txtAyudaHTML.Text = System.IO.Path.GetFileName(buscarhtml.FileName); ;
            }
            //txtAyudaHTML.Text = strBuscarOriginal.Replace(@"\", @"\\");
        }

        private void txtNombreAplicacion_TextChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "1";
        }

        private void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModulo.SelectedIndex != -1)
            {
                txtIdModulo.Text = cmbModulo.SelectedValue.ToString();
            }
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
