using CapaVistaSeguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;
using CapaVistaSeguridad.Formularios;
using CapaVistaSeguridad.Formularios.Mantenimientos;
using CapaVista.Mantenimientos;
using CapaVista.Procesos.Ordenes;

namespace CapaVista
{
    public partial class MDIPrincipal : Form
    {
        private int childFormNumber = 0;
        clsFuncionesSeguridad seguridad = new clsFuncionesSeguridad();//instancia para los permisos por aplicacion
        clsVistaBitacora bit = new clsVistaBitacora();//instancia para la bitacora.
        VariableGlobal glo = new VariableGlobal();

        public MDIPrincipal()
        {
            InitializeComponent();    
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtusuario.Text = frm.usuario();
                glo.usuariog = txtusuario.Text;
            }
        }
        private void MDIPrincipal_Load(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtusuario.Text = frm.usuario();
                glo.usuariog = txtusuario.Text;
            }

        }

        //Herramientas De Seguridad--------------------------------
        private void cambioDeContrasenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmMantenimientoAplicacion frmCambioContraseña = new frmMantenimientoAplicacion(txtusuario.Text);
            frmCambioContraseña frmCambioContraseña = new frmCambioContraseña(txtusuario.Text);
            frmCambioContraseña.MdiParent = this;
            frmCambioContraseña.Show();
            bit.user(txtusuario.Text);
            bit.insert("Ingreso A Cambio de Contraseña", 11);
        }

        private void mantenimientoDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("2", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Usuario", 2);
                frmMantenimientoUsuario mantenimientoUsuario = new frmMantenimientoUsuario(txtusuario.Text);
                mantenimientoUsuario.MdiParent = this;
                mantenimientoUsuario.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de ingresar a Mantenimiento Usuario", 2);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void mantenimiendoAplicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("3", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Aplicaciones", 3);
                frmAplicativo aplicativo = new frmAplicativo();
                aplicativo.MdiParent = this;
                aplicativo.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Aplicaciones", 3);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void asignacionPerfilYAplicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("6", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso a Asignacion de Perfil y Aplicaciones", 6);
                frmAsignacionDeAplicaciones perfil = new frmAsignacionDeAplicaciones();
                perfil.MdiParent = this;
                perfil.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar a Asignacion de perfil y aplicaciones", 6);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void mantenimientoModuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("8", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("ingreso a Mantenimiento Modulo", 8);
                frmModulo modulo = new frmModulo(txtusuario.Text);
                modulo.MdiParent = this;
                modulo.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Modulo", 8);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void mantenimientoAPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("4", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso a Mantenimiento Perfil", 4);
                frmMantenimientoPerfil perfil = new frmMantenimientoPerfil(txtusuario.Text);
                perfil.MdiParent = this;
                perfil.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Modulo", 4);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void asignacionDeAplicacionAPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("5", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso a Asignacion de Aplicaciones a Perfil", 5);
                frmAsignarAplicacionesAPerfil perfil = new frmAsignarAplicacionesAPerfil();
                perfil.MdiParent = this;
                perfil.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Asignacion de Aplicaciones a perfil", 5);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }
        //--------------------------------------------------------------

        //Menu Mantenimiento Proveedores-Seguridad
        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("3", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Proveedores", 3);
                frmProveedores mantenimiento = new frmProveedores(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Proveedores", 1501);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }
        //Mantenimiento Clientes -- Y Con seguridad.
        private void mantenimientoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("2501", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Clientes", 2501);
                frmCliente mantenimiento = new frmCliente(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Clientes", 2501);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }

        }

        private void mantenimientoEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("401", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Empresa", 401);
                frmEmpresa mantenimiento = new frmEmpresa(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Empresa", 401);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void mantenimientoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(seguridad.PermisosAcceso("402", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Sucursal", 402);
                frmSucursal mantenimiento = new frmSucursal(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Sucursal", 402);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void mantenimientoPaisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("301", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Pais", 301);
                frmPais mantenimiento = new frmPais(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Pais", 301);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void mantenimientoDepartamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("302", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Departamento", 302);
                frmDepartamento mantenimiento = new frmDepartamento(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Departamento", 302);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void mantenimientoMunicipioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("303", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Municipio", 303);
                frmMunicipio mantenimiento = new frmMunicipio(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Municipio", 303);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void mantenimientoLineaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("501", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Linea De Productos", 501);
                frmLineaProduc mantenimiento = new frmLineaProduc(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Linea De Productos", 501);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void mantenimientoMarcaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("502", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Marca De Productos", 502);
                frmMarcaPro mantenimiento = new frmMarcaPro(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Marca De Productos", 502);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void mantenimientoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("303", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Productos", 303);
                frmProducto mantenimiento = new frmProducto(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Productos", 303);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void mantenimientoBodegaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("303", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Productos", 303);
                frmBodega mantenimiento = new frmBodega(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Productos", 303);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procesos.Inventarios.frmInventarioTotal frm = new Procesos.Inventarios.frmInventarioTotal();
            frm.MdiParent = this;
            frm.Show();
        }

        private void movimientoDeInventariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procesos.MovimientoInventarios.frmMovimientoInventarios MovInventario = new Procesos.MovimientoInventarios.frmMovimientoInventarios();
            MovInventario.MdiParent = this;
            MovInventario.Show();
        }

        private void visualizarMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procesos.Inventarios.frmVistaMovimientoInventario frm = new Procesos.Inventarios.frmVistaMovimientoInventario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mantenimientoBodegaABodegaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("303", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Productos", 303);
                frmMovimientoInventario mantenimiento = new frmMovimientoInventario(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Productos", 303);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void mantenimientoExistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("303", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Productos", 303);
                frmExistencia mantenimiento = new frmExistencia(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Productos", 303);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void compraDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (seguridad.PermisosAcceso("303", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Productos", 303);
                frmOrdenes mantenimiento = new frmOrdenes(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Productos", 303);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void impresionComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("303", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Productos", 303);
                Procesos.OrdenesCompra.frmImpresionfacturaCompras mantenimiento = new Procesos.OrdenesCompra.frmImpresionfacturaCompras(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Productos", 303);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void estadoDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("303", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Productos", 303);
                Procesos.OrdenesCompra.frmEstadoCompras mantenimiento = new Procesos.OrdenesCompra.frmEstadoCompras(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Productos", 303);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void abonoCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("303", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Productos", 303);
                Procesos.OrdenesCompra.frmAbonoCuentas mantenimiento = new Procesos.OrdenesCompra.frmAbonoCuentas(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Productos", 303);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("8", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("ingreso a Mantenimiento Modulo", 8);
                frmAgregarAplicacion modulo = new frmAgregarAplicacion();
                modulo.MdiParent = this;
                modulo.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Modulo", 8);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }

        private void moverABodegasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procesos.OrdenesCompra.frmGuardar1 moverAExistencia = new Procesos.OrdenesCompra.frmGuardar1();
            moverAExistencia.MdiParent = this;
            moverAExistencia.Show();
        }

        private void reciboDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seguridad.PermisosAcceso("303", txtusuario.Text) == 1)
            {
                bit.user(txtusuario.Text);
                bit.insert("Ingreso A Mantenimiento Productos", 303);
                Procesos.Saldos.frmReciboCompras mantenimiento = new Procesos.Saldos.frmReciboCompras(txtusuario.Text);
                mantenimiento.MdiParent = this;
                mantenimiento.Show();
            }
            else
            {
                bit.user(txtusuario.Text);
                bit.insert("Trato de Ingresar A Mantenimiento Productos", 303);
                MessageBox.Show("El Usuario No Cuenta Con Permisos De Acceso A La Aplicación");
            }
        }
    }
}
