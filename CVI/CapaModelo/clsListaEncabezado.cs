using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class clsListaEncabezado
    {
        private string pkIdMovimientoEncabezado;
        private string fkEmpresa;
        private string fkSucursal;
        private string fkBodegaOrigen;
        private string fkBodegaDestino;
        private string fkRazon;
        private string fkProveedor;
        private string fkCliente;
        private string fkEncargado;
        private string fechaEncabezado;
        private string estadoEncabezado;

        public string PkIdMovimientoEncabezado { get => pkIdMovimientoEncabezado; set => pkIdMovimientoEncabezado = value; }
        public string FkEmpresa { get => fkEmpresa; set => fkEmpresa = value; }
        public string FkSucursal { get => fkSucursal; set => fkSucursal = value; }
        public string FkBodegaOrigen { get => fkBodegaOrigen; set => fkBodegaOrigen = value; }
        public string FkBodegaDestino { get => fkBodegaDestino; set => fkBodegaDestino = value; }
        public string FkRazon { get => fkRazon; set => fkRazon = value; }
        public string FkProveedor { get => fkProveedor; set => fkProveedor = value; }
        public string FkCliente { get => fkCliente; set => fkCliente = value; }
        public string FkEncargado { get => fkEncargado; set => fkEncargado = value; }
        public string FechaEncabezado { get => fechaEncabezado; set => fechaEncabezado = value; }
        public string EstadoEncabezado { get => estadoEncabezado; set => estadoEncabezado = value; }
    }
}
