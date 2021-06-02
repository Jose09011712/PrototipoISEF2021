using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControlador
{
    public class clsMoverAExistencias
    {
        clsMovInventariosMo moverInventarios = new clsMovInventariosMo();
        public OdbcDataReader funcMostrarEncabezado(string striCodigo)
        {
            string Consulta = "SELECT ce.pkNoDocumentoEnca, ce.fkIdEmpresa, em.nombreEmpresa, ce.fkIdSucursal, su.nombreSucursal, " +
                "ce.fkIdBodegadestino, bo.direccionBodega, pro.direccionProv , ce.fechaCompra, ce.totalCompra , tc.nombretipocompra " +
                "FROM compraencabezado ce inner join tipocompra tc on tc.pktipocompra = ce.fktipocompra inner join proveedor pro " +
                "on pro.pkIdProv = ce.fkIdProv inner join empresa em on em.pkIdEmpresa = ce.fkIdEmpresa inner join sucursal su " +
                "on su.pkIdSucursal = ce.fkIdSucursal inner join bodega bo on ce.fkIdBodegadestino = bo.pkIdBodega where ce.fktipocompra = " + striCodigo + ";";
            return moverInventarios.funcConsulta(Consulta);
        }
        public OdbcDataReader funcMostrarExistencia()
        {
            string Consulta = "select ex.pkIdExis, ex.fkIdEmpresa, em.nombreEmpresa, ex.fkIdSucursal, su.nombreSucursal, " +
                "ex.fkIdBodega, bo.direccionBodega, ex.fkIdPro, pro.nombrePro, ex.cantidad_existencia, ex.existencia_minima, " +
                "ex.existencia_maxima from existencia ex inner join empresa em on ex.fkIdEmpresa = em.pkIdEmpresa " +
                "inner join sucursal su on su.pkIdSucursal = ex.fkIdSucursal inner join  bodega bo on " +
                "bo.pkIdBodega = ex.fkIdBodega inner join producto pro on pro.pkIdProducto = ex.fkIdPro;";
            return moverInventarios.funcConsulta(Consulta);
        }

        public OdbcDataReader funcMostrarEncabezadoFiltro(string strFiltro)
        {
            string strConsulta = "SELECT ce.pkNoDocumentoEnca, ce.fkIdEmpresa, em.nombreEmpresa, ce.fkIdSucursal, su.nombreSucursal, " +
                "ce.fkIdBodegadestino, bo.direccionBodega, pro.direccionProv , ce.fechaCompra, ce.totalCompra , tc.nombretipocompra " +
                "FROM compraencabezado ce inner join tipocompra tc on tc.pktipocompra = ce.fktipocompra inner join proveedor pro " +
                "on pro.pkIdProv = ce.fkIdProv inner join empresa em on em.pkIdEmpresa = ce.fkIdEmpresa inner join sucursal su " +
                "on su.pkIdSucursal = ce.fkIdSucursal inner join bodega bo on ce.fkIdBodegadestino = bo.pkIdBodega where ce.fktipocompra = 5 " +
                "and ce.pkNoDocumentoEnca = " + strFiltro + ";";
            return moverInventarios.funcConsulta(strConsulta);
        }

        public OdbcDataReader funcMostrarDetalle(string strNoDocumento)
        {
            string strConsulta = "SELECT cd.fkNoDocumentoEnca, cd.fkIdPro, pr.nombrePro, cd.cantidadCompraDe, cd.costoCompraDe from " +
                "compradetalle cd inner join producto pr on cd.fkIdPro = pr.pkIdProducto where cd.fkNoDocumentoEnca = " + strNoDocumento + "";
            return moverInventarios.funcConsulta(strConsulta);
        }
        public string funcVerificarExistencia(string idEmpresa, string idSucursal, string idBodega, string idProducto)
        {
            string strConsulta = "select cantidad_existencia from existencia " +
                "where fkIdEmpresa = " + idEmpresa + " and fkIdSucursal = " + idSucursal + " and fkIdBodega = " + idBodega +
                " and fkIdPro = " + idProducto + " and estado_existencia = 1;";
            return moverInventarios.funcConsExistencia(strConsulta);
        }
        //============================================================================================
        List<clsListaMoverAExistencia> Detalle = new List<clsListaMoverAExistencia>();//lista para llenar el detalle 
        public void funcLlenarListaExistencia(string fkEmpresa, string fkSucursal, string fkBodega, string fkProducto, string Cantidad, string accion)
        {
            clsListaMoverAExistencia mover = new clsListaMoverAExistencia();
            mover.IdEmpresaOrigen = fkEmpresa;
            mover.IdSucursalOrigen = fkSucursal;
            mover.IdBodegaOrigen = fkBodega;
            mover.IdProducto = fkProducto;
            mover.Cantidad1 = Cantidad;
            mover.IntAccion = accion;
            Detalle.Add(mover);
        }

        public void insertarEnTransaccion(string NoDocuemtno)
        {
            moverInventarios.InsertarMovmientosBodega(Detalle,NoDocuemtno);
            Detalle.Clear();
        }
    }
}
