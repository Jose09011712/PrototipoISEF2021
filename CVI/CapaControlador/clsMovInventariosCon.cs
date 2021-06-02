using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControlador
{
    public class clsMovInventariosCon
    {
        clsMovInventariosMo Modelo = new clsMovInventariosMo();

        //Funcion obtener Id del suario
        public int funcObtenerIDUsuario(string Usuario)
        {
            string consulta = "SELECT pk_id_login from login where usuario_login = '" + Usuario + "' and estado_login = 1;";
            return Modelo.funcObtenerID(consulta);
        }
        //Funcion Para Consultar Detalles de la bodega.
        public OdbcDataReader funcConsulta()
        {
            string Consulta = "SELECT pkIdBodega, fkIdEmpresa, fkIdSucursal, direccionBodega FROM bodega where estadoBodega = 1;";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcCopnsultaClientes()
        {
            string Consulta = "SELECT pkIdCliente, nombreCliente, apellidoCliente, nitCliente FROM cliente where estadoCliente = 1;";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcCopnsultaProveedores()
        {
            string Consulta = "SELECT pkIdProv, nitProv, telProv, correoProv FROM proveedor where estadoProv = 1;";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcConsultaMov()
        {
            string Consulta = "SELECT * FROM movimientoinventario;";
            return Modelo.funcConsulta(Consulta);
        }
        //Funcion Para Consultar Detalles del Producto.
        public OdbcDataReader funcConsultaProducto()
        {
            string Consulta = "SELECT pkIdProducto, fkIdEmpresa, fkIdLineaPro, fkIdMarcaPro, nombrePro FROM producto where estadoPro = 1;";
            return Modelo.funcConsulta(Consulta);
        }

        //funcion Para Consultar Total de existencia de un producto.
        public OdbcDataReader funcExistencia(int idEmpresa, int idSucursal, int idBodega, int idProducto)
        {
            string strConsulta = "select cantidad_existencia, existencia_minima, existencia_maxima from existencia " +
                "where fkIdEmpresa = "+ idEmpresa + " and fkIdSucursal = "+ idSucursal + " and fkIdBodega = "+ idBodega + 
                " and fkIdPro = "+ idProducto + " and estado_existencia = 1;";
            return Modelo.funcConsulta(strConsulta);
        }
        public OdbcDataReader funcObtenerIdMovimientoEncabezado()
        {
            string strConsulta = "SELECT MAX(pkmovimientoe +1) FROM movimientoinventarioencabezado;";
            return Modelo.funcConsulta(strConsulta);
        }
        //funcion para movimeinto inventario.
        public string funcMovInventario(int idMovimiento, int idEmpresaO, int idSucursalO, int idBodegaO, int idEmpresaD, int idSucursalD, int idBodegaD, int idProducto, int Cantidad, string strRazon, int intAccion, int idUsuario)
        {
            string strConsulta = "call sp_MovimientoInventario(" + idMovimiento + "," + idEmpresaO + "," + idSucursalO + ", " + idBodegaO + 
                "," + idEmpresaD + "," + idSucursalD + "," + idBodegaD + "," + idProducto + "," + Cantidad + ",'" + strRazon + "'," + idUsuario + "," + intAccion + ");";
            Console.WriteLine(strConsulta);
            return Modelo.funcEjeQuerry(strConsulta);
        }
        //============================================================================================
        clsListaEncabezado encabezado = new clsListaEncabezado();//clase encabezado en capa modelo
        List<clsListaDetalle> listDetalle = new List<clsListaDetalle>();//lista para llenar el detalle 
        List<clsListaExistencia> listExistencia = new List<clsListaExistencia>();
        List<clsListaExistenciaMovBodegas> listBodegas = new List<clsListaExistenciaMovBodegas>();
        //============================================================================================
        public void funcLlenarListaEncabezado(string pkIdMovEnca, string fkEmpresa, string fkSucursal, string fkBodegaO, string fkBodegaD,
            string fkRazon, string fkProveedor, string fkCliente, string fkEncargado, string fecha)
        {
            encabezado.PkIdMovimientoEncabezado = pkIdMovEnca;
            encabezado.FkEmpresa = fkEmpresa;
            encabezado.FkSucursal = fkSucursal;
            encabezado.FkBodegaOrigen = fkBodegaO;
            encabezado.FkBodegaDestino = fkBodegaD;
            encabezado.FkRazon = fkRazon;
            encabezado.FkProveedor = fkProveedor;
            encabezado.FkCliente = fkCliente;
            encabezado.FkEncargado = fkEncargado;
            encabezado.FechaEncabezado = fecha;
            encabezado.EstadoEncabezado = "1";
        }
        public void funcLlenarlistasDetalle(string fkMovDetalle, string fkIdProducto, string Cantidad)
        {
            clsListaDetalle listaDetalle = new clsListaDetalle();
            listaDetalle.FkMovimientoDetalle = fkMovDetalle;
            listaDetalle.FkIdProducto = fkIdProducto;
            listaDetalle.Cantidad1 = Cantidad;
            listaDetalle.Estado = "1";
            listDetalle.Add(listaDetalle);
        }
        public void funcLlenarListaExistencia(string fkEmpresa, string fkSucursal, string fkBodega, string fkProducto, string Cantidad)
        {
            clsListaExistencia listaExistencia = new clsListaExistencia();
            listaExistencia.IdEmpresaOrigen = fkEmpresa;
            listaExistencia.IdSucursalOrigen = fkSucursal;
            listaExistencia.IdBodegaOrigen = fkBodega;
            listaExistencia.IdProducto = fkProducto;
            listaExistencia.Cantidad1 = Cantidad;
            listExistencia.Add(listaExistencia);
        }
        public void funcLlenarBodegas(string fkEmpresaO, string fkSucursalO, string fkBodegaO, 
            string fkEmpresaD, string fkSucursalD, string fkBodegaD, string fkProducto, string Cantidad)
        {
            clsListaExistenciaMovBodegas bodegas = new clsListaExistenciaMovBodegas();
            bodegas.IdEmpresaOrigen = fkEmpresaO;
            bodegas.IdEmpresaDestino = fkEmpresaD;
            bodegas.IdSucursalOrigen = fkSucursalO;
            bodegas.IdSucursalDestino = fkSucursalD;
            bodegas.IdBodegaOrigen = fkBodegaO;
            bodegas.IdBodegaDestino = fkBodegaD;
            bodegas.IdProducto = fkProducto;
            bodegas.Cantidad1 = Cantidad;
            listBodegas.Add(bodegas);
        }


        public void pruebarecorrido()
        {
            Modelo.PruebaRecorrido(encabezado, listDetalle);
        }        
       public void insertarEnTransaccion(string fkRazon)
        {
            bool prueba = Modelo.InsertarMovmientos(encabezado, listDetalle, listExistencia, listBodegas, fkRazon);           
        }
        public void funcEliminar()
        {
            listDetalle.Clear();
            listExistencia.Clear();
            listBodegas.Clear();
        }

    }
}
