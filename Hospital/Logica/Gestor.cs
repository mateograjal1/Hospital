using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Logica
{
    public class Gestor
    {
        private ObservableCollection<Paciente> pacientes;
        private ObservableCollection<Tratamiento> tratamientos;

        private const string VALIDAR_USUARIO = "ValidarPaciente";
        private const string ASIGNAR_TRATAMIENTO = "AsignarTratamiento";

        private static Gestor GESTOR = new Gestor();

        private Gestor()
        {
            pacientes = new ObservableCollection<Paciente>();
            tratamientos = new ObservableCollection<Tratamiento>();
            pacientes.CollectionChanged += Pacientes_CollectionChanged;
            tratamientos.CollectionChanged += Tratamientos_CollectionChanged;
        }

        public static bool ValidarUsuario(int id)
        {
            DataTable dt = ConexionDB.EjecutarProcedimiento(VALIDAR_USUARIO, "ID", id);
            if ((int)dt.Rows[0][0] != 0)
            {
                Debug.WriteLine("Usuario " + id + " valido");
                return true;
            }
            else
            {
                Debug.WriteLine("Usuario " + id + " invalido");
                return false;
            }
        }

        public static bool AsignarTratamiento(string fechaAsignado, string descripcion, string fechaInicio, string fechaFin, string observaciones, int paciente)
        {
            return ConexionDB.EjecutarProcedimiento(ASIGNAR_TRATAMIENTO,
                    "FechaAsignado", fechaAsignado,
                    "Descripcion", descripcion,
                    "FechaInicio", fechaInicio,
                    "FechaFin", fechaFin,
                    "Observaciones", observaciones,
                    "PacientesId", paciente) != null;
        }

        private void Tratamientos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    break;
                case NotifyCollectionChangedAction.Remove:
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                default:
                    break;
            }
        }

        private void Pacientes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    break;
                case NotifyCollectionChangedAction.Remove:
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                default:
                    break;
            }
        }
    }
}
