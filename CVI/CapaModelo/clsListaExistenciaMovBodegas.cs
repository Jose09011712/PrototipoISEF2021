using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class clsListaExistenciaMovBodegas
    {
        private string idEmpresaOrigen;
        private string idSucursalOrigen;
        private string idBodegaOrigen;
        private string idEmpresaDestino;
        private string idSucursalDestino;
        private string idBodegaDestino;
        private string idProducto;
        private string Cantidad;

        public string IdEmpresaOrigen { get => idEmpresaOrigen; set => idEmpresaOrigen = value; }
        public string IdSucursalOrigen { get => idSucursalOrigen; set => idSucursalOrigen = value; }
        public string IdBodegaOrigen { get => idBodegaOrigen; set => idBodegaOrigen = value; }
        public string IdEmpresaDestino { get => idEmpresaDestino; set => idEmpresaDestino = value; }
        public string IdSucursalDestino { get => idSucursalDestino; set => idSucursalDestino = value; }
        public string IdBodegaDestino { get => idBodegaDestino; set => idBodegaDestino = value; }
        public string IdProducto { get => idProducto; set => idProducto = value; }
        public string Cantidad1 { get => Cantidad; set => Cantidad = value; }
    }
}
