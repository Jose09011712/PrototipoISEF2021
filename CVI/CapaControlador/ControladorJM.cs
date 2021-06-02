using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControlador
{
    public class ControladorJM
    {
        Sentencias Modelo = new Sentencias();
        //Get data from table to cb
        public DataTable FieldCombobox(string field1, string field2, string table, string status)
        {
            string Comando = string.Format("SELECT " + field1 + " ," + field2 + " FROM " + table + " WHERE " + status + "= 1;");
            return Modelo.funcObtenerCamposCombobox(Comando);
        }
        public DataTable FieldComboboxCondition(string field1, string field2, string table, string conditionfield, string conditiondata, string status)
        {
            string Comando = string.Format("SELECT " + field1 + " ," + field2 + " FROM " + table + " WHERE "+ conditionfield +"=" + conditiondata + " AND " + status + "= 1;");
            return Modelo.funcObtenerCamposCombobox(Comando);
        }
        public OdbcDataReader FieldComboboxtxt(string field1, string table, string status, string field2, string condition)
        {
            string Comando = string.Format("SELECT " + field1 + " FROM " + table + " WHERE " + status + "= 1 AND "+ field2 +" = '"+condition+"';");
            return Modelo.funcConsulta(Comando);
        }
        public OdbcDataReader funcSelect(string Tabla)
        {
            string Consulta = "SELECT * FROM " + Tabla + ";";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcSelectAll ()
        {
            string Consulta = "select pro.nombrePro as producto, em.nombreEmpresa as empresa, bo.descripcionBodega as bodega, ex.cantidad_existencia as existencia, ex.existencia_maxima as maxima, ex.existencia_minima as minima from (existencia ex inner join empresa em on em.pkIdEmpresa = ex.fkIdEmpresa inner join bodega bo on bo.pkIdBodega= ex.fkIdBodega inner join producto pro on pro.pkIdProducto= ex.fkIdPro) where estado_existencia = 1;";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcSelectSearchInv(string empresa, string bodega)
        {
            string Consulta = "select pro.nombrePro as producto, em.nombreEmpresa as empresa, bo.descripcionBodega as bodega, ex.cantidad_existencia as existencia, ex.existencia_maxima as maxima, ex.existencia_minima as minima from (existencia ex inner join empresa em on em.pkIdEmpresa = ex.fkIdEmpresa inner join bodega bo on bo.pkIdBodega = ex.fkIdBodega inner join producto pro on pro.pkIdProducto = ex.fkIdPro)WHERE ex.fkidEmpresa = " + empresa+" AND bo.descripcionBodega = '"+bodega+"' AND ex.estado_existencia = 1;";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcSelectSearchInvproduct(string empresa, string bodega, string product)
        {
            string Consulta = "select pro.nombrePro as producto, em.nombreEmpresa as empresa, bo.descripcionBodega as bodega, ex.cantidad_existencia as existencia, ex.existencia_maxima as maxima, ex.existencia_minima as minima from (existencia ex inner join empresa em on em.pkIdEmpresa = ex.fkIdEmpresa inner join bodega bo on bo.pkIdBodega = ex.fkIdBodega inner join producto pro on pro.pkIdProducto = ex.fkIdPro)WHERE ex.fkidEmpresa = " + empresa + " AND bo.descripcionBodega = '" + bodega + "' AND ex.estado_existencia = 1 AND pro.nombrePro LIKE '%"+product+"%';";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcSelectSearchInvproductotal(string product)
        {
            string Consulta = "select pro.nombrePro as producto, em.nombreEmpresa as empresa, bo.descripcionBodega as bodega, ex.cantidad_existencia as existencia, ex.existencia_maxima as maxima, ex.existencia_minima as minima from (existencia ex inner join empresa em on em.pkIdEmpresa = ex.fkIdEmpresa inner join bodega bo on bo.pkIdBodega = ex.fkIdBodega inner join producto pro on pro.pkIdProducto = ex.fkIdPro)WHERE ex.estado_existencia = 1 AND pro.nombrePro LIKE '%" + product + "%';";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcSelectSearchInvproductminima(string empresa, string bodega)
        {
            string Consulta = "select pro.nombrePro as producto, em.nombreEmpresa as empresa, bo.descripcionBodega as bodega, ex.cantidad_existencia as existencia, ex.existencia_maxima as maxima, ex.existencia_minima as minima from (existencia ex inner join empresa em on em.pkIdEmpresa = ex.fkIdEmpresa inner join bodega bo on bo.pkIdBodega = ex.fkIdBodega inner join producto pro on pro.pkIdProducto = ex.fkIdPro)WHERE ex.fkidEmpresa = " + empresa + " AND bo.descripcionBodega = '" + bodega + "' AND ex.estado_existencia = 1 AND ex.existencia_minima >= cantidad_existencia;";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcSelectSearchInvproductotalminima()
        {
            string Consulta = "select pro.nombrePro as producto, em.nombreEmpresa as empresa, bo.descripcionBodega as bodega, ex.cantidad_existencia as existencia, ex.existencia_maxima as maxima, ex.existencia_minima as minima from (existencia ex inner join empresa em on em.pkIdEmpresa = ex.fkIdEmpresa inner join bodega bo on bo.pkIdBodega = ex.fkIdBodega inner join producto pro on pro.pkIdProducto = ex.fkIdPro)WHERE ex.estado_existencia = 1 AND ex.existencia_minima >= cantidad_existencia;";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcSelectSearchInvproductmaxima(string empresa, string bodega)
        {
            string Consulta = "select pro.nombrePro as producto, em.nombreEmpresa as empresa, bo.descripcionBodega as bodega, ex.cantidad_existencia as existencia, ex.existencia_maxima as maxima, ex.existencia_minima as minima from (existencia ex inner join empresa em on em.pkIdEmpresa = ex.fkIdEmpresa inner join bodega bo on bo.pkIdBodega = ex.fkIdBodega inner join producto pro on pro.pkIdProducto = ex.fkIdPro)WHERE ex.fkidEmpresa = " + empresa + " AND bo.descripcionBodega = '" + bodega + "' AND ex.estado_existencia = 1 AND existencia_maxima < cantidad_existencia;";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcSelectSearchInvproductotalmaxima()
        {
            string Consulta = "select pro.nombrePro as producto, em.nombreEmpresa as empresa, bo.descripcionBodega as bodega, ex.cantidad_existencia as existencia, ex.existencia_maxima as maxima, ex.existencia_minima as minima from (existencia ex inner join empresa em on em.pkIdEmpresa = ex.fkIdEmpresa inner join bodega bo on bo.pkIdBodega = ex.fkIdBodega inner join producto pro on pro.pkIdProducto = ex.fkIdPro)WHERE ex.estado_existencia = 1 AND existencia_maxima < cantidad_existencia;";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcSelectllenardgvOrdenes() //vista movimiento inventario llenar todo
        {
            string Consulta = "select movd.fkmovimiento, movd.fkidproducto, pro.nombrePro, moven.fkbodegaorigen, moven.fkbodegadestino, movd.cantidad, rm.nombrerazon, logi.usuario_login  from movimientoinventariodetalle movd inner join movimientoinventarioencabezado moven on movd.fkmovimiento=moven.pkmovimientoe inner join producto pro on movd.fkidproducto=pro.pkIdProducto inner join login logi on logi.pk_id_login= moven.fkencargado inner join razonmovimiento rm on rm.pkrazon=moven.fkrazon;";
            return Modelo.funcConsulta(Consulta);
        }

        public OdbcDataReader funcSelectllenardgvMovimientofiltro(string campo, string dato)
        {
            string Consulta = "select movd.fkmovimiento, movd.fkidproducto, pro.nombrePro, moven.fkbodegaorigen, moven.fkbodegadestino, movd.cantidad, rm.nombrerazon, logi.usuario_login  from movimientoinventariodetalle movd inner join movimientoinventarioencabezado moven on movd.fkmovimiento=moven.pkmovimientoe inner join producto pro on movd.fkidproducto=pro.pkIdProducto inner join login logi on logi.pk_id_login= moven.fkencargado inner join razonmovimiento rm on rm.pkrazon=moven.fkrazon where "+campo+" = "+dato+";";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcInsertarEncabezadoCompras( string idproveedor, string idempleado, string idempresa, string idsucursal, string idbodega, string fecha, string totalcompra, string idtipocompra, string idmetodopago, string estado)
        {
            string Consulta = "INSERT INTO compraencabezado( `fkIdProv`, `fkIdEmpleado`, `fkIdEmpresa`, `fkIdSucursal`,`fkIdBodegadestino`, `fechaCompra`, `totalCompra`, `fktipocompra`, `fkmetodoPago`, `estadoCompra`) VALUES(" + idproveedor + "," + idempleado + "," + idempresa + "," + idsucursal + "," + idbodega + ",'" + fecha + "'," + totalcompra + "," + idtipocompra + "," + idmetodopago + "," + estado + ");";
            return Modelo.funcInsertar(Consulta);
        }
        public OdbcDataReader funConsultaobteneridEncabezadoCompras()
        {
            string Consulta = "SELECT pkNoDocumentoEnca FROM compraencabezado ORDER BY 1 DESC LIMIT 1;"; 
            return Modelo.funcInsertar(Consulta);
        }

        public OdbcDataReader funcSelectllenardgvProductosProveedor(string proveedor)
        {
            string Consulta = "select PRO.pkIdProducto, PRO.nombrePro, PRO.precioPro, PRO.descripcionPro FROM PRODUCTO PRO INNER JOIN PROVEEDOR PROVEE ON PRO.fkProv = PROVEE.pkIdProv WHERE PROVEE.pkIdProv = " + proveedor + "";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcSelectllenardgvMovimiento()
        {
            string Consulta = "select MOV.PKMOVIMIENTO, fkidproducto, PROD.nombrePro, MOV.fkbodegaorigen, MOV.fkbodegadestino, MOV.cantidad, MOV.RAZON, LOGIN.usuario_login from MOVIMIENTOINVENTARIO MOV INNER JOIN producto PROD ON MOV.FKIDPRODUCTO = PROD.pkIdProducto INNER JOIN LOGIN ON LOGIN.pk_id_login = MOV.fkencargado;";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcInsertarDetalleCompras( string idencabezado, string idproductodetalle, string cantidad, string costo ,string estado)
        {
            string Consulta = "INSERT INTO compradetalle( `fkNoDocumentoEnca`, `fkIdPro`, `cantidadCompraDe`, `costoCompraDe`,`estado`) VALUES(" + idencabezado + "," + idproductodetalle + "," + cantidad + "," + costo + "," + estado + ");";
            return Modelo.funcInsertar(Consulta);
        }
        public OdbcDataReader funcActualizarencabezado(string idencabezado, string total)
        {
            string Consulta = "UPDATE `compraencabezado` SET `totalCompra` = "+total+" WHERE(`pkNoDocumentoEnca` = "+idencabezado+");";
            return Modelo.funcInsertar(Consulta);
        }
        public OdbcDataReader funcMostrarimpresion(string idimpresionencabezado)
        {
            string Consulta = "SELECT cd.fkIdPro, pro.nombrePro ,cd.cantidadCompraDe, pro.precioPro, (cd.cantidadCompraDe * pro.precioPro)AS subtotal, emp.nombreEmpresa, su.nombreSucursal, bo.descripcionBodega FROM  compradetalle cd inner join compraencabezado ce on cd.fkNoDocumentoEnca = ce.pkNoDocumentoEnca inner join producto pro on pro.pkIdProducto = fkIdPro inner join empresa emp on emp.pkIdEmpresa = ce.fkIdEmpresa inner join sucursal su on su.pkIdSucursal = ce.fkIdSucursal inner join bodega bo on bo.pkIdBodega = ce.fkIdBodegadestino WHERE ce.pkNoDocumentoEnca = "+idimpresionencabezado+";";
            return Modelo.funcInsertar(Consulta);
        }

        public OdbcDataReader funcMostrarEncabezado()
        {
            string Consulta = "SELECT ce.pkNoDocumentoEnca, pro.direccionProv , ce.fechaCompra, ce.totalCompra , tc.nombretipocompra FROM compraencabezado ce inner join tipocompra tc on tc.pktipocompra = fktipocompra inner join proveedor pro on pro.pkIdProv = fkIdProv;";
            return Modelo.funcInsertar(Consulta);
        }
        public OdbcDataReader funcActualizarestado(string idencabezadoestado, string estado)
        {         
            string Consulta = "UPDATE `compraencabezado` SET `fktipocompra` = "+estado+" WHERE(`pkNoDocumentoEnca` = "+idencabezadoestado+")";
            return Modelo.funcInsertar(Consulta);
        }
        public OdbcDataReader funcEstadosfiltroCompras(string estado)
        {
            string Consulta = "SELECT ce.pkNoDocumentoEnca, pro.direccionProv , ce.fechaCompra, ce.totalCompra , tc.nombretipocompra FROM compraencabezado ce inner join tipocompra tc on tc.pktipocompra = fktipocompra inner join proveedor pro on pro.pkIdProv = fkIdProv WHERE tc.nombretipocompra = '"+estado+"' ;";
            return Modelo.funcInsertar(Consulta);
        }
        public OdbcDataReader funcInsertarSaldocompras(string idcabezado, string saldo)
        {
            string Consulta = "INSERT INTO `saldoscomrpa` (`fkNoDocumentoEnca`, `saldo`) VALUES ('"+idcabezado+"', '"+saldo+"');";
            return Modelo.funcInsertar(Consulta);
        }
        public OdbcDataReader funcSelectllenardgvmorosos()
        {
            string Consulta = "SELECT ce.pkNoDocumentoEnca, pro.direccionProv, ce.fechaCompra, ce.totalCompra FROM compraencabezado ce inner join saldoscomrpa sc on sc.fkNoDocumentoEnca = ce.pkNoDocumentoEnca inner join proveedor pro on pro.pkIdProv = ce.fkIdProv WHERE ce.fkmetodoPago ='4' AND sc.saldo > 0;";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcSelectllenardgvmorososfiltro(string idencabezado)
        {
            string Consulta = "SELECT ce.pkNoDocumentoEnca, pro.direccionProv, ce.fechaCompra, ce.totalCompra FROM compraencabezado ce inner join saldoscomrpa sc on sc.fkNoDocumentoEnca = ce.pkNoDocumentoEnca inner join proveedor pro on pro.pkIdProv = ce.fkIdProv WHERE ce.fkmetodoPago ='4' AND sc.saldo > 0 AND ce.pkNoDocumentoEnca = '"+idencabezado+"';";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcSelectllenardgvhistorico(string idencabezado)
        {
            string Consulta = "SELECT ce.pkNoDocumentoEnca, pro.direccionProv, ce.fechaCompra, ce.totalCompra FROM compraencabezado ce inner join saldoscomrpa sc on sc.fkNoDocumentoEnca = ce.pkNoDocumentoEnca inner join proveedor pro on pro.pkIdProv = ce.fkIdProv WHERE ce.fkmetodoPago ='4' AND sc.saldo > 0 AND ce.pkNoDocumentoEnca = '" + idencabezado + "';";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcInsertarSaldocompras2(string fecha, string idencabezado, string metodo, string saldo, string abono)
        {
            string Consulta = "INSERT INTO saldohistoricocompra (`fechamovimientocompra`, `fkNoDocumentoEnca`, `fkmetodopago`, `saldoanterior`, `abono`) VALUES ('"+fecha+"', "+idencabezado+","+metodo+ ","+saldo+ ","+abono+");";
            return Modelo.funcInsertar(Consulta);
        }
        public OdbcDataReader funcSelectllenardgvmorososfiltro2(string idencabezado)
        {
            string Consulta = "SELECT sh.pksaldohistoricocompra, sh.fechamovimientocompra, sh.fkNoDocumentoEnca,sh.saldoanterior, sh.abono, (sh.saldoanterior - sh.abono)AS saldoactual, sc.saldo FROM saldohistoricocompra sh inner join saldoscomrpa sc on sh.fkNoDocumentoEnca = sc.fkNoDocumentoEnca WHERE sh.fkNoDocumentoEnca = "+idencabezado+";";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcInsertarsaldocomprasdefinitivo(string saldo, string abono)
        {
            string Consulta = "UPDATE`saldoscomrpa` SET `saldo` = " + abono + " WHERE (`fkNoDocumentoEnca` = " + saldo + ");";
            return Modelo.funcInsertar(Consulta);

        }
        public OdbcDataReader funcSelectllenardgvMovimientofiltroordenes(string campo1, string dato1)
        {
            string Consulta = "select PRO.pkIdProducto, PRO.nombrePro, PRO.precioPro, PRO.descripcionPro FROM PRODUCTO PRO INNER JOIN PROVEEDOR PROVEE ON PRO.fkProv = PROVEE.pkIdProv WHERE "+campo1+"=" +dato1+";";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcMostrarEncabezadoCompras()
        {
            string Consulta = "SELECT ce.pkNoDocumentoEnca, pro.direccionProv, emp.nombreEmpresa, ce.fechaCompra, ce.totalCompra FROM compraencabezado ce inner join proveedor pro on pro.pkIdProv = ce.fkIdProv inner join empresa emp on emp.pkIdEmpresa = ce.fkIdEmpresa;";
            return Modelo.funcInsertar(Consulta);
        }
        public OdbcDataReader funcMostrarRecibo()
        {
            string Consulta = "SELECT ce.pkNoDocumentoEnca, pro.direccionProv, emp.nombreEmpresa, ce.fechaCompra, ce.totalCompra, tc.nombretipocompra, mp.descripcionMetodo FROM compraencabezado ce inner join metodopago mp on mp.pkIdMetodoPago = ce.fkmetodoPago inner join proveedor pro on pro.pkIdProv = ce.fkIdProv inner join empresa emp on emp.pkIdEmpresa = ce.fkIdEmpresa inner join tipocompra tc on tc.pktipocompra = ce.fktipocompra inner join saldoscomrpa scc on scc.fkNoDocumentoEnca = ce.pkNoDocumentoEnca WHERE scc.saldo > 0; ";
            return Modelo.funcInsertar(Consulta);
        }
        public OdbcDataReader funcInsertarSaldocompras5(string fecha, string idencabezado, string saldo, string abono, string notas)
        {
            string Consulta = "INSERT INTO `saldohistoricocompra` (`fechamovimientocompra`, `fkNoDocumentoEnca`, `fkmetodopago`, `saldoanterior`, `abono`, `notas`) VALUES('" + fecha + "', " + idencabezado + ",1," + saldo + "," + abono +","+notas+");";
            return Modelo.funcInsertar(Consulta);
        }
    }
}
