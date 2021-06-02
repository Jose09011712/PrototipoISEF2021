using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class clsListaMoverAExistencia
    {
        private string idEmpresaOrigen;
        private string idSucursalOrigen;
        private string idBodegaOrigen;
        private string idProducto;
        private string Cantidad;
        private string intAccion;

        public string IdEmpresaOrigen { get => idEmpresaOrigen; set => idEmpresaOrigen = value; }
        public string IdSucursalOrigen { get => idSucursalOrigen; set => idSucursalOrigen = value; }
        public string IdBodegaOrigen { get => idBodegaOrigen; set => idBodegaOrigen = value; }
        public string IdProducto { get => idProducto; set => idProducto = value; }
        public string Cantidad1 { get => Cantidad; set => Cantidad = value; }
        public string IntAccion { get => intAccion; set => intAccion = value; }
    }
}
