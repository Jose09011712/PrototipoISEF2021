using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class clsListaDetalle
    {
        private string fkMovimientoDetalle;
        private string fkIdProducto;
        private string Cantidad;
        private string estado;

        public string FkMovimientoDetalle { get => fkMovimientoDetalle; set => fkMovimientoDetalle = value; }
        public string FkIdProducto { get => fkIdProducto; set => fkIdProducto = value; }
        public string Cantidad1 { get => Cantidad; set => Cantidad = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
