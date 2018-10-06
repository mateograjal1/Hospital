using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hospital.Logica;

namespace Hospital.UI
{
    public partial class AsignarTratamientoUI : Form
    {
        private int cedula;

        public AsignarTratamientoUI()
        {
            InitializeComponent();
        }

        private void txtCedula_Validating(object sender, CancelEventArgs e)
        {
            if (!Int32.TryParse(txtCedula.Text.Trim(), out cedula))
            {
                e.Cancel = true;
                error.SetError(txtCedula, "Cedula invalida");
            }
            else if (!Gestor.ValidarUsuario(cedula))
            {
                e.Cancel = true;
                error.SetError(txtCedula, "Usuario invalido");
            }
            else
            {
                error.SetError(txtCedula, "");
            }
        }

        private void butAceptar_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (Gestor.AsignarTratamiento(dtpFechaAsignado.Text, txtDescripcion.Text, dtpFechaInicio.Text, dtpFechaFinalizacion.Text, txtObservaciones.Text, cedula))
                {
                    MessageBox.Show("Tratamiento asignado correctamente");
                    this.Close();
                }
            }
        }

        private void dtpFechaAsignado_Validating(object sender, CancelEventArgs e)
        {
            if (dtpFechaAsignado.Value.Date > DateTime.Today)
            {
                e.Cancel = true;
                error.SetError(dtpFechaAsignado, "La fecha de asignacion no puede ser en el futuro");
            }
            else
            {
                error.SetError(dtpFechaAsignado, "");
            }
        }

        private void txtDescripcion_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                e.Cancel = true;
                error.SetError(txtDescripcion, "La descripcion no puede estar vacia");
            }
            else
            {
                error.SetError(txtDescripcion, "");
            }
        }

        private void txtObservaciones_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtObservaciones.Text.Trim()))
            {
                e.Cancel = true;
                error.SetError(txtObservaciones, "Las observaciones no puede estar vacias");
            }
            else
            {
                error.SetError(txtObservaciones, "");
            }
        }

        private void dtpFechaInicio_Validating(object sender, CancelEventArgs e)
        {
            if (dtpFechaInicio.Value.Date < DateTime.Today)
            {
                e.Cancel = true;
                error.SetError(dtpFechaInicio, "La fecha de inicio no puede ser en el pasado");
            }
            else if (dtpFechaInicio.Value.Date < dtpFechaAsignado.Value.Date)
            {
                e.Cancel = true;
                error.SetError(dtpFechaInicio, "La fecha de inicio no puede ser menor a la fecha de asignacion");
            }
            else
            {
                error.SetError(dtpFechaInicio, "");
            }
        }

        private void dtpFechaFinalizacion_Validating(object sender, CancelEventArgs e)
        {
            if (dtpFechaFinalizacion.Value.Date < DateTime.Today)
            {
                e.Cancel = true;
                error.SetError(dtpFechaFinalizacion, "La fecha de inicio no puede ser en el pasado");
            }
            else if (dtpFechaFinalizacion.Value.Date < dtpFechaAsignado.Value.Date)
            {
                e.Cancel = true;
                error.SetError(dtpFechaFinalizacion, "La fecha de finalizacion no puede ser menor a la fecha de asignacion");
            }
            else if (dtpFechaFinalizacion.Value.Date < dtpFechaInicio.Value.Date)
            {
                e.Cancel = true;
                error.SetError(dtpFechaFinalizacion, "La fecha de finalizacion no puede ser menor a la fecha de inicio");
            }
            else
            {
                error.SetError(dtpFechaFinalizacion, "");
            }
        }
    }
}
