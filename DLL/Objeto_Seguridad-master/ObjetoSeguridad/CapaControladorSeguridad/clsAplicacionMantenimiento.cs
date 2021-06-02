using CapaModeloSeguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladorSeguridad
{
    public class clsAplicacionMantenimiento
    {
        clsModeloAplicacion ca = new clsModeloAplicacion();
        public DataTable funcObtenerCamposComboboxPais(string Campo1, string Campo2, string Tabla, string Estado)
        {
            string Comando = string.Format("SELECT " + Campo1 + " ," + Campo2 + " FROM " + Tabla + " WHERE " + Estado + "= 1;");
            return ca.funcObtenerCamposCombobox(Comando);
        }

        public string funcAyudaCHM(int intAplicacion)
        {
            return ca.funcObtenerAyudaCHM(intAplicacion);
        }
        public string funcAyudaHTML(int intAplicacion)
        {
            return ca.funcObtenerAyudaHTML(intAplicacion);
        }
    }
}
