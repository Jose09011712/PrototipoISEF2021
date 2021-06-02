using CapaControladorSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaVistaSeguridad
{
    public class clsFuncionesAyudas
    {
        clsAplicacionMantenimiento apliMantenimiento = new clsAplicacionMantenimiento();
        //Obtener la ubicacion del archivo .chm
        public string AyudaCHM(int intAplicacion)
        {
            string strAyudaOriginal = "";
            string strAyudaConsulta = "";
            strAyudaConsulta = apliMantenimiento.funcAyudaCHM(intAplicacion);
            strAyudaOriginal = strAyudaConsulta.Replace("/", @"\\");
            return strAyudaOriginal;
        }
        public string AyudaHTML(int intAplicacion)
        {
            return apliMantenimiento.funcAyudaHTML(intAplicacion);
        }
    }
}
