using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Logica
{
    public class Tratamiento
    {
        private int consecutivo;
        private DateTime fechaAsignado;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private string descripcion;
        private string observaciones;
        private int pacienteId;

        public Tratamiento(int consecutivo, DateTime fechaAsignado, DateTime fechaInicio, DateTime fechaFin, string descripcion, string observaciones, int pacienteId)
        {
            this.Consecutivo = consecutivo;
            this.FechaAsignado = fechaAsignado;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
            this.Descripcion = descripcion;
            this.Observaciones = observaciones;
            this.PacienteId = pacienteId;
        }

        public int Consecutivo { get => consecutivo; set => consecutivo = value; }
        public DateTime FechaAsignado { get => fechaAsignado; set => fechaAsignado = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public int PacienteId { get => pacienteId; set => pacienteId = value; }
    }
}
