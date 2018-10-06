using Hospital.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital.UI
{
    public partial class ConsultarTratamientoUI : Form
    {
        public ConsultarTratamientoUI()
        {
            InitializeComponent();
        }

        private void txtCedula_Validating(object sender, CancelEventArgs e)
        {
            int cedula;
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

        private void butConsultar_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

            }
        }
    }
}
