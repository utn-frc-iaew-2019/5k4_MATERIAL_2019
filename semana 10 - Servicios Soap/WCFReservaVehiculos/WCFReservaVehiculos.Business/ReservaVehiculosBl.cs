using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFReservaVehiculos.Business.DataBaseModel;
using WCFReservaVehiculos.Business.Entities;
using WCFReservaVehiculos.Business.ExceptionHandling;

namespace WCFReservaVehiculos.Business
{
    public class ReservaVehiculosBl : IDisposable
    {
        private string sSource = "WCFReservaVehiculos";
        private readonly ReservaVehiculosDataBaseEntities _context;
        public ReservaVehiculosBl()
        {
            _context = new ReservaVehiculosDataBaseEntities();
            //if (!EventLog.SourceExists("WCFReservaVehiculos"))
            //    EventLog.CreateEventSource("WCFReservaVehiculos", "Application");
        }

        public ConsultarVehiculosDisponiblesResponse ConsultarVehiculosDisponibles(ConsultarVehiculosRequest request, string userName = "")
        {


            if (!_context.Ciudad.Any(p => p.Id == request.IdCiudad))
                throw new CustomException(1, "La ciudad no se encuentra registrada.");

            var reservas = (from r in _context.Reserva
                            where (r.FechaHoraRetiro >= request.FechaHoraRetiro && r.FechaHoraRetiro <= request.FechaHoraDevolucion) ||
                                  (r.FechaHoraDevolucion >= request.FechaHoraRetiro && r.FechaHoraDevolucion <= request.FechaHoraDevolucion)
                                  && r.Estado == EstadoReservaEnum.Activa
                            group r by r.VehiculoPorCiudadId
                                into grp
                                select new { Key = grp.Key, Count = grp.Count() });

            var queryResult = (from v in _context.Vehiculo
                               join c in _context.VehiculoPorCiudad on v.Id equals c.VehiculoId
                               where c.CiudadId == request.IdCiudad
                               select new VehiculoModel()
                               {
                                   Id = v.Id,
                                   Modelo = v.Modelo,
                                   Marca = v.Marca,
                                   Puntaje = v.Puntaje,
                                   PrecioPorDia = v.PrecioPorDia,
                                   TieneDireccion = v.TieneDireccion,
                                   TieneAireAcon = v.TieneAireAcon,
                                   CantidadPuertas = v.CantidadPuertas,
                                   TipoCambio = v.TipoCambio,
                                   CantidadDisponible = c.CantidadDisponible,
                                   CiudadId = c.CiudadId,
                                   VehiculoCiudadId = c.Id
                               });

            var result = queryResult.ToList();
            foreach (var item in result.Where(item => reservas.Any(p => p.Key == item.VehiculoCiudadId)))
            {
                item.CantidadDisponible -= reservas.First(p => p.Key == item.VehiculoCiudadId).Count;
            }
            return new ConsultarVehiculosDisponiblesResponse(DateTime.Now, result);
        }

        public ReservarVehiculoResponse ReservarVehiculo(ReservarVehiculoRequest request, string userName)
        {

            //EventLog.WriteEntry(sSource, "Inicio Metodo. Request: " + request.ToString() + " username: " + userName, EventLogEntryType.Information, 234);

            var vehiculoSel1 = _context.VehiculoPorCiudad.Include("VehiculoEntity");

            var vehiculoSel = vehiculoSel1.FirstOrDefault(p => p.Id == request.IdVehiculoCiudad);


            if (vehiculoSel == null)
                throw new CustomException(21, "El vehículo seleccionado no existe.");

            var reservas = (from r in _context.Reserva
                            where r.VehiculoPorCiudadId == request.IdVehiculoCiudad &&
                                  (r.FechaHoraRetiro > request.FechaHoraRetiro && r.FechaHoraRetiro < request.FechaHoraDevolucion) ||
                                  (r.FechaHoraDevolucion > request.FechaHoraRetiro && r.FechaHoraDevolucion < request.FechaHoraDevolucion)
                                  && r.Estado == EstadoReservaEnum.Activa
                            select new { }).Count();


            if ((vehiculoSel.CantidadDisponible - reservas) <= 0)
                throw new CustomException(22, "El vehículo no se encuentra disponible.");

            var diffFecha = request.FechaHoraDevolucion.Subtract(request.FechaHoraRetiro);

            var nvaReserva = new ReservaEntity()
            {
                CodigoReserva = GenerarCodigoReserva(),
                ApellidoNombreCliente = request.ApellidoNombreCliente,
                NroDocumentoCliente = request.NroDocumentoCliente,
                LugarRetiro = request.LugarRetiro.ToString(),
                FechaHoraRetiro = request.FechaHoraRetiro,
                LugarDevolucion = request.LugarDevolucion.ToString(),
                FechaHoraDevolucion = request.FechaHoraDevolucion,
                FechaReserva = DateTime.Now,
                TotalReserva = vehiculoSel.VehiculoEntity.PrecioPorDia * (decimal)diffFecha.TotalDays,
                UsuarioReserva = userName,
                VehiculoPorCiudadId = vehiculoSel.Id,
                Estado = EstadoReservaEnum.Activa
            };

            _context.Reserva.Add(nvaReserva);

            _context.SaveChanges();

            return new ReservarVehiculoResponse(DateTime.Now, nvaReserva);
        }

        public ConsultarReservasResponse ConsultarReserva(ConsultarReservasRequest request, string userName)
        {
            if (request.CodigoReserva != null)
            {

                var reserva = _context.Reserva.FirstOrDefault(
                    p => p.UsuarioReserva == userName && p.CodigoReserva == request.CodigoReserva);

                if (reserva != null)
                {
                    return new ConsultarReservasResponse(DateTime.Now, reserva);
                }
            }
            throw new CustomException(31, string.Concat("La reserva ", request.CodigoReserva, " no fue encontrada."));

        }

        public CancelarReservaResponse CancelarReserva(CancelarReservaRequest request, string userName)
        {
            var reserva = _context.Reserva.FirstOrDefault(p => p.CodigoReserva == request.CodigoReserva && p.UsuarioReserva == userName);
            if (reserva == null)
                throw new CustomException(41, "La reserva que se desea cancelar no existe.");

            if (reserva.Estado != EstadoReservaEnum.Activa)
                throw new CustomException(42, "La reserva se encuentra cancelada. Fecha Cancelación: " + reserva.FechaCancelacion);


            reserva.Estado = EstadoReservaEnum.Cancelada;
            reserva.FechaCancelacion = DateTime.Now;
            reserva.UsuarioCancelacion = userName;

            _context.Entry(reserva).State = EntityState.Modified;

            _context.SaveChanges();

            return new CancelarReservaResponse(DateTime.Now, reserva);
        }

        private static string GenerarCodigoReserva()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 5)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ReservaVehiculosBl()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            // free native resources here if there are any
        }
        #endregion

        public ConsultarCiudadesResponse ConsultarCiudades(ConsultarCiudadesRequest request, string userName)
        {
            var ciudades = _context.Ciudad.Include("PaisEntity").Where(p => p.PaisId == request.IdPais);
            if (!ciudades.Any())
                throw new CustomException(51, "No se encontraron ciudades.");

            var ciudad = ciudades.ToList();
            return new ConsultarCiudadesResponse(DateTime.Now, ciudad);
        }

        public ConsultarPaisesResponse ConsultarPaises(string userName)
        {
            var paises = _context.Pais;
            if (!paises.Any())
                throw new CustomException(61, "No se encontraron paises.");

            return new ConsultarPaisesResponse(DateTime.Now, paises.ToList());
        }


        public bool ValidarUsuario(string userName, string password)
        {
            return _context.Usuario.Any(p => p.UserName == userName && p.Password == password);
        }
    }
}
