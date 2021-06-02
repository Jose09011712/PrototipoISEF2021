using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModeloSeguridad
{
    public class clsModeloAplicacion
    {
        clsConexion cn = new clsConexion();
        OdbcCommand Comm;
        private DataTable tabla;

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

        //Obtener los archivos chm
        public string funcObtenerAyudaCHM(int intAplicacion)
        {           
            try
            {
                string strAyudachm = "";
                Comm = new OdbcCommand("select archivoCHM from aplicacion where pk_id_aplicacion = '" + intAplicacion + "' and estado_aplicacion = 1;", cn.conexion());
                OdbcDataReader reader = Comm.ExecuteReader();
                reader.Read();
                strAyudachm = reader.GetString(0);
                reader.Close();
                Console.WriteLine(strAyudachm);
                return strAyudachm;
            }
            catch (Exception ex)
            {
                Console.WriteLine("CapaModelo Error al consular Ayuda CHM:  " + ex);
                return "";
            }
        }

        //obtener las ayudas html
        public string funcObtenerAyudaHTML(int intAplicacion)
        {
            try
            {
                string strAyudahtml = "";
                Comm = new OdbcCommand("select archivoHTML from aplicacion where pk_id_aplicacion = " + intAplicacion + " and estado_aplicacion = 1;", cn.conexion());
                OdbcDataReader reader = Comm.ExecuteReader();
                reader.Read();
                strAyudahtml = reader.GetString(0);
                reader.Close();
                Console.WriteLine(strAyudahtml);
                return strAyudahtml;
            }
            catch (Exception ex)
            {
                Console.WriteLine("CapaModelo Error al consular Ayuda HTML:  " + ex);
                return "";
            }
        }
    }
}
