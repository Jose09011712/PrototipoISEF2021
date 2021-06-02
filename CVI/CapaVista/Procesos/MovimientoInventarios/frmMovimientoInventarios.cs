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

namespace CapaVista.Procesos.MovimientoInventarios
{
    public partial class frmMovimientoInventarios : Form
    {
        //Llamadas a los form de seleccion==============================================
        frmSeleccionBodega SeleccionarBodega = new frmSeleccionBodega();
        frmSeleccionProveedor SeleccionarProveedor = new frmSeleccionProveedor();
        frmSeleccionCliente SeleccionarCliente = new frmSeleccionCliente();
        frmSeleccionProducto SeleccionarProducto = new frmSeleccionProducto();
        //==============================================================================
        clsMovInventariosCon Controlador = new clsMovInventariosCon();
        VariableGlobal glo = new VariableGlobal();
        DataTable Dt = new DataTable();
        DataTable DM = new DataTable();
        //==============================================================================
        int Contador;
        int intObtenerFinalDGV;
        string strIdUsuario;
        string strAcciones;
        //==============================================================================
        public frmMovimientoInventarios()
        {
            InitializeComponent();
            ObtenerIdUsuario();
            funcLimpiar();
            txtFechaCV.Text = dtpFecha.Value.ToString("dd/MM/yyyy"); 
            txtFechaM.Text = dtpFechaM.Value.ToString("dd/MM/yyyy");
        }   
        public void funcLimpiar()
        {
            ObtenerUltimoIDMovimientoEncabezado();
            rbCompra.Checked = false;
            rbVenta.Checked = false;
            rbDevCompra.Checked = false;
            rbDevVenta.Checked = false;
            gbVentas.Enabled = false;
            gbCompras.Enabled = false;
            btnBuscarProveedorCV.Enabled = false;
            btnBuscarClienteCV.Enabled = false;

            txtIdProveedorCV.Text = "";
            txtTelProveedorCV.Text = "";
            txtMailProveedorCV.Text = "";
            txtIdClienteCV.Text = "";
            txtNombreCV.Text = "";
            txtTelCV.Text = "";

            txtIdEmpresaCV.Text = "";
            txtIdSucursalCV.Text = "";
            txtIDBodegaCV.Text = "";
            txtDirecCV.Text = "";

            txtIdProductoCV.Text = "";
            txtProductoCV.Text = "";
            txtCantidadDisponibleCV.Text = "";
            txtCantMaxima.Text = "";
            txtCantMinima.Text = "";
            txtCantMoverCV.Text = "";
        }
        public void ObtenerIdUsuario()
        {
            txtIdUsuario.Text = Controlador.funcObtenerIDUsuario(glo.usuariog).ToString();
            strIdUsuario = Controlador.funcObtenerIDUsuario(glo.usuariog).ToString();
        }
        public void ObtenerUltimoIDMovimientoEncabezado()
        {
            OdbcDataReader mostrar = Controlador.funcObtenerIdMovimientoEncabezado();
            try
            {
                mostrar.Read();
                txtIdMovimiento.Text = mostrar.GetString(0);
                txtIdMovimientoM.Text = txtIdMovimiento.Text;
                mostrar.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                if (txtIdMovimiento.Text.Equals("") || txtIdMovimientoM.Equals(""))
                {
                    txtIdMovimiento.Text = "1";
                    txtIdMovimientoM.Text = txtIdMovimiento.Text;
                }
            }
        }
        //======================================================================
        //FUNCIONES CON EL DATAGRIDVIEW
        public void funcAgregarAlDGV()
        {
            DataRow dR_fila = Dt.NewRow();
            dR_fila["Numero_Encabezado"] = txtIdMovimiento.Text;
            dR_fila["ID_Producto"] = txtIdProductoCV.Text;
            dR_fila["cantidad"] = txtCantMoverCV.Text;
            Dt.Rows.Add(dR_fila);
        }
        public void funcEliminarFila()
        {
            if (dgvMover.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una fila antes de eliminar");
            }
            else
            {
                dgvMover.Rows.Remove(dgvMover.CurrentRow);
            }
        }

        public void funcLlenarDetalle()
        {
            for(int intContador = 0; intContador < dgvMover.Rows.Count - 1; intContador++)
            {
                Controlador.funcLlenarlistasDetalle(dgvMover.Rows[intContador].Cells[0].Value.ToString(),
                    dgvMover.Rows[intContador].Cells[1].Value.ToString(), dgvMover.Rows[intContador].Cells[2].Value.ToString());

                Controlador.funcLlenarListaExistencia(txtIdEmpresaCV.Text, txtIdSucursalCV.Text, txtIDBodegaCV.Text,
                    dgvMover.Rows[intContador].Cells[1].Value.ToString(), dgvMover.Rows[intContador].Cells[2].Value.ToString());
            }
        }
       
        public void funcLlenarEncabezado()
        {
            Controlador.funcLlenarListaEncabezado(txtIdMovimiento.Text, txtIdEmpresaCV.Text, txtIdSucursalCV.Text, txtIDBodegaCV.Text,
                txtIDBodegaCV.Text, txtAccionCV.Text, txtIdProveedorCV.Text, txtIdClienteCV.Text, txtIdUsuario.Text, txtFechaCV.Text);
        }
        //======================================================================
        //Funciones para seleccionar Datos
        //======================================================================
        //PESTAÑA 1
        public void funcBuscarProveedorCV()
        {
            if(SeleccionarProveedor.ShowDialog() == DialogResult.OK)
            {
                txtIdProveedorCV.Text = SeleccionarProveedor.dgvProveedor.Rows[SeleccionarProveedor.dgvProveedor.CurrentRow.Index].Cells[0].Value.ToString();
                txtTelProveedorCV.Text = SeleccionarProveedor.dgvProveedor.Rows[SeleccionarProveedor.dgvProveedor.CurrentRow.Index].Cells[1].Value.ToString();
                txtMailProveedorCV.Text = SeleccionarProveedor.dgvProveedor.Rows[SeleccionarProveedor.dgvProveedor.CurrentRow.Index].Cells[3].Value.ToString();
            }
        }
        public void funcBuscarClienteCV()
        {
            if (SeleccionarCliente.ShowDialog() == DialogResult.OK)
            {
                txtIdClienteCV.Text = SeleccionarCliente.dgvClientes.Rows[SeleccionarCliente.dgvClientes.CurrentRow.Index].Cells[0].Value.ToString();
                txtNombreCV.Text = SeleccionarCliente.dgvClientes.Rows[SeleccionarCliente.dgvClientes.CurrentRow.Index].Cells[1].Value.ToString();
                txtTelCV.Text = SeleccionarCliente.dgvClientes.Rows[SeleccionarCliente.dgvClientes.CurrentRow.Index].Cells[2].Value.ToString();
            }
        }
        //funcion consulta bodega origen
        public void funcBodegaCV()
        {
            if (SeleccionarBodega.ShowDialog() == DialogResult.OK)
            {
                txtIDBodegaCV.Text = SeleccionarBodega.dgvBodega.Rows[SeleccionarBodega.dgvBodega.CurrentRow.Index].Cells[0].Value.ToString();
                txtIdEmpresaCV.Text = SeleccionarBodega.dgvBodega.Rows[SeleccionarBodega.dgvBodega.CurrentRow.Index].Cells[1].Value.ToString();
                txtIdSucursalCV.Text = SeleccionarBodega.dgvBodega.Rows[SeleccionarBodega.dgvBodega.CurrentRow.Index].Cells[2].Value.ToString();
                txtDirecCV.Text = SeleccionarBodega.dgvBodega.Rows[SeleccionarBodega.dgvBodega.CurrentRow.Index].Cells[3].Value.ToString();
            }
        }
        //funcion para buscar Productos
        public void funcBuscarProducto()
        {
            try
            {
                if (SeleccionarProducto.ShowDialog() == DialogResult.OK)
                {
                    txtIdProductoCV.Text = SeleccionarProducto.dgvProducto.Rows[SeleccionarProducto.dgvProducto.CurrentRow.Index].Cells[0].Value.ToString();
                    txtProductoCV.Text = SeleccionarProducto.dgvProducto.Rows[SeleccionarProducto.dgvProducto.CurrentRow.Index].Cells[4].Value.ToString();
                    funcExistencias();
                }
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
    
        //======================================================================
        //======================================================================
        //func para verificar si hay existencia.
        public void funcExistencias()
            {
            OdbcDataReader mostrar = Controlador.funcExistencia(Int32.Parse(txtIdEmpresaCV.Text), Int32.Parse(txtIdSucursalCV.Text), Int32.Parse(txtIDBodegaCV.Text), Int32.Parse(txtIdProductoCV.Text));
            try
            {
                mostrar.Read();
                txtCantidadDisponibleCV.Text = mostrar.GetString(0);
                txtCantMinima.Text = mostrar.GetString(1);
                txtCantMaxima.Text = mostrar.GetString(2);
                
            }
            catch (Exception err)
            {
                DialogResult drResultadoMensaje;
                drResultadoMensaje = MessageBox.Show("Producto No Existente En Bodega Seleccionada", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (drResultadoMensaje == DialogResult.OK)
                {
                    txtCantidadDisponibleCV.Text = "";
                    txtCantMinima.Text = "";
                    txtCantMaxima.Text = "";
                }               
                Console.WriteLine(err.Message);
            }
        }
        //======================================================================
        //======================================================================
        //funcion para verificar si es compra o venta.
        public void funcAccion()
        {
            if(rbCompra.Checked == true)
            {
                txtAccionCV.Text = "1";

                gbVentas.Enabled = false;
                btnBuscarClienteCV.Enabled = false;
                txtIdClienteCV.Text = "127";
                txtNombreCV.Text = "No aplica";
                txtTelCV.Text = "No Aplica";

                gbCompras.Enabled = true;
                btnBuscarProveedorCV.Enabled = true;
                txtIdProveedorCV.Text = "";
                txtTelProveedorCV.Text = "";
                txtMailProveedorCV.Text = "";
            }
            else if(rbDevCompra.Checked == true)
            {
                txtAccionCV.Text = "3";

                gbVentas.Enabled = false;
                btnBuscarClienteCV.Enabled = false;
                txtIdClienteCV.Text = "127";
                txtNombreCV.Text = "No aplica";
                txtTelCV.Text = "No Aplica";

                gbCompras.Enabled = true;
                btnBuscarProveedorCV.Enabled = true;
                txtIdProveedorCV.Text = "";
                txtTelProveedorCV.Text = "";
                txtMailProveedorCV.Text = "";
            }
            else if(rbVenta.Checked == true)
            {
                txtAccionCV.Text = "2";

                gbVentas.Enabled = true;
                btnBuscarClienteCV.Enabled = true;
                txtIdClienteCV.Text = "";
                txtNombreCV.Text = "";
                txtTelCV.Text = "";

                gbCompras.Enabled = false;
                btnBuscarProveedorCV.Enabled = false;
                txtIdProveedorCV.Text = "127";
                txtTelProveedorCV.Text = "No Aplica";
                txtMailProveedorCV.Text = "No Aplica";
            }else if(rbDevVenta.Checked== true)
            {
                txtAccionCV.Text = "4";

                gbVentas.Enabled = true;
                btnBuscarClienteCV.Enabled = true;
                txtIdClienteCV.Text = "";
                txtNombreCV.Text = "";
                txtTelCV.Text = "";

                gbCompras.Enabled = false;
                btnBuscarProveedorCV.Enabled = false;
                txtIdProveedorCV.Text = "127";
                txtTelProveedorCV.Text = "No Aplica";
                txtMailProveedorCV.Text = "No Aplica";
            }
        }
        //Funcion Aplicar Movimientos
        public void funcAplicarMove(int intAccion, int intInserDelete)
        {
            int intIdMovimiento;
            int intIdEmpresaO;
            int intIdSucursalO;
            int intIdBodegaO;

            int intIdEmpresaD;
            int intIdSucursalD;
            int intIdBodegaD;

            int intIdProducto;
            string strRazon = "";
            int intCantidad;

        }
        
        //funcion para validar campos vacios.
        public int funcValidarCampos()
        {
            Contador = 0;
            if (txtIdEmpresaCV.Text.Equals(""))
            {
                
                DialogResult drResultadoMensaje;
                drResultadoMensaje = MessageBox.Show("Bodega De Origen No Esta Seleccionada\nSeleccione La Bodega De Origen", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (drResultadoMensaje == DialogResult.OK)
                {
                    Contador += 1;
                    funcBodegaCV();
                }
            }
            else { Contador += 0; }

            if (txtIdProductoCV.Text.Equals(""))
            {
                if (txtIdEmpresaCV.Text.Equals(""))
                {
                    DialogResult drResultadoMensaje;
                    drResultadoMensaje = MessageBox.Show("Bodega De Origen No Esta Seleccionada\nSeleccione La Bodega De Origen", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (drResultadoMensaje == DialogResult.OK)
                    {
                        Contador += 1;
                        funcBodegaCV();
                    }
                }
                else
                {
                    DialogResult drResultadoMensajes;
                    drResultadoMensajes = MessageBox.Show("Producto No Seleccionado\nSeleccione Un Producto", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (drResultadoMensajes == DialogResult.OK)
                    {
                        Contador += 1;
                        funcBuscarProducto();
                    }
                }

            }
            else { Contador += 0; }

            if (txtCantMoverCV.Text.Equals(""))
            {
                DialogResult drResultadoMensaje;
                drResultadoMensaje = MessageBox.Show("No Ha Ingresado La Cantidad A Mover\nIngrese La Cantidad A Mover", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (drResultadoMensaje == DialogResult.OK)
                {
                    Contador += 1;
                    txtCantMoverCV.Text = "";
                }
            }
            else { Contador += 0; }
            
            if(txtAccionCV.Text.Equals("1") || txtAccionCV.Text.Equals("4"))
            {
                if ((Convert.ToInt32(txtCantMoverCV.Text) + Convert.ToInt32(txtCantidadDisponibleCV.Text)) > Convert.ToInt32(txtCantMaxima.Text))
                {
                    DialogResult drResultadoMensaje;
                    drResultadoMensaje = MessageBox.Show("Supera la Capacidad Maxima en Bodega\nIngrese Una Cantidad Menor", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (drResultadoMensaje == DialogResult.OK)
                    {
                        Contador += 1;
                        txtCantMoverCV.Text = "";
                    }
                }              
            }
            else
            { Contador += 0; }
            if (txtAccionCV.Text.Equals("2") || txtAccionCV.Text.Equals("3"))
            {
                if ((Convert.ToInt32(txtCantidadDisponibleCV.Text) - Convert.ToInt32(txtCantMoverCV.Text)) < Convert.ToInt32(txtCantMinima.Text))
                {
                    DialogResult drResultadoMensaje;
                    drResultadoMensaje = MessageBox.Show("Supera la Capacidad Minima en Bodega\nIngrese Una Cantidad Menor", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (drResultadoMensaje == DialogResult.OK)
                    {
                        Contador += 1;
                        txtCantMoverCV.Text = "";
                    }
                }
            }
            return Contador;
        }
        //======================================================================
        //======================================================================
        //PESTAÑA 2
        public void funcBodegaOrigen()
        {
            if (SeleccionarBodega.ShowDialog() == DialogResult.OK)
            {
                txtIdBodegaOM.Text = SeleccionarBodega.dgvBodega.Rows[SeleccionarBodega.dgvBodega.CurrentRow.Index].Cells[0].Value.ToString();
                txtIdEmpresaOM.Text = SeleccionarBodega.dgvBodega.Rows[SeleccionarBodega.dgvBodega.CurrentRow.Index].Cells[1].Value.ToString();
                txtidSucursalOM.Text = SeleccionarBodega.dgvBodega.Rows[SeleccionarBodega.dgvBodega.CurrentRow.Index].Cells[2].Value.ToString();
                txtDireccionOM.Text = SeleccionarBodega.dgvBodega.Rows[SeleccionarBodega.dgvBodega.CurrentRow.Index].Cells[3].Value.ToString();
            }
        }
        //funcion Para Validar Bodega Destino 
        public void funcValidarDestino()
        {
            if(txtIdEmpresaOM.Text.Equals(txtIdEmpresaDM.Text) && txtidSucursalOM.Text.Equals(txtIdSucursalDM.Text) && txtIdBodegaOM.Text.Equals(txtIdBodegaDM.Text))
            {
                txtIdEmpresaDM.Text = "";
                txtIdSucursalDM.Text = "";
                txtIdBodegaDM.Text = "";
                txtDireccionDM.Text = "";
                DialogResult drResultadoMensaje;
                drResultadoMensaje = MessageBox.Show("Bodega Destino No Puede Ser Igual Al Origen\nSeleccione Otro Destino", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (drResultadoMensaje == DialogResult.OK)
                {
                    funcBodegaDestino();
                }
            }
        }
        public void funcBodegaDestino()
        {
            if (SeleccionarBodega.ShowDialog() == DialogResult.OK)
            {
                txtIdBodegaDM.Text = SeleccionarBodega.dgvBodega.Rows[SeleccionarBodega.dgvBodega.CurrentRow.Index].Cells[0].Value.ToString();
                txtIdEmpresaDM.Text = SeleccionarBodega.dgvBodega.Rows[SeleccionarBodega.dgvBodega.CurrentRow.Index].Cells[1].Value.ToString();
                txtIdSucursalDM.Text = SeleccionarBodega.dgvBodega.Rows[SeleccionarBodega.dgvBodega.CurrentRow.Index].Cells[2].Value.ToString();
                txtDireccionDM.Text = SeleccionarBodega.dgvBodega.Rows[SeleccionarBodega.dgvBodega.CurrentRow.Index].Cells[3].Value.ToString();
                funcValidarDestino();
            }
        }
        public void funcBuscarProductoM()
        {
            try
            {
                if (SeleccionarProducto.ShowDialog() == DialogResult.OK)
                {
                    txtIdProductoM.Text = SeleccionarProducto.dgvProducto.Rows[SeleccionarProducto.dgvProducto.CurrentRow.Index].Cells[0].Value.ToString();
                    txtProductoM.Text = SeleccionarProducto.dgvProducto.Rows[SeleccionarProducto.dgvProducto.CurrentRow.Index].Cells[4].Value.ToString();
                    funcExistenciasM();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public void funcExistenciasM()
        {
            OdbcDataReader mostrar = Controlador.funcExistencia(Int32.Parse(txtIdEmpresaOM.Text), Int32.Parse(txtidSucursalOM.Text), Int32.Parse(txtIdBodegaOM.Text), Int32.Parse(txtIdProductoM.Text));
            try
            {
                mostrar.Read();
                txtCantDisponibleM.Text = mostrar.GetString(0);
                txtCantMinimaM.Text = mostrar.GetString(1);
                txtCantMaximaM.Text = mostrar.GetString(2);

            }
            catch (Exception err)
            {
                DialogResult drResultadoMensaje;
                drResultadoMensaje = MessageBox.Show("Producto No Existente En Bodega Seleccionada", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (drResultadoMensaje == DialogResult.OK)
                {
                    txtCantDisponibleM.Text = "";
                    txtCantMinimaM.Text = "";
                    txtCantMaximaM.Text = "";
                }
                Console.WriteLine(err.Message);
            }
        }
        public int funcValidacionM()
        {
            Contador = 0;
            if (txtIdEmpresaOM.Text.Equals(""))
            {
                DialogResult drResultadoMensaje;
                drResultadoMensaje = MessageBox.Show("Bodega De Origen No Esta Seleccionada\nSeleccione La Bodega De Origen", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (drResultadoMensaje == DialogResult.OK)
                {
                    Contador += 1;
                    funcBodegaOrigen();
                }
            }
            else { Contador += 0; }
            if (txtIdEmpresaDM.Text.Equals(""))
            {
                DialogResult drResultadoMensaje;
                drResultadoMensaje = MessageBox.Show("Bodega De Destinio No Esta Seleccionada\nSeleccione La Bodega De Origen", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (drResultadoMensaje == DialogResult.OK)
                {
                    Contador += 1;
                    funcBodegaDestino();
                }
            }
            else { Contador += 0; }

            if (txtIdProductoM.Text.Equals(""))
            {
                if (txtIdEmpresaOM.Text.Equals(""))
                {
                    DialogResult drResultadoMensaje;
                    drResultadoMensaje = MessageBox.Show("Bodega De Origen No Esta Seleccionada\nSeleccione La Bodega De Origen", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (drResultadoMensaje == DialogResult.OK)
                    {
                        Contador += 1;
                        funcBodegaOrigen();
                    }
                }
                else
                {
                    DialogResult drResultadoMensajes;
                    drResultadoMensajes = MessageBox.Show("Producto No Seleccionado\nSeleccione Un Producto", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (drResultadoMensajes == DialogResult.OK)
                    {
                        Contador += 1;
                        funcBuscarProductoM();
                    }
                }

            }
            else { Contador += 0; }

            if (txtCantMoverM.Text.Equals(""))
            {
                DialogResult drResultadoMensaje;
                drResultadoMensaje = MessageBox.Show("No Ha Ingresado La Cantidad A Mover\nIngrese La Cantidad A Mover", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (drResultadoMensaje == DialogResult.OK)
                {
                    Contador += 1;
                    txtCantMoverM.Text = "";
                }
            }
            else { Contador += 0; }


            return Contador;
        }
        
        public void funcAgregarAlDGVM()
        {
            DataRow dR_fila = DM.NewRow();
            dR_fila["Numero_Encabezado"] = txtIdMovimientoM.Text;
            dR_fila["ID_Producto"] = txtIdProductoM.Text;
            dR_fila["cantidad"] = txtCantMoverM.Text;
            DM.Rows.Add(dR_fila);
        }
        public void funcEliminarFilaM()
        {
            if (dgvMoverM.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una fila antes de eliminar");
            }
            else
            {
                dgvMoverM.Rows.Remove(dgvMoverM.CurrentRow);
            }
        }
        public void funcLlenarDetalleM()
        {
            for (int intContador = 0; intContador < dgvMoverM.Rows.Count - 1; intContador++)
            {
                Controlador.funcLlenarlistasDetalle(dgvMoverM.Rows[intContador].Cells[0].Value.ToString(),
                    dgvMoverM.Rows[intContador].Cells[1].Value.ToString(), dgvMoverM.Rows[intContador].Cells[2].Value.ToString());

                Controlador.funcLlenarBodegas(txtIdEmpresaOM.Text, txtidSucursalOM.Text, txtIdBodegaOM.Text,
                    txtIdEmpresaDM.Text, txtIdSucursalDM.Text, txtIdBodegaDM.Text,
                    dgvMoverM.Rows[intContador].Cells[1].Value.ToString(), dgvMoverM.Rows[intContador].Cells[2].Value.ToString());
            }
        }
        public void funcLlenarEncabezadoM()
        {
            Controlador.funcLlenarListaEncabezado(txtIdMovimientoM.Text, txtIdEmpresaOM.Text, txtidSucursalOM.Text, txtIdBodegaOM.Text,
                txtIdBodegaDM.Text, "5", "127", "127", txtIdUsuario.Text, txtFechaM.Text);
        }
        public void funcLimpiarM()
        {
            ObtenerUltimoIDMovimientoEncabezado();
            txtIdEmpresaOM.Text = "";
            txtIdEmpresaDM.Text = "";
            txtidSucursalOM.Text = "";
            txtIdSucursalDM.Text = "";
            txtIdBodegaOM.Text = "";
            txtIdBodegaDM.Text = "";
            txtDireccionOM.Text = "";
            txtDireccionDM.Text = "";

            txtIdProductoM.Text = "";
            txtProductoM.Text = "";
            txtCantDisponibleM.Text = "";
            txtCantMaximaM.Text = "";
            txtCantMinimaM.Text = "";
            txtCantMoverM.Text = "";

        }
        //======================================================================
        //FUNCIONES DEL FORMULARIO==============================================
        //======================================================================

        private void frmMovimientoInventarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmente desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dgvMover_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            intObtenerFinalDGV = e.RowIndex;
        }
        
        //======================================================================
        //BOTONES===============================================================
        //======================================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (funcValidarCampos() == 0)
            {
                funcAgregarAlDGV();
            }
            else
            {
                return;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            funcEliminarFila();
        }

        private void btnGuardarRegistros_Click(object sender, EventArgs e)
        {
            funcLlenarEncabezado();
            funcLlenarDetalle();
            //Controlador.pruebarecorrido();
            Controlador.insertarEnTransaccion(txtAccionCV.Text);
            Controlador.funcEliminar();
            funcLimpiar();
            Dt.Rows.Clear();
        }

        private void btnBuscarProveedorCV_Click(object sender, EventArgs e)
        {
            funcBuscarProveedorCV();
        }

        private void btnBuscarClienteCV_Click(object sender, EventArgs e)
        {
            funcBuscarClienteCV();
        }

        private void btnBuscarBodegaCV_Click(object sender, EventArgs e)
        {
            funcBodegaCV();
        }

        private void btnBuscarProductoCV_Click(object sender, EventArgs e)
        {
            funcBuscarProducto();
        }
        //======================================================================
        //RADIO BUTONS==========================================================
        //======================================================================

        private void rbCompra_CheckedChanged(object sender, EventArgs e)
        {
            funcAccion();
        }

        private void rbVenta_CheckedChanged(object sender, EventArgs e)
        {
            funcAccion();
        }

        private void rbDevCompra_CheckedChanged(object sender, EventArgs e)
        {
            funcAccion();
        }

        private void rbDevVenta_CheckedChanged(object sender, EventArgs e)
        {
            funcAccion();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            txtFechaCV.Text = dtpFecha.Value.ToString("dd/MM/yyyy");
        }

        private void frmMovimientoInventarios_Load(object sender, EventArgs e)
        {
            Dt.Columns.Add("Numero_Encabezado");
            Dt.Columns.Add("ID_Producto");
            Dt.Columns.Add("cantidad");
            dgvMover.DataSource = Dt;

            DM.Columns.Add("Numero_Encabezado");
            DM.Columns.Add("ID_Producto");
            DM.Columns.Add("cantidad");
            dgvMoverM.DataSource = DM;
        }
        //======================================================================
        //PESTAÑA 2=============================================================
        //======================================================================
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscarOrigenM_Click(object sender, EventArgs e)
        {
            funcBodegaOrigen();
        }

        private void txtDestinoM_Click(object sender, EventArgs e)
        {
            funcBodegaDestino();
        }

        private void btnBuscarProducM_Click(object sender, EventArgs e)
        {
            funcBuscarProductoM();
        }

        private void btnAgregarM_Click(object sender, EventArgs e)
        {
            if (funcValidacionM() == 0)
            {
                funcAgregarAlDGVM();
            }
            else
            {
                return;
            }
        }

        private void btnEliminarM_Click(object sender, EventArgs e)
        {
            funcEliminarFilaM();
        }

        private void btnGuardarM_Click(object sender, EventArgs e)
        {
            funcLlenarEncabezadoM();
            funcLlenarDetalleM();
            Controlador.insertarEnTransaccion("5");
            Controlador.funcEliminar();
            funcLimpiarM();
            DM.Rows.Clear();
        }

        private void dgvMoverM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            intObtenerFinalDGV = e.RowIndex;
        }
    }
}
