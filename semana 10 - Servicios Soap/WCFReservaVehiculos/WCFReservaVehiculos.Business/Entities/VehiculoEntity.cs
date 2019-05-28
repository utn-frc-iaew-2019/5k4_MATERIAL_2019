using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFReservaVehiculos.Business.DataBaseModel;

namespace WCFReservaVehiculos.Business.Entities
{
    using System;
    using System.Collections.Generic;

    public class VehiculoModel
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Puntaje { get; set; }
        public decimal PrecioPorDia { get; set; }
        public bool TieneDireccion { get; set; }
        public bool TieneAireAcon { get; set; }
        public int CantidadPuertas { get; set; }
        public string TipoCambio { get; set; }
        public int CantidadDisponible { get; set; }
        public int CiudadId { get; set; }
        public int VehiculoCiudadId { get; set; }

        public VehiculoModel()
        { }

        
    }
}
