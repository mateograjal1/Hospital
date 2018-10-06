using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital.UI
{
    public partial class UsuariosUI : Form
    {
        public UsuariosUI()
        {
            InitializeComponent();            
        }

        private void PacienteBindingNavigator_RefreshItems(object sender, EventArgs e)
        {
            Debug.WriteLine("Hubo un cambio en los items");
        }

        private void pacienteBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            try
            {
                this.pacienteBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.hospitalDataSet);
                bindingNavigatorAddNewItem.Enabled = true;
            } 
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }        

        }

        private void UsuariosUI_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'hospitalDataSet.Paciente' Puede moverla o quitarla según sea necesario.
            this.pacienteTableAdapter.Fill(this.hospitalDataSet.Paciente);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            bindingNavigatorAddNewItem.Enabled = false;            
        }

        private void pacienteDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
