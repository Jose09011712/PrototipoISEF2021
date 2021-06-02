using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
   public class Sentencias
    {
        Conexion cn = new Conexion();
        OdbcCommand Comm;
        private DataTable tabla;
        public bool procInsertarDatos(string tabla, List<string> lista)
        {
            OdbcConnection con = cn.conexion();
            OdbcCommand comando = con.CreateCommand();
            OdbcTransaction transaccion;
            transaccion = con.BeginTransaction();
            string sql = " INSERT INTO " + tabla + " VALUES (";
            string consulta = sql;
            int contador = lista.Count();
            int i = 1;
            foreach (var items in lista)
            {
                if (i != contador)
                {
                    try
                    {
                        //int 
                        int.Parse(items);
                        sql += " " + items + ", ";
                        consulta += " " + items + ", ";
                    }
                    catch (Exception)
                    {
                        try
                        {
                            //double
                            double.Parse(items);
                            sql += " " + items + ", ";
                            consulta += " " + items + ", ";
                        }
                        catch (Exception)
                        {
                            try
                            {
                                //DateTimePicker
                                DateTime.Parse(items);
                                sql += " '" + items + "', ";
                                consulta += " " + items + ", ";
                            }
                            catch (Exception)
                            {
                                //string
                                sql += " '" + items + "', ";
                                consulta += " " + items + ", ";
                            }
                        }
                    }
                }
                else
                {
                    break;
                }

                i++;
            }
            var item = lista.Last();
            try
            {
                //int 
                int.Parse(item);
                sql += " " + item + ") ";
                consulta += " " + item + ") ";
            }
            catch (Exception)
            {
                sql += " '" + item + "') ";
                consulta += " " + item + ") ";
            }
            try
            {


                comando.Transaction = transaccion;
                OdbcCommand comm = new OdbcCommand(sql, cn.conexion());
                OdbcDataReader mostrarC = comm.ExecuteReader();
                Console.WriteLine("Los Datos se guardaron correctamente");
                transaccion.Commit();
                Console.WriteLine("Transaccion exitosa!!!!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString() + " \nNo existe la tabla o los campos indicados \n -" + tabla + "\n -" + ex + " " + sql);
                transaccion.Rollback();
                Console.WriteLine("Fallida!!!!");
                return false;
            }
        }
        public DataTable obtenerDosParametros(string tabla, string campo1, string campo2,string estado)
        {
     
                string sql = "SELECT " + campo1 + "," + campo2 + " FROM " + tabla + " where " + estado + " = 1 ;";
                OdbcCommand command = new OdbcCommand(sql, cn.conexion());
                OdbcDataAdapter adaptador = new OdbcDataAdapter(command);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                return dt;
      
            
        }
        public int funcObtenerCodigo(string NombreTabla, string Campo)
        {
            int Codigo = 0;
            string Sql = "SELECT MAX(" + Campo + ") FROM " + NombreTabla + " ;";
            try
            {
                OdbcCommand Command = new OdbcCommand(Sql, cn.conexion());
                OdbcDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    Codigo = Reader.GetInt32(0);
                }
            }
            catch (Exception Ex) { Console.WriteLine(Ex.Message.ToString() + " \nError al obtener codigo automatico, revise los parametros " + NombreTabla + " y " + Campo + " " + Ex + " " + " \n -\n -"); }
            return Codigo + 1;
        }

        public string funcPrecio(string codigo)
        {
            string Codigo = "";
            string Sql = "SELECT precioPro FROM producto where pkIdProducto = "+codigo+" ;";
            try
            {
                OdbcCommand Command = new OdbcCommand(Sql, cn.conexion());
                OdbcDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    Codigo = Reader.GetValue(0).ToString();
                }
            }
            catch (Exception Ex) { Console.WriteLine(Ex.Message.ToString() + " \nError al obtener codigo automatico, revise los parametros " ); }
            return Codigo;
        }

        public string[] llenarCmbDosParametros(string tabla, string campo1, string campo2,string estado )
        {

            string[] Campos = new string[300];
            string[] auto = new string[300];
            int i = 0;
            string sql = "SELECT " + campo1 + "," + campo2 + " FROM " + tabla + " where " + estado + " = 1 ;";

            try
            {
                OdbcCommand command = new OdbcCommand(sql, cn.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Campos[i] = reader.GetValue(0).ToString() + "-" + reader.GetValue(1).ToString();
                    i++;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en asignarCombo, revise los parametros \n -" + tabla + "\n -" + campo1); }
            return Campos;
        }
        //funcion para realizar consultas al a DB
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
                Console.WriteLine("Error en modelo " + Error);
                return null;
            }

        }
        //Funcion obtener datos combobox
        public DataTable funcObtenerCamposCombobox(string Comando)
        {
            try
            {
                OdbcDataAdapter datos = new OdbcDataAdapter(Comando, cn.conexion());
                tabla = new DataTable();
                datos.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //funcion para insertar en la BD
        public OdbcDataReader funcInsertar(String Consulta)
        {
            try
            {
                Comm = new OdbcCommand(Consulta, cn.conexion());
                OdbcDataReader mostrar = Comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine("Ocurrio un error al registrar modelo" + err);
                return null;
            }
        }
        //funcion para la modificacion en la DB
        public OdbcDataReader funcModificar(string Consulta)
        {
            try
            {
                Comm = new OdbcCommand(Consulta, cn.conexion());
                OdbcDataReader mostrar = Comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception Error)
            {
                Console.WriteLine("Error en modelo-modificar ", Error);
                return null;
            }
        }
    }
}
