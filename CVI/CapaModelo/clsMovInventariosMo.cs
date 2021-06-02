using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaModelo
{
    public class clsMovInventariosMo
    {
        Conexion cn = new Conexion();
        OdbcCommand Comm;
        OdbcTransaction transaction = null;
        string strSql = "";
        string Mensaje = "";
        public int funcObtenerID(string strConsulta)
        {
            try
            {
                int intIdUsuario = 0;
                Comm = new OdbcCommand(strConsulta, cn.conexion());
                OdbcDataReader reader = Comm.ExecuteReader();
                reader.Read();
                intIdUsuario = reader.GetInt32(0);
                reader.Close();
                return intIdUsuario;
            }
            catch (Exception Error)
            {
                Console.WriteLine("Error Consulta Id Usuario: " + Error);
                return 0;
            }
        }
        //Funcion Consulta General
        public OdbcDataReader funcConsulta(string Consulta)
        {
            try
            {
                Comm = new OdbcCommand(Consulta, cn.conexion());
                OdbcDataReader reader = Comm.ExecuteReader();
                return reader;
            }
            catch (Exception Error)
            {
                Console.WriteLine("Error en Consulta General: " + Error);
                return null;
            }
        }
        //Consulta para calcular existencia
        public string funcConsExistencia(string Consulta)
        {
            string intExistencia = "";
            try
            {
                
                Comm = new OdbcCommand(Consulta, cn.conexion());
                OdbcDataReader reader = Comm.ExecuteReader();
                reader.Read();
                intExistencia = reader.GetString(0);
                reader.Close();
                return intExistencia;
            }
            catch (Exception Error)
            {
                Console.WriteLine("Error Consulta Existencia: ");
                return intExistencia;
            }
        }

        //Funcion Para ejecutar querrys
        public string funcEjeQuerry(string strConsulta)
        {
            try
            {
                Comm = new OdbcCommand(strConsulta, cn.conexion());
                OdbcDataReader reader = Comm.ExecuteReader();
                reader.Read();
                reader.Close();
                return "Se Realizo el Movimiento";
            }
            catch (Exception Error)
            {
                Console.WriteLine("Error Consulta Existencia: " + Error);
                return "No Se Realizo el Movimiento";
            }
        }
        public void PruebaRecorrido(clsListaEncabezado encabezado, List<clsListaDetalle> listaDetalles)
        {
            Console.WriteLine(encabezado.PkIdMovimientoEncabezado + "\n" +
                encabezado.FkEmpresa + "\n" +
                encabezado.FkSucursal + "\n" +
                encabezado.FkBodegaOrigen + "\n" +
                encabezado.FkBodegaDestino + "\n" +
                encabezado.FkRazon + "\n" +
                encabezado.FkProveedor + "\n" +
                encabezado.FkCliente + "\n" +
                encabezado.FkEncargado + "\n" +
                encabezado.FechaEncabezado + "\n" +
                encabezado.EstadoEncabezado + "\n");
            foreach (clsListaDetalle detalle in listaDetalles)
            {
                Console.WriteLine(detalle.FkMovimientoDetalle + "\n" +
                    detalle.FkIdProducto + "\n" +
                    detalle.Cantidad1 + "\n" +
                    detalle.Estado + "\n");
            }
        }
        //funcion Realizar la transaccion de movimientos
        public bool InsertarMovmientos(clsListaEncabezado encabezado, List<clsListaDetalle> listaDetalles, List<clsListaExistencia> listaExistencia, List<clsListaExistenciaMovBodegas> listaBodegas, string fkRazon)
        {
            int bandera = 0;
            var resultado = cn.ObtenerConexion();
            OdbcTransaction transaction = resultado.Item2;
            OdbcCommand cmd = resultado.Item1.CreateCommand();
            cmd.Transaction = transaction;
            try
            {
                strSql = "INSERT INTO movimientoinventarioencabezado " +
                    "(pkmovimientoe, fkempresa, fksucursal, fkbodegaorigen, fkbodegadestino, fkrazon, fkproveedor, fkcliente, fkencargado, fecha, estado)" +
                    " VALUES ('" + encabezado.PkIdMovimientoEncabezado + "','" + encabezado.FkEmpresa + "','" + encabezado.FkSucursal + "','" + encabezado.FkBodegaOrigen +  "','" + 
                    encabezado.FkBodegaDestino + "','" + encabezado.FkRazon + "','" + encabezado.FkProveedor + "','" + encabezado.FkCliente +"','" + 
                    encabezado.FkEncargado + "','" + encabezado.FechaEncabezado + "','" + encabezado.EstadoEncabezado + "');";
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("encabezado guardado");
                //Llenado del detalle
                foreach (clsListaDetalle detalle in listaDetalles)
                {
                    try
                    {
                        strSql = "INSERT INTO movimientoinventariodetalle (fkmovimiento, fkidproducto, cantidad, estado) " +
                            "VALUES ('" + detalle.FkMovimientoDetalle + "','" + detalle.FkIdProducto + "','" + detalle.Cantidad1 + "','" + detalle.Estado + "');";
                        cmd.CommandText = strSql;
                        cmd.ExecuteNonQuery();                       
                        MessageBox.Show("Detalles guardado");
                    }
                    catch (OdbcException err)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error Rollback realizado en detalles" + err.Message);
                        Console.WriteLine("eroro", err.Message);
                        bandera = 1;

                        return false;
                    }
                }
                if (fkRazon.Equals("1") || fkRazon.Equals("4"))
                {
                    //modificacion en tabla existencias suma a existencia
                    foreach (clsListaExistencia existencia in listaExistencia)
                    {
                        try
                        {
                            strSql = "update existencia set cantidad_existencia = cantidad_existencia + "+existencia.Cantidad1+" where " +
                                "fkIdEmpresa='"+existencia.IdEmpresaOrigen+ "' and fkIdSucursal='" + existencia.IdSucursalOrigen + "' " +
                                "and fkIdBodega='" + existencia.IdBodegaOrigen + "' and fkIdPro='" + existencia.IdProducto + "';";
                            cmd.CommandText = strSql;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Existencias guardado");
                        }
                        catch (OdbcException err)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error Rollback realizado en Existencias" + err.Message);
                            Console.WriteLine("eroro", err.Message);
                            bandera = 1;

                            return false;
                        }
                    }
                }
                if (fkRazon.Equals("2") || fkRazon.Equals("3"))
                {
                    //modificacion a tabla existencia resta a existencia
                    foreach (clsListaExistencia existencia in listaExistencia)
                    {
                        try
                        {
                            strSql = "update existencia set cantidad_existencia = cantidad_existencia - " + existencia.Cantidad1 + " where " +
                                "fkIdEmpresa='" + existencia.IdEmpresaOrigen + "' and fkIdSucursal='" + existencia.IdSucursalOrigen + "' " +
                                "and fkIdBodega='" + existencia.IdBodegaOrigen + "' and fkIdPro='" + existencia.IdProducto + "';";
                            cmd.CommandText = strSql;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Existencias guardado");
                        }
                        catch (OdbcException err)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error Rollback realizado en Existencias" + err.Message);
                            Console.WriteLine("eroro", err.Message);
                            bandera = 1;

                            return false;
                        }
                    }
                }
                if (fkRazon.Equals("5"))
                {
                    foreach (clsListaExistenciaMovBodegas bod in listaBodegas)
                    {
                        try
                        {
                            strSql = "update existencia set cantidad_existencia = cantidad_existencia - " + bod.Cantidad1 + " where fkIdEmpresa ='" + bod.IdEmpresaOrigen + "' and fkIdSucursal ='" + bod.IdSucursalOrigen + "' and fkIdBodega ='" + bod.IdBodegaOrigen + "' and fkIdPro ='" + bod.IdProducto + "';";
                            cmd.CommandText = strSql;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Existencias guardado");
                        }
                        catch (OdbcException err)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error Rollback realizado en Existencias" + err.Message);
                            Console.WriteLine("eroro", err.Message);
                            bandera = 1;

                            return false;
                        }
                    }
                    foreach (clsListaExistenciaMovBodegas bod in listaBodegas)
                    {
                        try
                        {
                            strSql = "update existencia set cantidad_existencia = cantidad_existencia + " + bod.Cantidad1 + " where fkIdEmpresa = '" + bod.IdEmpresaDestino + "' and fkIdSucursal = '" + bod.IdSucursalDestino + "' and fkIdBodega = '" + bod.IdBodegaDestino + "' and fkIdPro  = '" + bod.IdProducto + "'; ";
                            cmd.CommandText = strSql;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Existencias guardado");
                        }
                        catch (OdbcException err)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error Rollback realizado en Existencias" + err.Message);
                            Console.WriteLine("eroro", err.Message);
                            bandera = 1;

                            return false;
                        }
                    }
                }
                
            }
            catch (OdbcException err)
            {
                transaction.Rollback();
                MessageBox.Show("Error Rollback realizado en encabezado" + err.Message);
                bandera = 1;
                return false;
            }
            if (bandera == 0)
            {
                transaction.Commit();
                MessageBox.Show("realizando commit datos guardados");
            }
            else
            {
                bandera = 0;
            }
            return true;
        }

        public bool InsertarMovmientosBodega(List<clsListaMoverAExistencia> listaDetalles, string strNoDocumento)
        {
            int bandera = 0;
            var resultado = cn.ObtenerConexion();
            OdbcTransaction transaction = resultado.Item2;
            OdbcCommand cmd = resultado.Item1.CreateCommand();
            cmd.Transaction = transaction;
            try
            {
                strSql = "UPDATE compraencabezado SET fktipocompra = '9' WHERE (pkNoDocumentoEnca = " + strNoDocumento + ");";
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Actualizacion encabezado");
                //Llenado del detalle
                foreach (clsListaMoverAExistencia detalle in listaDetalles)
                {
                    try
                    {
                        if (detalle.IntAccion.Equals("1"))
                        {
                            Console.WriteLine("Entro al foreach");
                            strSql = "INSERT INTO existencia (fkIdEmpresa, fkIdSucursal, fkIdBodega, fkIdPro, cantidad_existencia, " +
                                "existencia_minima, existencia_maxima, estado_existencia) " +
                                "VALUES ('" + detalle.IdEmpresaOrigen + "', '" + detalle.IdSucursalOrigen + "', '" + detalle.IdBodegaOrigen + "', " +
                                "'" + detalle.IdProducto + "', '" + detalle.Cantidad1 + "', '100', '10000', '1');";
                            cmd.CommandText = strSql;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Guardado En Bodega");
                        }
                        else
                        {
                            Console.WriteLine("Entro al foreach");
                            strSql = "UPDATE existencia SET cantidad_existencia = cantidad_existencia + " + detalle.Cantidad1 + " " +
                                "WHERE (fkIdEmpresa = '" + detalle.IdEmpresaOrigen + "') and(fkIdBodega = '" + detalle.IdBodegaOrigen + "') " +
                                "and(fkIdPro = '" + detalle.IdProducto + "')and(fkIdSucursal = '" + detalle.IdSucursalOrigen + "');";
                            cmd.CommandText = strSql;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Guardado En Bodega");
                        }
                        
                    }
                    catch (OdbcException err)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error Rollback\nGuardado en bodega" + err.Message);
                        Console.WriteLine("eroro", err.Message);
                        bandera = 1;

                        return false;
                    }
                }              
            }
            catch (OdbcException err)
            {
                transaction.Rollback();
                MessageBox.Show("Error Rollback\nRealizadio en Actualizacion encabezado" + err.Message);
                bandera = 1;
                return false;
            }
            if (bandera == 0)
            {
                transaction.Commit();
                MessageBox.Show("Realizando commit datos guardados");
            }
            else
            {
                bandera = 0;
            }
            return true;
        }
    }

}
