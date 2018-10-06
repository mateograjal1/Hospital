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
    public partial class MenuPrincipalUI : Form
    {
        public MenuPrincipalUI()
        {
            InitializeComponent();
        }

        private void gestionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosUI u = new UsuariosUI();
            u.MdiParent = this;
            u.Show();
        }

        private void asignarTratamientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignarTratamientoUI ui = new AsignarTratamientoUI();
            ui.MdiParent = this;
            ui.Show();
        }
    }
}
