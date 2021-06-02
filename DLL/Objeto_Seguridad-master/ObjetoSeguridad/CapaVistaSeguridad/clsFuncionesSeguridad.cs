//Billy Jeshua Sican Matias
//0901-17-16250
using CapaControladorSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaVistaSeguridad
{
    public class clsFuncionesSeguridad
    {
        clsObtenerPermisos obtenerPermisos = new clsObtenerPermisos();
        //permisos para navegador (Solo uso del Navegador)
        public string Permisos(string strAplicacion, string strUsuario)
        {
            string strPermisos = obtenerPermisos.funcPermisosPorPerfil(strAplicacion, strUsuario);
            if (strPermisos == null)
            {
                strPermisos = obtenerPermisos.funcPermisosPorAplicacion(strAplicacion, strUsuario);
                if (strPermisos == null)
                {
                    Console.WriteLine("Tiene los siguientes permisos " + strPermisos);
                    return "0,0,0,0,0";
                }
                else
                {
                    Console.WriteLine("Tiene los siguientes permisos " + strPermisos);
                    return strPermisos;
                }
            }
            else
            {
                Console.WriteLine("Tiene los siguientes permisos " + strPermisos);
                return strPermisos;
            }
        }

        //Verifica si tiene permiso a la aplicacion
        public int PermisosAcceso(string strIdAplicacion, string strUsuario)
        {
            int permisos = obtenerPermisos.funcAccesoAplicacionPerfil(strIdAplicacion, strUsuario);
            Console.WriteLine("Tiene permiso por perfil "+permisos);
            if (permisos == 0)
            { 
                permisos = obtenerPermisos.funcAccesoAplicacion(strIdAplicacion, strUsuario);
                Console.WriteLine("Tiene permiso por aplicacion "+permisos);
                if (permisos == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }

    }
}
