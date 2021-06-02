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
    public class Controlador
    {
        Sentencias Modelo = new Sentencias();
        Sentencias Sn = new Sentencias();
        public bool procDatosInsertar(string tabla, List<string> lista)
        {
            if (Sn.procInsertarDatos(tabla, lista))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string[] itemsDosParametros(string tabla, string campo1, string campo2,string estado)
        {
            string[] Items = Sn.llenarCmbDosParametros(tabla, campo1, campo2,estado);
            return Items;
        }
        public DataTable enviarDosParametros(string tabla, string campo1, string campo2, string estado)
        {
            var dt1 = Sn.obtenerDosParametros(tabla, campo1, campo2, estado);
            return dt1;
        }
        public int funcCodigoMaximo(string Tabla, string Campo)
        {
            int CodigoNuevo = Sn.funcObtenerCodigo(Tabla, Campo);
            return CodigoNuevo;
        }
        public string funcPrecio(string codigo)
        {
            string presio = Sn.funcPrecio(codigo);
            return presio;
        }
        //clsVariableGlobal glo = new clsVariableGlobal();
        public DataTable funcObtenerCamposCombobox(string Campo1, string Campo2, string Tabla, string Estado)
        {
            string Comando = string.Format("SELECT " + Campo1 + " ," + Campo2 + " FROM " + Tabla + " WHERE " + Estado + "= 1;");
            return Modelo.funcObtenerCamposCombobox(Comando);
        }
        public OdbcDataReader funcConsultaCombo(string Campo1, string Campo2, string Tabla, string Estado, string Codigo)
        {
            string Comando = string.Format("SELECT " + Campo1 + " FROM " + Tabla + " WHERE " + Estado + "= 1 AND " + Campo2 + " = " + Codigo + ";");
            return Modelo.funcConsulta(Comando);

        }
        public OdbcDataReader funcEliminar_perfil(string Codigo)
        {
            string Consulta = "UPDATE  control_producto SET resultado_control_producto = 'Finalizado', estado_control_producto = 0 where pk_id_control_producto = " + Codigo + ";";
            return Modelo.funcModificar(Consulta);
        }
        public OdbcDataReader funcConsultaDetallesCUI(string Tabla, string CodPedido)
        {
            string Consulta = "SELECT * FROM " + Tabla + " Where pk_id_usuario_pasaporte = " + CodPedido + ";";
            return Modelo.funcConsulta(Consulta);
        }
        public OdbcDataReader funcConsultaBanco(string Tabla, string CodPedido)
        {
            string Consulta = "SELECT estado_boleta FROM " + Tabla + " Where pk_numero_boleta = " + CodPedido + ";";
            return Modelo.funcConsulta(Consulta);
        }
        //Funcion para obtener datos combobox
        public DataTable funcObtenerCamposComboboxPais(string Campo1, string Campo2, string Tabla, string Estado)
        {
            string Comando = string.Format("SELECT " + Campo1 + " ," + Campo2 + " FROM " + Tabla + " WHERE " + Estado + "= 1;");
            return Modelo.funcObtenerCamposCombobox(Comando);
        }
        public DataTable funcObtenerCamposComboboxtipoorden(string Campo1, string Campo2, string Tabla, string Estado)
        {
            string Comando = string.Format("SELECT " + Campo1 + " ," + Campo2 + " FROM " + Tabla + " WHERE " + Estado + "= 1 LIMIT 2;");
            return Modelo.funcObtenerCamposCombobox(Comando);
        }
    }
}
