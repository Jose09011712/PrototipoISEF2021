using CapaControladorEncriptar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaVistaEncriptar
{
    public class clsRecepcion
    {
        clsEncriptar encriptar = new clsEncriptar();   
        public static string strKey = "b14ca5898a4e4133bbce2ea2315a1916";
        public string funcEncryp (string strParametro)
        {
            return encriptar.funcEncryptString(strKey, strParametro);           
        }
        public string funcDesencryp(string strParametro)
        {
            return encriptar.funcDecryptString(strKey, strParametro);
        }
    }
}
